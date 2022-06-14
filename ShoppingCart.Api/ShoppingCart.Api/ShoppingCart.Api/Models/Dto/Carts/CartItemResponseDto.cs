namespace InsuranceCalculator.Api.Models.Dto.Carts
{
    public class CartItemResponseDto
    {
        public int ProductId { get; set; }
        public string ProductTypeName { get; set; }
        public int Quantity { get; set; }
        public decimal SalesPrice { get; set; }
        public bool ProductTypeHasInsurance { get; set; }
        public decimal InsuranceValue { get; set; }
        public decimal SubTotal => Quantity * SalesPrice;
        public decimal InsuranceSubTotal => Quantity * InsuranceValue;
        public decimal InsuranceTotal { get; set; }
    }
}
