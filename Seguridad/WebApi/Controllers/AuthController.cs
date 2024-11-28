using CapaEntidad;
using CapaDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    
    private readonly UsserDomain _UsserDomain;

    public AuthController( UsserDomain userDomain)
    {
      
        _UsserDomain = userDomain;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Usser oUsser)
    {
        var respuesta = _UsserDomain.ValidarUsuario(oUsser);

            if (respuesta.cToken != null && respuesta.cToken != string.Empty) 
            {
                return Ok(respuesta);
            }
        return Unauthorized(respuesta);
    }

    

}


