﻿using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Domain.Entities;

namespace ShoppingCartAPI.Application.Common.Interfaces
{
    public interface IShoppingCartDbContext
    {
        public DbSet<CartDetails> CartDetails { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
