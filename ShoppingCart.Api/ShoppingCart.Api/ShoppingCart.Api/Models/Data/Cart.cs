using System;
using System.Collections.Generic;

namespace InsuranceCalculator.Api.Models.Data
{
    public sealed class Cart : Entity
    {
        public List<CartItem> Products { get; set; } = new List<CartItem>();

        public Cart()
        {
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        
    }
}
