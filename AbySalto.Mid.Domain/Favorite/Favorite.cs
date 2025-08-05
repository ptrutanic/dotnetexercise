namespace AbySalto.Mid.Domain.Favorite
{
    public class Favorite : BaseEntity
    {
        protected Favorite() { }

        public Favorite(int userId, int productId)
        {
            UserId = userId;
            ExternalProductId = productId;
        }

        public int UserId { get; private set; }
        public int ExternalProductId { get; private set; }

        public virtual User.User User { get; private set; } = null!;
    }
}
