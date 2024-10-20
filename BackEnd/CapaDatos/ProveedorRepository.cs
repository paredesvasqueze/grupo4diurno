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
    public class ProveedorRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public ProveedorRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Proveedors
        public IEnumerable<Proveedor> ObtenerProveedorTodos()
        {
            var Proveedors = new List<Proveedor>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Proveedor> lstFound = new List<Proveedor>();
                var query = "SeleccionarProveedores";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Proveedor>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public int InsertarProveedor(Proveedor cProveedor)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "InsertarProveedor";
                var param = new DynamicParameters();
                param.Add("@cNombre", cProveedor.cNombre);
                param.Add("@cContacto", cProveedor.cContacto);
                param.Add("@cTelefono", cProveedor.cTelefono);
                param.Add("@cEmail", cProveedor.cEmail);
                param.Add("@cDireccion", cProveedor.cDireccion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
        public int ActualizarProveedor(Proveedor cProveedor)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "ActualizarProveedor";
                var param = new DynamicParameters();
                param.Add("@nIdProveedor", cProveedor.nIdProveedor);
                param.Add("@cNombre", cProveedor.cNombre);
                param.Add("@cContacto", cProveedor.cContacto);
                param.Add("@cTelefono", cProveedor.cTelefono);
                param.Add("@cEmail", cProveedor.cEmail);
                param.Add("@cDireccion", cProveedor.cDireccion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int EliminarProveedor(Proveedor cProveedor)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "EliminarProveedor";
                var param = new DynamicParameters();
                param.Add("@nIdProveedor", cProveedor.nIdProveedor);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

              }

        }
}



