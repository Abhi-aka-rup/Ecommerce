using Products.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Products.Application.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductsListVm>
    {
        private readonly IProductDbContext _context;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IProductDbContext productDbContext, IMapper mapper)
        {
            _context = productDbContext;
            _mapper = mapper;
        }

        public async Task<ProductsListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.ProductName)
                .ToListAsync(cancellationToken);

            var vm = new ProductsListVm()
            {
                Products = products
            };

            return vm;
        }
    }
}
