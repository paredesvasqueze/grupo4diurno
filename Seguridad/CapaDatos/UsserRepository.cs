using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Dapper;

namespace CapaDatos
{
    public class UsserRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public UsserRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }
       
        public bool ValidarUsuario(Usser oUsser)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                var query = "ValidarUsuario";
                var param = new DynamicParameters();
                param.Add("@cUserName", oUsser.cUsername);
                param.Add("@cPassword", oUsser.cPassword.ToUpper());
                return (bool)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }
        }       
       
    }
}
