using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly CompraDomain _CompraDomain;

        public CompraController(CompraDomain CompraDomain)
        {
            _CompraDomain = CompraDomain;
        }

        [HttpGet("ObtenerCompraTodos")]
        public IActionResult ObtenerCompraTodos()
        {
            var Compras = _CompraDomain.ObtenerCompraTodos();
            return Ok(Compras);
        }

        [HttpPost("InsertarCompra")]
        public IActionResult InsertarCompra(Compra oCompra)
        {
            var id = _CompraDomain.InsertarCompra(oCompra);
            return Ok(id);
        }

        [HttpPut("ActualizarCompra")]
        public IActionResult ActualizarCompra(Compra oCompra)
        {
            var id = _CompraDomain.ActualizarCompra(oCompra);
            return Ok(id);
        }
        [HttpDelete("EliminarCompra")]
        public IActionResult EliminarCompra(Compra oCompra)
        {
            var id = _CompraDomain.EliminarCompra(oCompra);
            return Ok(id);
        }
    }
}



