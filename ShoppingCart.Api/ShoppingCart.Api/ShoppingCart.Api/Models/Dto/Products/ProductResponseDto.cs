using System;
using Newtonsoft.Json;
using ShoppingCart.Api.Models.Dto.Common;

namespace ShoppingCart.Api.Models.Dto.Products
{
    public sealed class ProductResponseDto : Resource
    {
        public int ProductId { get; set; }
        [JsonIgnore]
        public string ProductTypeName { get; set; }
        [JsonIgnore]
        public decimal SalesPrice { get; set; }

        public float InsuranceValue { get; set; }
        [JsonIgnore]
        public bool ProductTypeHasInsurance { get; set; }

   }
}
