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
    public class ProductoRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public ProductoRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Productos
        public IEnumerable<Producto> ObtenerProductoTodos()
        {
            var Productos = new List<Producto>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Producto> lstFound = new List<Producto>();
                var query = "SeleccionarProductos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Producto>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int InsertarProducto(Producto cProducto)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "InsertarProducto";
                var param = new DynamicParameters();
                param.Add("@nIdProveedor", cProducto.nIdProveedor);
                param.Add("@nIdCategoria", cProducto.nIdCategoria);
                param.Add("@cNombre", cProducto.cNombre);
                param.Add("@cDescripcion", cProducto.cDescripcion);
                param.Add("@pPrecio", cProducto.pPrecio);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
        public int ActualizarProducto(Producto cProducto)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "ActualizarProducto";
                var param = new DynamicParameters();
                param.Add("@nIdProducto", cProducto.nIdProducto);
                param.Add("@nIdProveedor", cProducto.nIdProveedor);
                param.Add("@nIdCategoria", cProducto.nIdCategoria);
                param.Add("@cNombre", cProducto.cNombre);
                param.Add("@cDescripcion", cProducto.cDescripcion);
                param.Add("@pPrecio", cProducto.pPrecio);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int EliminarProducto(Producto cProducto)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "EliminarProducto";
                var param = new DynamicParameters();
                param.Add("@nIdProducto", cProducto.nIdProducto);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int SeleccionarProducto(Producto cProducto)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "SeleccionarProducto";
                var param = new DynamicParameters();
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
    }
}


