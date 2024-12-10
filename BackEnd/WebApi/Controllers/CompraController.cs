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

        [HttpGet("GetCompraId/{nIdCompra}")]
        public IActionResult GetCompraId(int nIdCompra)
        {
            var oCompra = _CompraDomain.GetCompraId(nIdCompra);
            return Ok(oCompra);
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
        [HttpDelete("EliminarCompra/{nIdCompra}")]
        public IActionResult EliminarCompra(Int32 nIdCompra)
        {
            Compra compra = new Compra() { nIdCompra = nIdCompra };
            var id = _CompraDomain.EliminarCompra(compra);
            return Ok(id);
        }
    }
}



