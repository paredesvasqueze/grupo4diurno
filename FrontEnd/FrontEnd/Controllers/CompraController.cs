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
    public class CompraController : Controller
    {
        private readonly CompraService _CompraService;
        private readonly EmpleadoService _EmpleadoService;
        private string _token;

        public CompraController(CompraService CompraService, EmpleadoService empleadoService)
        {
            _EmpleadoService = empleadoService;
            _CompraService = CompraService;
            
            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var empleado = await _EmpleadoService.GetEmpleadosAsync(_token);
            ViewBag.Empleado = empleado;
            var Compra = await _CompraService.GetComprasAsync(_token);
            return View(Compra);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Compra Compra)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _CompraService.CreateCompraAsync(Compra, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Compra Compra)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _CompraService.UpdateCompraAsync(Compra, _token);
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
            var result = await _CompraService.DeleteCompraAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
