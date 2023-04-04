using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Products.Queries.GetProductList
{
    public class ProductDto : IMapFrom<Product>
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
