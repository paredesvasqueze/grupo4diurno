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
    public class InventarioRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public InventarioRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de alumnos
        public IEnumerable<Inventario> SeleccionarInventarios()
        {
            var Inventario = new List<Inventario>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Inventario> lstFound = new List<Inventario>();
                var query = "SeleccionarInventarios";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Inventario>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }



        public int InsertarInventario(Inventario oInventario)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "InsertarInventario";
                var param = new DynamicParameters();
                param.Add("@nIdProducto", oInventario.nIdProducto);
                param.Add("@dFechaActualizar", oInventario.dFechaActualizar);
                param.Add("@pCantidad", oInventario.pCantidad);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }



        public int ActualizarInventario(Inventario oInventario)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "ActualizarInventario";
                var param = new DynamicParameters();
                param.Add("@nIdInventario", oInventario.nIdInventario);
                param.Add("@nIdProducto", oInventario.nIdProducto);
                param.Add("@dFechaActualizar", oInventario.dFechaActualizar);
                param.Add("@pCantidad", oInventario.pCantidad);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }



        public int EliminarInventario(int nIdInventario)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "EliminarInventario";
                var param = new DynamicParameters();
                param.Add("@nIdInventario", nIdInventario);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

    }
}