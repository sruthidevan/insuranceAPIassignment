using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceCalculator.Api.Controllers;
using InsuranceCalculator.Api.Models.Dto.Carts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace InsuranceCalculator.Api.Tests.Insurance.Tests
{
    public class InsuranceTests
    {
        private readonly ControllerTestFixture _fixture;

        public InsuranceTests(ControllerTestFixture fixture)
        {
            _fixture = fixture;
        }

        [TestMethod()]
        public async Task CalculateInsurance_GivenSalesPriceBetween500And2000Euros_ShouldAddThousandEurosToInsuranceCost()
        {
            const float expectedInsuranceValue = 1000;

            var dto = new CartContentsRequestDto()
                      {
                         Products = new List<CartItemRequestDto>
                         {
                         }
                      };

            var sut = new InsurancesController();

            var result = await sut.CalculateInsurance(dto);

            Assert.AreEqual(
                expected: expectedInsuranceValue,
                actual: result.
            );
        }
    }

    public class ControllerTestFixture: IDisposable
    {
        private readonly IHost _host;

        public ControllerTestFixture()
        {
            _host = new HostBuilder()
                   .ConfigureWebHostDefaults(
                        b => b.UseUrls("http://localhost:5002")
                              .UseStartup<ControllerTestStartup>()
                    )
                   .Build();

            _host.Start();
        }

        public void Dispose() => _host.Dispose();
    }

    public class ControllerTestStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(
                ep =>
                {
                    ep.MapGet(
                        "products/{id:int}",
                        context =>
                        {
                            int productId = int.Parse((string) context.Request.RouteValues["id"] ?? string.Empty);
                            var product = new
                                          {
                                              id = productId,
                                              name = "Test Product",
                                              productTypeId = 1,
                                              salesPrice = 750
                                          };
                            return context.Response.WriteAsync(JsonConvert.SerializeObject(product));
                        }
                    );
                    ep.MapGet(
                        "product_types",
                        context =>
                        {
                            var productTypes = new[]
                                               {
                                                   new
                                                   {
                                                       id = 1,
                                                       name = "Test type",
                                                       canBeInsured = true
                                                   }
                                               };
                            return context.Response.WriteAsync(JsonConvert.SerializeObject(productTypes));
                        }
                    );
                }
            );
        }
    }
}