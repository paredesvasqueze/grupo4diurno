using CapaEntidad;
using CapaDatos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace CapaDomain
{
    public class UsserDomain
    {
        private readonly UsserRepository _UserRepository;
        private readonly IConfiguration _configuration;

        public UsserDomain(IConfiguration configuration, UsserRepository UserRepository)
        {
            _UserRepository = UserRepository;
            _configuration = configuration;
        }       

        public Respuesta ValidarUsuario(Usser oUsser)
        {
            var resouesta = new Respuesta() ;

            oUsser = DecryptUser(oUsser);

            if (_UserRepository.ValidarUsuario(oUsser) )
            {
                resouesta.cMensaje = "OK";
                resouesta.cToken = GenerateToken(oUsser.cUsername);             
            }
            else
            {
                resouesta.cMensaje = "Usuario o Clave Incorrecta";
                resouesta.cToken = "";
            }
            return resouesta;
        }

        private string GenerateToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username)
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

               

        public  Usser DecryptUser(Usser encryptedUser)        {
            {
                string key = _configuration["ClaveCifrado:ClaveSimetrica"];
            Usser decryptedUser = new Usser();

            // Convertir el IV y la clave a byte arrays
            byte[] ivBytes = encryptedUser.cVectorInicializacion;
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            // Verificar que el IV tenga 16 bytes (128 bits) para AES
            if (ivBytes.Length != 16)
            {
                throw new CryptographicException("El tamaño del IV debe ser de 16 bytes (128 bits) para AES.");
            }

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                // Desencriptar el nombre de usuario
                using (MemoryStream msDecryptUsername = new MemoryStream(Convert.FromBase64String(encryptedUser.cUsername)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecryptUsername, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decryptedUser.cUsername = srDecrypt.ReadToEnd();
                        }
                    }
                }

                // Desencriptar la contraseña
                using (MemoryStream msDecryptPassword = new MemoryStream(Convert.FromBase64String(encryptedUser.cPassword)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecryptPassword, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decryptedUser.cPassword = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return decryptedUser;
        }


    }
    }
}
