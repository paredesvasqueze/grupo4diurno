using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdenCompraController : ControllerBase
    {
        private readonly OrdenCompraDomain _ordenCompraDomain;

        public OrdenCompraController(OrdenCompraDomain ordenCompraDomain)
        {
            _ordenCompraDomain = ordenCompraDomain;
        }

        [HttpGet("SeleccionarOrdenesCompra")]
        public IActionResult SeleccionarOrdenesCompra()
        {
            var ordenesCompra = _ordenCompraDomain.SeleccionarOrdenesCompra();
            return Ok(ordenesCompra);
        }


        [HttpPost("InsertarOrdenCompra")]
        public IActionResult InsertarOrdenCompra(OrdenCompra oOrdenCompra)
        {
            var id = _ordenCompraDomain.InsertarOrdenCompra(oOrdenCompra);
            return Ok(id);
        }

        [HttpPut("ActualizarOrdenCompra")]
        public IActionResult ActualizarOrdenCompra(OrdenCompra oOrdenCompra)
        {
            var resultado = _ordenCompraDomain.ActualizarOrdenCompra(oOrdenCompra);
            return Ok(resultado);
        }

        [HttpDelete("EliminarOrdenCompra/{nIdOrdenCompra}")]
        public IActionResult EliminarOrdenCompra(int nIdOrdenCompra)
        {
            OrdenCompra oOrdenCompra = new OrdenCompra() { nIdOrdenCompra = nIdOrdenCompra };
            var id = _ordenCompraDomain.EliminarOrdenCompra(nIdOrdenCompra);
            return Ok(id);
        }
    }
}
