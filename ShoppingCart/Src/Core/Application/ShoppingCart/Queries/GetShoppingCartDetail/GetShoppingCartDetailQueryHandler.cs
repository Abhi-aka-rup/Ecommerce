using AutoMapper;
using Common.Exceptions;
using MediatR;
using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.ShoppingCart.Queries.GetShoppingCartDetail
{
    public class GetShoppingCartDetailQueryHandler : IRequestHandler<GetShoppingCartDetailQuery, ShoppingCartVm>
    {
        private readonly IShoppingCartDbContext _context;
        private readonly IMapper _mapper;

        public GetShoppingCartDetailQueryHandler(IShoppingCartDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShoppingCartVm> Handle(GetShoppingCartDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.CartDetails
                .FindAsync(request.CartDetailsId, cancellationToken) ??
                throw new NotFoundException(nameof(CartDetails), request.CartDetailsId);

            return _mapper.Map<ShoppingCartVm>(vm);
        }
    }
}
