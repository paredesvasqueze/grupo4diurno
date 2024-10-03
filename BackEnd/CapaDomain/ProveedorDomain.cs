using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class ProveedorDomain
    {
        private readonly ProveedorRepository _ProveedorRepository;

        public ProveedorDomain(ProveedorRepository ProveedorRepository)
        {
           
                _ProveedorRepository = ProveedorRepository;     
        }

        public IEnumerable<Proveedor> ObtenerProveedorTodos()
        {
            try
            {
                return _ProveedorRepository.ObtenerProveedorTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarProveedor(Proveedor oProveedor)
        {
            try
            {
                return _ProveedorRepository.InsertarProveedor(oProveedor);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public int ActualizarProveedor(Proveedor oProveedor)
        {
            try
            {
                return _ProveedorRepository.InsertarProveedor(oProveedor);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int EliminarProveedor(Proveedor oProveedor)
        {
            try
            {
                return _ProveedorRepository.EliminarProveedor(oProveedor);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int SeleccionarProveedor(Proveedor oProveedor)
        {
            try
            {
                return _ProveedorRepository.EliminarProveedor(oProveedor);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
