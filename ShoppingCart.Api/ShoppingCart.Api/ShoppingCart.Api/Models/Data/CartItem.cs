﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Models.Data
{
    public class CartItem
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int CatalogItemId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal InsuranceValue { get; set; }

        [NotMapped]
        public string Name { get; set; }
    }
}
