using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;
namespace WebApi.Controllers
{
    [Authorize]
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

        [HttpDelete("EliminarCategoria/{nIdCategoria}")]
        public IActionResult EliminarCategoria(Int32 nIdCategoria)
        {
            Categoria categoria = new Categoria() { nIdCategoria = nIdCategoria };
            var id = _CategoriaDomain.EliminarCategoria(categoria);
            return Ok(id);
        }
    }
}



