namespace InsuranceCalculator.Api.Models.Data
{
   public sealed class Product : Entity
   {
      //public int Id { get; set; }
      public string ProductTypeName { get; set; }
      public string NamePlural { get; set; }
      public decimal SalesPrice { get; set; }
      public decimal SurchargeRate { get; set; }
   }
}