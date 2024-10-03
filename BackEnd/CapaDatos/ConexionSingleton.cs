using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionSingleton
    {
        private static ConexionSingleton _instance;
        private readonly string _connectionString;

        // Constructor privado para Singleton
        private ConexionSingleton(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaConnection");
        }

        // Método estático para obtener la instancia Singleton
        public static ConexionSingleton GetInstance(IConfiguration configuration)
        {
            if (_instance == null)
            {
                _instance = new ConexionSingleton(configuration);
            }
            return _instance;
        }

        // Método para obtener una conexión a la base de datos
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
