using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FrontEnd.Filter
{
    public class TokenAuthorizationFilter : IActionFilter
    {
        private readonly ILogger<TokenAuthorizationFilter> _logger;

        public TokenAuthorizationFilter(ILogger<TokenAuthorizationFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Obtener el token de la sesión
            var token = context.HttpContext.Request.Cookies["AuthToken"];
            //var token = context.HttpContext.Session.GetString("AuthToken");

            // Verificar si el token está presente y es válido
            if (string.IsNullOrEmpty(token) || !EsTokenValido(token))
            {
                _logger.LogWarning("Acceso denegado. Token no válido o no presente.");

                // Redirigir al inicio de sesión si el token es inválido
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Este método se puede dejar vacío si no se necesita realizar ninguna acción después de la ejecución
        }

        private bool EsTokenValido(string token)
        {
            // Aquí puedes agregar la lógica para verificar si el token es válido
            // Por ejemplo, puedes verificar la expiración del token o decodificarlo si es un JWT.
            return true; // Suponiendo que el token siempre es válido por simplicidad
        }
    }
}
