﻿using Common.Domain;

namespace ShoppingCartAPI.Domain.Entities
{
    public class CartDetails : AuditableEntity
    {
        public int CartDetailsId { get; set; }

        public int CartHeaderId { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public CartHeader CartHeader { get; set; }

        public Product Product { get; set; }
    }
}
