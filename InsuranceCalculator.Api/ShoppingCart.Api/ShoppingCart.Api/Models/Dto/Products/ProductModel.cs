using System.Text.Json.Serialization;

namespace ShoppingCart.Api.Models.Dto.Products
{
    public class ProductModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("salesPrice")]
        public decimal SalesPrice { get; set; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonIgnore]
        public string ProductTypeName { get; set; }

        [JsonIgnore]
        public bool ProductTypeHasInsurance { get; set; }
    }
}
