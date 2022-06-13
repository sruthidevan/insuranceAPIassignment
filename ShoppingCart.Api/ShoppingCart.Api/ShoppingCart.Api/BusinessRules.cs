using Newtonsoft.Json;
using ShoppingCart.Api.Models.Dto.Carts;
using ShoppingCart.Api.Models.Dto.Products;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InsuranceApi
{
    public static class BusinessRules
    {
        private static readonly string PRODUCT_API = "http://localhost:5002";

        public static async Task<CartItemResponseDto> GetProductAsync(int productId, int quantity)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(PRODUCT_API) };
            // string json = client.GetAsync("/product_types").Result.Content.ReadAsStringAsync().Result;
            //var collection = JsonConvert.DeserializeObject<dynamic>(json);

            //string productIdJson = client.GetAsync($"/products/{productId:G}").Result.Content.ReadAsStringAsync().Result;
            //var product = JsonConvert.DeserializeObject<dynamic>(productIdJson);

            var productResponse = await client.GetAsync($"products/{productId}");

            if (productResponse.IsSuccessStatusCode)
            {
                var productResponseJson = await productResponse.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductModel>(productResponseJson);

                var productTypeResponse = await client.GetStringAsync($"product_types/{product.ProductTypeId}");
                var productType = JsonConvert.DeserializeObject<ProductTypeModel>(productTypeResponse);

                return new CartItemResponseDto
                {
                    ProductId = product.Id,
                    ProductTypeName = productType.Name,
                    ProductTypeHasInsurance = productType.CanBeInsured,
                    SalesPrice = product.SalesPrice,
                    InsuranceValue = CalculateProductInsurance(product.SalesPrice, productType.CanBeInsured, productType.Name),
                    Quantity = quantity
                };

            }
            else
            {
                throw new Exception($"Remote server returned status code: {productResponse.StatusCode}");
            }

            //int productTypeId = product?.ProductType;
            //string productTypeName = null;
            //bool hasInsurance = false;

            //insurance = new CartItemResponseDto();

            /*for (int i = 0; i < collection?.Count; i++)
            {
                if (collection?[i].id == productTypeId && collection[i].canBeInsured == true)
                {
                    insurance.ProductTypeName = collection[i].name;
                    insurance.ProductTypeHasInsurance = true;
                }
            }*/
        }

        public static void GetSalesPrice(string baseAddress, int productId, ref CartItemResponseDto insurance)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(baseAddress) };
            string json = client.GetAsync(string.Format("/products/{0:G}", productId)).Result.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<dynamic>(json);

            insurance.SalesPrice = product?.salesPrice;
        }

        public static decimal CalculateProductInsurance(decimal salesPrice, bool hasInsurance, string productTypeName)
        {
            var insuranceValue = 0m;

            var isLaptop = productTypeName.Trim().Equals("laptops", StringComparison.InvariantCultureIgnoreCase);
            var isSmartPhone = productTypeName.Trim().Equals("smartphones", StringComparison.InvariantCultureIgnoreCase);

            if (hasInsurance)
            {
                if (salesPrice < 500 && isLaptop)
                {
                   insuranceValue = 500;
                }
                else if (salesPrice >= 500 && salesPrice < 2000)
                {
                    insuranceValue = 1000;
                }
                else if (salesPrice >= 2000)
                {
                    insuranceValue = 2000;
                }

                // Additional insurance Value for laptops and smartphones
                insuranceValue += isLaptop || isSmartPhone ? 500 : 0;
            }

            return insuranceValue;
        }
    }
}