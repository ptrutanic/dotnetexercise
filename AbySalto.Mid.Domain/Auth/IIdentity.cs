namespace AbySalto.Mid.Domain.Auth
{
    public interface IIdentity
    {
        string IdentityProviderId { get; }
        bool IsAuthenticated { get; }
        int AppUserId { get; set; }
    }
}
