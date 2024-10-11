using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoDomain _ProductoDomain;

        public ProductoController(ProductoDomain ProductoDomain)
        {
            _ProductoDomain = ProductoDomain;
        }

        [HttpGet("ObtenerProductoTodos")]
        public IActionResult ObtenerProductoTodos()
        {
            var ordenesCompra = _ProductoDomain.ObtenerProductoTodos();
            return Ok(ordenesCompra);
        }

        [HttpPost("InsertarProducto")]
        public IActionResult InsertarProducto(Producto oProducto)
        {
            var id = _ProductoDomain.InsertarProducto(oProducto);
            return Ok(id);
        }

        [HttpPut("ActualizarProducto")]
        public IActionResult ActualizarProducto(Producto oProducto)
        {
            var resultado = _ProductoDomain.InsertarProducto(oProducto);
            return Ok(resultado);
        }

        [HttpDelete("EliminarProducto")]
        public IActionResult EliminarProducto(Producto oProducto)
        {
            var id = _ProductoDomain.EliminarProducto(oProducto);
            return Ok(id);
        }
    }
}
