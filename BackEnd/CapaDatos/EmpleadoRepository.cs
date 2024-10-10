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
    public class EmpleadoRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public EmpleadoRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Empleados
        public IEnumerable<Empleado> ObtenerEmpleadoTodos()
        {
            var Empleados = new List<Empleado>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Empleado> lstFound = new List<Empleado>();
                var query = "USP_GET_Empleado_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Empleado>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int InsertarEmpleado(Empleado cEmpleado)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "InsertarEmpleado";
                var param = new DynamicParameters();
                param.Add("@cNombre", cEmpleado.cNombre);
                param.Add("@cApellido", cEmpleado.cApellido);
                param.Add("@cPuesto", cEmpleado.cPuesto);
                param.Add("@dFechaContrato", cEmpleado.dFechaContrato);
                param.Add("@pSalario", cEmpleado.pSalario);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
        public int ActualizarEmpleado(Empleado cEmpleado)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "ActualizarEmpleado";
                var param = new DynamicParameters();
                param.Add("@nIdEmpleado", cEmpleado.nIdEmpleado);
                param.Add("@cNombre", cEmpleado.cNombre);
                param.Add("@cApellido", cEmpleado.cApellido);
                param.Add("@cPuesto", cEmpleado.cPuesto);
                param.Add("@dFechaContrato", cEmpleado.dFechaContrato);
                param.Add("@pSalario", cEmpleado.pSalario);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int EliminarEmpleado(Empleado cEmpleado)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "EliminarEmpleado";
                var param = new DynamicParameters();
                param.Add("@nIdEmpleado", cEmpleado.nIdEmpleado);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int SeleccionarEmpleado(Empleado cEmpleado)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "SeleccionarEmpleado";
                var param = new DynamicParameters();
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
    }
}


