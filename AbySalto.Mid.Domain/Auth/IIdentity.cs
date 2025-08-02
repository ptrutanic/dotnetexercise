namespace AbySalto.Mid.Domain.Auth
{
    public interface IIdentity
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}
