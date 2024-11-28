using FrontEnd.Models;
using System.Security.Cryptography;
using System.Text;


namespace FrontEnd.Servicio
{
    public class TokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TokenService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetTokenAsync(string username, string password)
        {
            var requestBody = new Usser
            {
                cUsername = username,
                cPassword = password
            };

            requestBody.cPassword = ComputeSha256Hash(requestBody.cPassword);
            //return Ok(oUsser);
            requestBody = EncryptUser(requestBody);

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5224/api/Auth/login", requestBody);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
                return jsonResponse?.cToken;
            }

            return null;
        }

        public Usser EncryptUser(Usser user)

        {
            string key = _configuration["ClaveCifrado:ClaveSimetrica"];
            Usser encryptedUser = new Usser();
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.GenerateIV(); // Genera un IV aleatorio

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Encriptar el username
                using (MemoryStream msEncryptUsername = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncryptUsername, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(user.cUsername);
                        }
                    }
                    encryptedUser.cUsername = Convert.ToBase64String(msEncryptUsername.ToArray());
                }

                // Encriptar la contraseña (password)
                using (MemoryStream msEncryptPassword = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncryptPassword, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(user.cPassword);
                        }
                    }
                    encryptedUser.cPassword = Convert.ToBase64String(msEncryptPassword.ToArray());
                }

                // Almacenar el IV para la desencriptación
                encryptedUser.cVectorInicializacion = aesAlg.IV;
            }
            return encryptedUser;
        }

        public string ComputeSha256Hash(string rawData)
        {
            // Crear un objeto SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el hash a partir del string de entrada
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convertir el arreglo de bytes a un string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
