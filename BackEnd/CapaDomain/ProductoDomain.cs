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

        public Producto GetProductoId(int nIdProducto)
        {
            try
            {
                return _ProductoRepository.GetProductoId(nIdProducto);
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

        public int ActualizarProducto(Producto oProducto)
        {
            try
            {
                return _ProductoRepository.ActualizarProducto(oProducto);
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
