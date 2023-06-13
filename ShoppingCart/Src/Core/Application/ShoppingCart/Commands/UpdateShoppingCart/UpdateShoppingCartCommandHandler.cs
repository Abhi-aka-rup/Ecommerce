using Common.Exceptions;
using MediatR;
using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.ShoppingCart.Commands.UpdateShoppingCart
{
    public class UpdateShoppingCartCommandHandler : IRequestHandler<UpdateShoppingCartCommand, Unit>
    {
        private readonly IShoppingCartDbContext _context;

        public UpdateShoppingCartCommandHandler(IShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CartDetails.FindAsync(request.CartDetailsId) ??
                throw new NotFoundException(nameof(CartDetails), request.CartDetailsId);

            entity.Count = request.Count;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
