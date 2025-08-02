namespace AbySalto.Mid.Application.User
{
    public interface IUserRegistrationService
    {
        Task EnsureUserExistsAsync(string identityProviderId);
    }
}