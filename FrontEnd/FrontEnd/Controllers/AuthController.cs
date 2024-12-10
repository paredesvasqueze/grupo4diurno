using FrontEnd.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class AuthController : Controller
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            var token = HttpContext.Request.Cookies["AuthToken"];

            // Verificar si el token está presente y no está vacío
            if (!string.IsNullOrEmpty(token))
            {
                // Redirigir al Dashboard si el token existe
                return RedirectToAction("Index", "Dashboard");
            }

            // Si el token no existe, mostrar la vista de login
            return View();


        }  

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _tokenService.GetTokenAsync(username, password);

            if (!string.IsNullOrEmpty(token))
            {
                CookieOptions cookieOptions = new CookieOptions
                {
                    HttpOnly = true,       // Mayor seguridad
                    Secure = true,         // Solo para HTTPS en producción
                    SameSite = SameSiteMode.Strict, // Protección contra CSRF
                    Expires = DateTime.Now.AddMinutes(30) // La cookie expira en 20 minutos
                };

                // Agregar la cookie con el token y las opciones configuradas
                HttpContext.Response.Cookies.Append("AuthToken", token, cookieOptions);

                // Guardar el token en la cookie o en sesión
                //HttpContext.Response.Cookies.Append("AuthToken", token);
                return RedirectToAction("Index", "DashBoard");
            }

            ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            return View();
        }
    }
}
