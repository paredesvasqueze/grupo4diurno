using Microsoft.AspNetCore.Mvc;
//using CapaDomain;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        
        [HttpGet]
        public string Get()
        {
            return "Proyecto Seguridad";
        }
    }
}
