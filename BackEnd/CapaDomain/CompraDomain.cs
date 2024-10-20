using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class CompraDomain
    {
        private readonly CompraRepository _CompraRepository;

        public CompraDomain(CompraRepository CompraRepository)
        {
           
                _CompraRepository = CompraRepository;     
        }

        public IEnumerable<Compra> ObtenerCompraTodos()
        {
            try
            {
                return _CompraRepository.ObtenerCompraTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarCompra(Compra oCompra)
        {
            try
            {
                return _CompraRepository.InsertarCompra(oCompra);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public int ActualizarCompra(Compra oCompra)
        {
            try
            {
                return _CompraRepository.InsertarCompra(oCompra);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int EliminarCompra(Compra oCompra)
        {
            try
            {
                return _CompraRepository.InsertarCompra(oCompra);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
