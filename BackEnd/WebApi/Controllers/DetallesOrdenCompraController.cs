using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetallesOrdenCompraController : ControllerBase
    {
        private readonly DetallesOrdenCompraDomain _DetallesOrdenCompraDomain;

        public DetallesOrdenCompraController(DetallesOrdenCompraDomain DetallesOrdenCompraDomain)
        {
            _DetallesOrdenCompraDomain = DetallesOrdenCompraDomain;
        }

        [HttpGet("ObtenerDetallesOrdenCompraTodos")]
        public IActionResult ObtenerDetallesOrdenCompra()
        {
            var DetallesOrdenCompras = _DetallesOrdenCompraDomain.ObtenerDetallesOrdenCompraTodos();
            return Ok(DetallesOrdenCompras);
        }

        [HttpPost("InsertarDetallesOrdenCompra")]
        public IActionResult InsertarDetallesOrdenCompra(DetallesOrdenCompra oDetallesOrdenCompra)
        {
            var id = _DetallesOrdenCompraDomain.InsertarDetalleOrdenCompra(oDetallesOrdenCompra);
            return Ok(id);
        }

        [HttpPut("ActualizarDetallesOrdenCompra")]
        public IActionResult ActualizarDetalleDetallesOrdenCompra(DetallesOrdenCompra oDetallesOrdenCompra)
        {
            var id = _DetallesOrdenCompraDomain.ActualizarDetalleOrdenCompra(oDetallesOrdenCompra);
            return Ok(id);
        }

        [HttpDelete("EliminarDetallesOrdenCompra")]
        public IActionResult EliminarDetalleDetallesOrdenCompra(DetallesOrdenCompra oDetallesOrdenCompra)
        {
            var id = _DetallesOrdenCompraDomain.EliminarDetalleOrdenCompra(oDetallesOrdenCompra);
            return Ok(id);
        }

    }
}
