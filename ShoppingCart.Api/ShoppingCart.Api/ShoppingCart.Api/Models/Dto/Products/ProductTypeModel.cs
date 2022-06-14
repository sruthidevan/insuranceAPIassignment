using System.Text.Json.Serialization;

namespace InsuranceCalculator.Api.Models.Dto.Products
{
    public class ProductTypeModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("canBeInsured")]
        public bool CanBeInsured { get; set; }
    }
}
