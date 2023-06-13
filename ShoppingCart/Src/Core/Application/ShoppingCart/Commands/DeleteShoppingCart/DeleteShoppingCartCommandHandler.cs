using Common.Exceptions;
using MediatR;
using ShoppingCartAPI.Application.Common.Interfaces;
using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.ShoppingCart.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand, Unit>
    {
        private readonly IShoppingCartDbContext _context;

        public DeleteShoppingCartCommandHandler(IShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CartDetails.FindAsync(request.CartDetailsId) ??
                throw new NotFoundException(nameof(CartDetails), request.CartDetailsId);

            _context.CartDetails.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
