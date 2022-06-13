using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InsuranceApi.Models.Dto
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