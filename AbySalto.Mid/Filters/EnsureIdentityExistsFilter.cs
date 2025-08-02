
using AbySalto.Mid.Application.User;
using AbySalto.Mid.Domain.Auth;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AbySalto.Mid.WebApi.Filters
{
    public class EnsureIdentityExistsFilter(IIdentity identity, IUserRegistrationService userRegistrationService) : IAsyncActionFilter
    {
        private readonly IIdentity _identity = identity;
        private readonly IUserRegistrationService _userRegistrationService = userRegistrationService;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_identity.IsAuthenticated == false)
            {
                await next();
                return;
            }

            var appUserId = await _userRegistrationService.EnsureUserExistsAsync(_identity.IdentityId);
            _identity.AppUserId = appUserId;
            await next();
        }
    }

}