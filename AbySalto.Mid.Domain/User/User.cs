namespace AbySalto.Mid.Domain.User
{
    public class User(string identityProviderId) : BaseEntity
    {
        public string IdentityProviderId { get; private set; } = identityProviderId;

        public virtual ICollection<Favorite.Favorite> Favorites { get; set; } = [];
        public virtual Cart.Cart? Cart { get; set; }
    }
}
