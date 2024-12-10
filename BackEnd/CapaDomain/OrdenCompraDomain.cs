using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;

namespace CapaDomain
{
    public class OrdenCompraDomain
    {
        private readonly OrdenCompraRepository _ordenCompraRepository;

        public OrdenCompraDomain(OrdenCompraRepository ordenCompraRepository)
        {
            _ordenCompraRepository = ordenCompraRepository;
        }

        public IEnumerable<OrdenCompra> SeleccionarOrdenesCompra()
        {
            try
            {
                return _ordenCompraRepository.SeleccionarOrdenesCompra();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las órdenes de compra", ex);
            }
        }

        public OrdenCompra GetOrdenCompraId(int nIdOrdenCompra)
        {
            try
            {
                return _ordenCompraRepository.GetOrdenCompraId(nIdOrdenCompra);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int InsertarOrdenCompra(OrdenCompra ordenCompra)
        {
            try
            {
                return _ordenCompraRepository.InsertarOrdenCompra(ordenCompra);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la orden de compra", ex);
            }
        }

        public int ActualizarOrdenCompra(OrdenCompra ordenCompra)
        {
            try
            {
                return _ordenCompraRepository.ActualizarOrdenCompra(ordenCompra);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la orden de compra", ex);
            }
        }

        public int EliminarOrdenCompra(int idOrdenCompra)
        {
            try
            {
                return _ordenCompraRepository.EliminarOrdenCompra(idOrdenCompra);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la orden de compra", ex);
            }
        }
    }
}