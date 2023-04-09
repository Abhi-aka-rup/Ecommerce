using Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Products.Queries.GetProductList
{
    public class ProductDto : IMapFrom<Product>
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>();
        }
    }
}
