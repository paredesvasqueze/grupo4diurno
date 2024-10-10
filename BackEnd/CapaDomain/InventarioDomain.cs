using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;

namespace CapaDomain
{
    public class InventarioDomain
    {
        private readonly InventarioRepository _InventarioRepository;

        public InventarioDomain(InventarioRepository InventarioRepository)
        {
            _InventarioRepository = InventarioRepository;
        }

        public IEnumerable<Inventario> SeleccionarInventarios()
        {
            try
            {
                return _InventarioRepository.SeleccionarInventarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las órdenes de compra", ex);
            }
        }

        public int InsertarInventario(Inventario Inventario)
        {
            try
            {
                return _InventarioRepository.InsertarInventario(Inventario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la orden de compra", ex);
            }
        }

        public int ActualizarInventario(Inventario Inventario)
        {
            try
            {
                return _InventarioRepository.ActualizarInventario(Inventario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la orden de compra", ex);
            }
        }

        public int EliminarInventario(int idInventario)
        {
            try
            {
                return _InventarioRepository.EliminarInventario(idInventario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la orden de compra", ex);
            }
        }
    }
}