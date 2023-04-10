using Common.Domain;

namespace ShoppingCartAPI.Domain.Entities
{
    public class CartHeader : AuditableEntity
    {
        public int CartHeaderId { get; set; }

        public string UserId { get; set; }

        public string CouponCode { get; set; }
    }
}
