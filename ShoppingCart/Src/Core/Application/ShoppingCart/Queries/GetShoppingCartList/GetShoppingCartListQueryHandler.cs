using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.MessageBus;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Application.Common.Interfaces;

namespace Application.ShoppingCart.Queries.GetShoppingCartList
{
    public class GetShoppingCartListQueryHandler : IRequestHandler<GetShoppingCartListQuery, ShoppingCartListVm>
    {
        private readonly IShoppingCartDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMessageBus _messageBus;

        public GetShoppingCartListQueryHandler(IShoppingCartDbContext context, IMapper mapper, IMessageBus messageBus)
        {
            _context = context;
            _mapper = mapper;
            _messageBus = messageBus;
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
            await _messageBus.PublishMessage(vm, "checkoutmessagetopic");
            return vm;
        }
    }
}
