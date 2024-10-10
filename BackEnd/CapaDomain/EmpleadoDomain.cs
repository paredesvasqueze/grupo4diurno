using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class EmpleadoDomain
    {
        private readonly EmpleadoRepository _EmpleadoRepository;

        public EmpleadoDomain(EmpleadoRepository EmpleadoRepository)
        {
           
                _EmpleadoRepository = EmpleadoRepository;     
        }

        public IEnumerable<Empleado> ObtenerEmpleadoTodos()
        {
            try
            {
                return _EmpleadoRepository.ObtenerEmpleadoTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarEmpleado(Empleado cEmpleado)
        {
            try
            {
                return _EmpleadoRepository.InsertarEmpleado(cEmpleado);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public int ActualizarEmpleado(Empleado cEmpleado)
        {
            try
            {
                return _EmpleadoRepository.ActualizarEmpleado(cEmpleado);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int EliminarEmpleado(Empleado cEmpleado)
        {
            try
            {
                return _EmpleadoRepository.EliminarEmpleado(cEmpleado);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int SeleccionarEmpleado(Empleado cEmpleado)
        {
            try
            {
                return _EmpleadoRepository.SeleccionarEmpleado(cEmpleado);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
