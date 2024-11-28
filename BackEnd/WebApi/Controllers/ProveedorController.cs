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

        [HttpGet("ObtenerProveedorTodos")]
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
        [HttpDelete("EliminarProveedor/{nIdProveedor}")]
        public IActionResult EliminarProveedor(Int32 nIdProveedor)
        {
            Proveedor proveedor = new Proveedor() { nIdProveedor = nIdProveedor };
            var id = _ProveedorDomain.EliminarProveedor(proveedor);
            return Ok(id);
        }
    }
}



