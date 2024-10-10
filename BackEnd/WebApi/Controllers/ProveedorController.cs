using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorDomain _ProveedorDomain;

        public ProveedorController(ProveedorDomain ProveedorDomain)
        {
            _ProveedorDomain = ProveedorDomain;
        }

        [HttpGet("ObtenerProveedorTodos(")]
        public IActionResult ObtenerProveedorTodos()
        {
            var Proveedors = _ProveedorDomain.ObtenerProveedorTodos();
            return Ok(Proveedors);
        }

        [HttpPost("InsertarProveedor")]
        public IActionResult InsertarProveedor(Proveedor oProveedor)
        {
            var id = _ProveedorDomain.InsertarProveedor(oProveedor);
            return Ok(id);
        }

        [HttpPut("ActualizarProveedor")]
        public IActionResult ActualizarProveedor(Proveedor oProveedor)
        {
            var id = _ProveedorDomain.ActualizarProveedor(oProveedor);
            return Ok(id);
        }
        [HttpDelete("EliminarProveedor")]
        public IActionResult EliminarProveedor(Proveedor oProveedor)
        {
            var id = _ProveedorDomain.EliminarProveedor(oProveedor);
            return Ok(id);
        }
    }
}



