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
    public class CategoriaRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public CategoriaRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Categorias
        public IEnumerable<Categoria> ObtenerCategoriaTodos()
        {
            var Categorias = new List<Categoria>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Categoria> lstFound = new List<Categoria>();
                var query = "SeleccionarCategorias";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Categoria>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int InsertarCategoria(Categoria cCategoria)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "InsertarCategoria";
                var param = new DynamicParameters();
                param.Add("@cNombre", cCategoria.cNombre);
                param.Add("@cDescripcion", cCategoria.cDescripcion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
        public int ActualizarCategoria(Categoria cCategoria)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "ActualizarCategoria";
                var param = new DynamicParameters();
                param.Add("@nIdCategoria", cCategoria.nIdCategoria);
                param.Add("@cNombre", cCategoria.cNombre);
                param.Add("@cDescripcion", cCategoria.cDescripcion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int EliminarCategoria(Categoria cCategoria)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "EliminarCategoria";
                var param = new DynamicParameters();
                param.Add("@nIdCategoria", cCategoria.nIdCategoria);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}


