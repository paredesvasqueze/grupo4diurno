using FrontEnd.Filter;
using FrontEnd.Models;
using FrontEnd.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [TypeFilter(typeof(TokenAuthorizationFilter))]
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {

        private readonly ProductoService _ProductoService;
        private readonly CategoriaService _CategoriaService;
        private readonly ProveedorService _ProveedorService;

        private string _token;

        public ProductoController(CategoriaService categoriaService, ProductoService productoService, ProveedorService proveedorService)
        {
            _CategoriaService = categoriaService;
            _ProductoService = productoService;
            _ProveedorService = proveedorService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var categorias = await _CategoriaService.GetCategoriasAsync(_token);            
            ViewBag.Categorias = categorias;
            var proveedor = await _ProveedorService.GetProveedorsAsync(_token);
            ViewBag.Proveedor = proveedor; 
        var productos = await _ProductoService.GetProductosAsync(_token);
            return View(productos);        
        }

        [HttpGet("GetProductoById/{nIdProducto}")]
        public async Task<IActionResult> GetProductoById(Int32 nIdProducto)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];           
            var producto = await _ProductoService.GetProductoAsync(nIdProducto,_token);
            return Ok(producto);
            //return View(productos);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _ProductoService.CreateProductoAsync(producto, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Producto producto)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _ProductoService.UpdateProductoAsync(producto, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var result = await _ProductoService.DeleteProductoAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
