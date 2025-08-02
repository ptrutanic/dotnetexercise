using AbySalto.Mid.Domain.Entities;

namespace AbySalto.Mid.Domain.User
{
    public class User(string identityProviderId) : BaseEntity
    {
        public string IdentityProviderId { get; private set; } = identityProviderId;
    }
}
