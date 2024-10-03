using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class DetallesOrdenCompraDomain
    {
        private readonly DetallesOrdenCompraRepository _DetallesOrdenCompraRepository;

        public DetallesOrdenCompraDomain(DetallesOrdenCompraRepository DetallesOrdenCompraRepository)
        {
           
                _DetallesOrdenCompraRepository = DetallesOrdenCompraRepository;     
        }

        public IEnumerable<DetallesOrdenCompra> ObtenerDetallesOrdenCompraTodos()
        {
            try
            {
                return _DetallesOrdenCompraRepository.ObtenerDetallesOrdenCompraTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarDetalleOrdenCompra(DetallesOrdenCompra oDetallesOrdenCompra)
        {
            try
            {
                return _DetallesOrdenCompraRepository.InsertarDetalleOrdenCompra(oDetallesOrdenCompra);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int ActualizarDetalleOrdenCompra(DetallesOrdenCompra oDetallesOrdenCompra)
        {
            try
            {
                return _DetallesOrdenCompraRepository.ActualizarDetalleOrdenCompra(oDetallesOrdenCompra);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int EliminarDetalleOrdenCompra(DetallesOrdenCompra oDetallesOrdenCompra)
        {
            try
            {
                return _DetallesOrdenCompraRepository.EliminarDetalleOrdenCompra(oDetallesOrdenCompra);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
