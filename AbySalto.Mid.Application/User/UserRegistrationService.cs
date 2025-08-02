using AbySalto.Mid.Domain.User;

namespace AbySalto.Mid.Application.User
{
    public class UserRegistrationService(IUserRepository userRepository) : IUserRegistrationService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<int> EnsureUserExistsAsync(string identityProviderId)
        {
            if (string.IsNullOrWhiteSpace(identityProviderId))
                throw new ArgumentNullException(nameof(identityProviderId));

            var user = await _userRepository.FindByIdentityProviderIdAsync(identityProviderId);
            if (user is not null)
            {
                return user.Id;
            }

            user = new Domain.User.User(identityProviderId);
            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
