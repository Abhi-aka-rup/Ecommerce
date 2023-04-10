using Common.Exceptions;
using ProductsAPI.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductsAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IProductDbContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IProductDbContext productDbContext, IMapper mapper)
        {
            _context = productDbContext;
            _mapper = mapper;
        }

        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Products
                .ProjectTo<ProductDetailVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.ProductId == request.ProductId, cancellationToken) ??
                throw new NotFoundException(nameof(Product), request.ProductId);

            return vm;
        }
    }
}
