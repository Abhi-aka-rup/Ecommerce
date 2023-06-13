using AutoMapper;
using Common.Mappings;
using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.ShoppingCart.Queries.GetShoppingCartDetail
{
    public class ShoppingCartVm : IMapFrom<CartDetails>
    {
        public int Count { get; set; }

        public Product Product { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartDetails, ShoppingCartVm>();
        }
    }
}
