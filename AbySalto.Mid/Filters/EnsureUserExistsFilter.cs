
using AbySalto.Mid.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AbySalto.Mid.WebApi.Filters
{
    public class EnsureUserExistsFilter(IIdentity identity) : IAsyncActionFilter
    {
        private readonly IIdentity _identity = identity;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_identity.IsAuthenticated == false)
            {
                await next();
                return;
            }

            var userId = _identity.UserId;

            await next();
        }
    }

}