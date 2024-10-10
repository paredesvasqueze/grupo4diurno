using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaDomain _CategoriaDomain;

        public CategoriaController(CategoriaDomain CategoriaDomain)
        {
            _CategoriaDomain = CategoriaDomain;
        }

        [HttpGet("ObtenerCategoriaTodos")]
        public IActionResult ObtenerCategoriaTodos()
        {
            var Categorias = _CategoriaDomain.ObtenerCategoriaTodos();
            return Ok(Categorias);
        }

        [HttpPost("InsertarCategoria")]
        public IActionResult InsertarCategoria(Categoria oCategoria)
        {
            var id = _CategoriaDomain.InsertarCategoria(oCategoria);
            return Ok(id);
        }

        [HttpPut("ActualizarCategoria")]
        public IActionResult ActualizarCategoria(Categoria oCategoria)
        {
            var id = _CategoriaDomain.ActualizarCategoria(oCategoria);
            return Ok(id);
        }
        [HttpDelete("EliminarCategoria")]
        public IActionResult EliminarCategoria(Categoria oCategoria)
        {
            var id = _CategoriaDomain.EliminarCategoria(oCategoria);
            return Ok(id);
        }
        [HttpPost("SeleccionarCategoria")]
        public IActionResult SeleccionarCategoria(Categoria oCategoria)
        {
            var id = _CategoriaDomain.SeleccionarCategoria(oCategoria);
            return Ok(id);
        }


    }
}



