using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
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

        [HttpGet("GetProductoId/{nIdProducto}")]
        public IActionResult GetProductoId(int nIdProducto)
        {
            var ordenesCompra = _ProductoDomain.GetProductoId(nIdProducto);
            return Ok(ordenesCompra);
        }

        [HttpPost("InsertarProducto")]
        public IActionResult InsertarProducto(Producto oProducto)
        {
            oProducto.nIdProveedor = 1;
            var id = _ProductoDomain.InsertarProducto(oProducto);
            return Ok(id);
        }

        [HttpPut("ActualizarProducto")]
        public IActionResult ActualizarProducto(Producto oProducto)
        {
            oProducto.nIdProveedor = 1;
            var resultado = _ProductoDomain.ActualizarProducto(oProducto);
            return Ok(resultado);
        }

        [HttpDelete("EliminarProducto/{nIdProducto}")]
        public IActionResult EliminarProducto(int nIdProducto)
        {
            Producto oProducto = new Producto() { nIdProducto = nIdProducto };
            var id = _ProductoDomain.EliminarProducto(oProducto);
            return Ok(id);
        }
    }
}
