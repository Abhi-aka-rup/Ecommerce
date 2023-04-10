using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Domain.Models
{
    public class Cart
    {
        public Cart()
        {
            CartDetails = new HashSet<CartDetails>();
        }

        public CartHeader CartHeader { get; set; }

        public ICollection<CartDetails> CartDetails { get; set; }
    }
}
