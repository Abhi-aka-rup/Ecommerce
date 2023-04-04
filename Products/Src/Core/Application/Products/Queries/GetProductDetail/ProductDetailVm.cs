using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Products.Queries.GetProductDetail
{
    public class ProductDetailVm : IMapFrom<Product>
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int Price { get; set; }

        public string? Description { get; set; }

        public string? CategoryName { get; set; }

        public string? ImageUrl { get; set; }
    }
}
