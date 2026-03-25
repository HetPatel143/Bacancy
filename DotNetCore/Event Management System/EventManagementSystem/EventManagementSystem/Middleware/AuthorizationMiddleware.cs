using System.Security.Claims;

namespace EventManagementSystem.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var user = context.User;

            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                
                    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var role = context.User.FindFirst(ClaimTypes.Role)?.Value;

                    Console.WriteLine($"User: {userId}, Role: {role}");
                
            }

            await _next(context);
        }
    }
}
