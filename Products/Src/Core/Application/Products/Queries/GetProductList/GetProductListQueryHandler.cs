using ProductsAPI.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ecommerce.MessageBus;

namespace ProductsAPI.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductsListVm>
    {
        private readonly IProductDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMessageBus _messageBus;

        public GetProductListQueryHandler(IProductDbContext productDbContext, IMapper mapper, IMessageBus messageBus)
        {
            _context = productDbContext;
            _mapper = mapper;
            _messageBus = messageBus;
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

            await _messageBus.PublishMessage(vm, "checkoutmessagetopic");
            return vm;
        }
    }
}
