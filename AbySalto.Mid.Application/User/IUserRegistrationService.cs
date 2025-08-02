namespace AbySalto.Mid.Application.User
{
    public interface IUserRegistrationService
    {
        Task<int> EnsureUserExistsAsync(string identityProviderId);
    }
}