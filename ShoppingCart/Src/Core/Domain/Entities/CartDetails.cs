using Common.Domain;

namespace ShoppingCartAPI.Domain.Entities
{
    public class CartDetails : AuditableEntity
    {
        public int CartDetailsId { get; set; }

        public int Count { get; set; }

        public Product Product { get; set; }
    }
}
