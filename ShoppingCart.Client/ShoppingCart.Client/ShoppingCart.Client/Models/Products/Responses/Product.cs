using System;

namespace ShoppingCart.Client.Models.Products.Responses
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
