using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class ProductoDomain
    {
        private readonly ProductoRepository _ProductoRepository;

        public ProductoDomain(ProductoRepository ProductoRepository)
        {
           
                _ProductoRepository = ProductoRepository;     
        }

        public IEnumerable<Producto> ObtenerProductoTodos()
        {
            try
            {
                return _ProductoRepository.ObtenerProductoTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarProducto(Producto oProducto)
        {
            try
            {
                return _ProductoRepository.InsertarProducto(oProducto);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int ActualizararProducto(Producto oProducto)
        {
            try
            {
                return _ProductoRepository.InsertarProducto(oProducto);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int EliminarProducto(Producto oProducto)
        {
            try
            {
                return _ProductoRepository.EliminarProducto(oProducto);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
