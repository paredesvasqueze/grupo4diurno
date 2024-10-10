using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly CompraController _CompraController;

        public CompraController(CompraController CompraController)
        {
            _CompraController = CompraController;
        }

        [HttpGet("ObtenerCompraTodos")]
        public IActionResult ObtenerCompraTodos()
        {
            var Compras = _CompraController.ObtenerCompraTodos();
            return Ok(Compras);
        }

        [HttpPost("InsertarCompra")]
        public IActionResult InsertarCompra(Compra oCompra)
        {
            var id = _CompraController.InsertarCompra(oCompra);
            return Ok(id);
        }
    }
}