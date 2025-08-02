
using System.Security.Claims;
using AbySalto.Mid.Domain.Auth;
using Microsoft.AspNetCore.Http;

namespace AbySalto.Mid.Infrastructure.Auth
{
    public class Identity(IHttpContextAccessor httpContext) : IIdentity
    {
        private readonly IHttpContextAccessor _httpContext = httpContext;

        public string UserId =>
            _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        public bool IsAuthenticated =>
            _httpContext.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}