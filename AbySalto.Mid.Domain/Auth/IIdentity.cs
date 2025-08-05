namespace AbySalto.Mid.Domain.Auth
{
    public interface IIdentity
    {
        string IdentityId { get; }
        bool IsAuthenticated { get; }
        int AppUserId { get; set; }
    }
}
