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
    public class DetallesOrdenCompraRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public DetallesOrdenCompraRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de DetallesOrdenCompras
        public IEnumerable<DetallesOrdenCompra> ObtenerDetallesOrdenCompraTodos()
        {
            var DetallesOrdenCompras = new List<DetallesOrdenCompra>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<DetallesOrdenCompra> lstFound = new List<DetallesOrdenCompra>();
                var query = "SeleccionarDetallesOrdenCompra";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<DetallesOrdenCompra>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;
            }
        }

        public int InsertarDetalleOrdenCompra(DetallesOrdenCompra oDetallesOrdenCompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                
                var query = "InsertarDetalleOrdenCompra";
                var param = new DynamicParameters();
                param.Add("@nIdOrdenCompra", oDetallesOrdenCompra.nIdOrdenCompra);
                param.Add("@nIdProducto", oDetallesOrdenCompra.nIdProducto);
                param.Add("@pCantidad", oDetallesOrdenCompra.pCantidad);
                param.Add("@pPrecio", oDetallesOrdenCompra.pPrecio);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }
        }

        public int ActualizarDetalleOrdenCompra(DetallesOrdenCompra oDetallesOrdenCompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "ActualizarDetalleOrdenCompra";
                var param = new DynamicParameters();
                param.Add("@nIdDetalle", oDetallesOrdenCompra.nIdDetalle);
                param.Add("@nIdOrdenCompra", oDetallesOrdenCompra.nIdOrdenCompra);
                param.Add("@nIdProducto", oDetallesOrdenCompra.nIdProducto);
                param.Add("@pCantidad", oDetallesOrdenCompra.pCantidad);
                param.Add("@pPrecio", oDetallesOrdenCompra.pPrecio);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }




        public int EliminarDetalleOrdenCompra(DetallesOrdenCompra oDetallesOrdenCompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "EliminarDetalleOrdenCompra(";
                var param = new DynamicParameters();
                param.Add("@nIdDetalle", oDetallesOrdenCompra.nIdDetalle);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

    }
}