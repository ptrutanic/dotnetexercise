
using AbySalto.Mid.Domain.Auth;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AbySalto.Mid.WebApi.Filters
{
    public class EnsureIdentityExistsFilter(IIdentity identity) : IAsyncActionFilter
    {
        private readonly IIdentity _identity = identity;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_identity.IsAuthenticated == false)
            {
                await next();
                return;
            }

            var IdentityId = _identity.IdentityId;

            await next();
        }
    }

}