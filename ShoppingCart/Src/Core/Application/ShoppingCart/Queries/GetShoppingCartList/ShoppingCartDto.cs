using AutoMapper;
using Common.Mappings;
using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.ShoppingCart.Queries.GetShoppingCartList
{
    public class ShoppingCartDto : IMapFrom<CartDetails>
    {
        public int Count { get; set; }

        public int ProductId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartDetails, ShoppingCartDto>();
        }
    }
}
