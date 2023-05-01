using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Application.Common.Interfaces;

namespace Application.ShoppingCart.Queries.GetShoppingCartList
{
    public class GetShoppingCartListQueryHandler : IRequestHandler<GetShoppingCartListQuery, ShoppingCartListVm>
    {
        private readonly IShoppingCartDbContext _context;
        private readonly IMapper _mapper;

        public GetShoppingCartListQueryHandler(IShoppingCartDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShoppingCartListVm> Handle(GetShoppingCartListQuery request, CancellationToken cancellationToken)
        {
            var cartList = await _context.CartDetails
                .ProjectTo<ShoppingCartDto>(_mapper.ConfigurationProvider)
                .OrderBy(cart => cart.Count)
                .ToListAsync();

            var vm = new ShoppingCartListVm()
            {
                CartList = cartList
            };

            return vm;
        }
    }
}
