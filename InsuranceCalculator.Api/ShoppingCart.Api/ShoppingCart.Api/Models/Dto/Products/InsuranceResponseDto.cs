using System.Text.Json.Serialization;

namespace ShoppingCart.Api.Models.Dto.Products
{
   public class InsuranceResponseDto
   {
      public int ProductId { get; set; }
      public float InsuranceValue { get; set; }
      [JsonIgnore]
      public string ProductTypeName { get; set; }
      [JsonIgnore]
      public bool ProductTypeHasInsurance { get; set; }
      [JsonIgnore]
      public float SalesPrice { get; set; }
   }
}