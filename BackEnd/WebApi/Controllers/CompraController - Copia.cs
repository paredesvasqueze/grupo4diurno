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

        [HttpGet("ObtenerAlumnoTodos")]
        public IActionResult ObtenerAlumnoTodos()
        {
            var alumnos = _CompraController.ObtenerAlumnoTodos();
            return Ok(alumnos);
        }

        [HttpPost("InsertarAlumno")]
        public IActionResult InsertarAlumno(Alumno oAlumno)
        {
            var id = _CompraController.InsertarAlumno(oAlumno);
            return Ok(id);
        }
    }
}