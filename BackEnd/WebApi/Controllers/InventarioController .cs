using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly InventarioDomain _InventarioDomain;

        public InventarioController(InventarioDomain InventarioDomain)
        {
            _InventarioDomain = InventarioDomain;
        }

        [HttpGet("SeleccionarInventarios")]
        public IActionResult SeleccionarInventarios()
        {
            var Inventario = _InventarioDomain.SeleccionarInventarios();
            return Ok(Inventario);
        }

        [HttpPost("InsertarInventario")]
        public IActionResult InsertarInventario(Inventario oInventario)
        {
            var id = _InventarioDomain.InsertarInventario(oInventario);
            return Ok(id);
        }

        [HttpPut("ActualizarInventario")]
        public IActionResult ActualizarInventario(Inventario oInventario)
        {
            var resultado = _InventarioDomain.ActualizarInventario(oInventario);
            return Ok(resultado);
        }

        [HttpDelete("EliminarInventario")]
        public IActionResult EliminarInventario(int id)
        {
            var resultado = _InventarioDomain.EliminarInventario(id);
            return Ok(resultado);
        }
    }
}
