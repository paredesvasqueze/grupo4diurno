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
    public class OrdenCompraRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public OrdenCompraRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de alumnos
        public IEnumerable<OrdenCompra> SeleccionarOrdenesCompra()
        {
            var ordenCompra = new List<OrdenCompra>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<OrdenCompra> lstFound = new List<OrdenCompra>();
                var query = "SeleccionarOrdenesCompra";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<OrdenCompra>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }



        public int InsertarOrdenCompra(OrdenCompra oOrdenCompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "InsertarOrdenCompra";
                var param = new DynamicParameters();
                param.Add("@nIdProveedor", oOrdenCompra.nIdProveedor);
                param.Add("@dFecha", oOrdenCompra.dFecha);
                param.Add("@pTotal", oOrdenCompra.pTotal);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarOrdenCompra(OrdenCompra oOrdenCompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "ActualizarOrdenCompra";
                var param = new DynamicParameters();
                param.Add("@nIdOrdenCompra", oOrdenCompra.nIdOrdenCompra);
                param.Add("@nIdProveedor", oOrdenCompra.nIdProveedor);
                param.Add("@dFecha", oOrdenCompra.dFecha);
                param.Add("@pTotal", oOrdenCompra.pTotal);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }



        public int EliminarOrdenCompra(int nIdOrdenCompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "EliminarOrdenCompra";
                var param = new DynamicParameters();
                param.Add("@nIdOrdenCompra", nIdOrdenCompra);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

    }
}