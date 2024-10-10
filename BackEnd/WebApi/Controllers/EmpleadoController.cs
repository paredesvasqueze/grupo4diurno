using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoDomain _EmpleadoDomain;

        public EmpleadoController(EmpleadoDomain EmpleadoDomain)
        {
            _EmpleadoDomain = EmpleadoDomain;
        }

        [HttpGet("ObtenerEmpleadoTodos")]
        public IActionResult ObtenerEmpleadoTodos()
        {
            var Empleados = _EmpleadoDomain.ObtenerEmpleadoTodos();
            return Ok(Empleados);
        }

        [HttpPost("InsertarEmpleado")]
        public IActionResult InsertarEmpleado(Empleado cEmpleado)
        {
            var id = _EmpleadoDomain.InsertarEmpleado(cEmpleado);
            return Ok(id);
        }

        [HttpPut("ActualizarEmpleado")]
        public IActionResult ActualizarEmpleado(Empleado cEmpleado)
        {
            var id = _EmpleadoDomain.ActualizarEmpleado(cEmpleado);
            return Ok(id);
        }
        [HttpDelete("EliminarEmpleado")]
        public IActionResult EliminarEmpleado(Empleado cEmpleado)
        {
            var id = _EmpleadoDomain.EliminarEmpleado(cEmpleado);
            return Ok(id);
        }
        [HttpPost("SeleccionarEmpleado")]
        public IActionResult SeleccionarEmpleado(Empleado cEmpleado)
        {
            var id = _EmpleadoDomain.SeleccionarEmpleado(cEmpleado);
            return Ok(id);
        }


    }
}



