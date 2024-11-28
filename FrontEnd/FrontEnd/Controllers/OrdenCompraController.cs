using FrontEnd.Filter;
using FrontEnd.Models;
using FrontEnd.Servicio;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace FrontEnd.Controllers
{
   [TypeFilter(typeof(TokenAuthorizationFilter))]
    [ApiController]
    [Route("[controller]")]
    public class OrdenCompraController : Controller
    {
        private readonly OrdenCompraService _OrdenCompraService;
        private readonly ProveedorService _ProveedorService;
        private string _token;

        public OrdenCompraController(OrdenCompraService OrdenCompraService, ProveedorService ProveedorService)
        {
            _ProveedorService = ProveedorService;
            _OrdenCompraService = OrdenCompraService;
            
            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var proveedor = await _ProveedorService.GetProveedorsAsync(_token);
            ViewBag.proveedor = proveedor;
            var OrdenCompra = await _OrdenCompraService.GetOrdenComprasAsync(_token);
            return View(OrdenCompra);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] OrdenCompra OrdenCompra)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _OrdenCompraService.CreateOrdenCompraAsync(OrdenCompra, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OrdenCompra OrdenCompra)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _OrdenCompraService.UpdateOrdenCompraAsync(OrdenCompra, _token);
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
            var result = await _OrdenCompraService.DeleteOrdenCompraAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
