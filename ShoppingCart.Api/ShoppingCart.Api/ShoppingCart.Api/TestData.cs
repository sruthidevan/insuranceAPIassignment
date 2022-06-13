using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Api.Contexts;
using ShoppingCart.Api.Models.Data;

namespace ShoppingCart.Api
{
    public static class TestData
    {
        public static async Task Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApiDbContext>();
                await Seed(dbContext);
            }
        }

        public static async Task Seed(ApiDbContext dbContext)
        {
            await SeedCatalogData(dbContext);
        }

        private static async Task SeedCatalogData(ApiDbContext dbContext)
        {
            if (!dbContext.CatalogItems.Any())
            {
                dbContext.Add(new Product
                {
                    ProductId = int.Parse("13a9cd0b-dbfc-47d0-ab25-43e6d2aac375"),
                    ProductTypeName = "Apple",
                    NamePlural = "Apples",
                    SalesPrice = new decimal(0.34)
                });

                dbContext.Add(new Product
                {
                    ProductId = int.Parse("117d7811-2d5d-4192-8cd3-bbd5d353981f"),
                    ProductTypeName = "Banana",
                    NamePlural = "Bananas",
                    SalesPrice = new decimal(0.34)
                });
                dbContext.Add(new Product
                {
                    ProductId = int.Parse("2ca94fcf-22e3-49bb-9c7c-71a0130a9290"),
                    ProductTypeName = "Orange",
                    NamePlural = "Oranges",
                    SalesPrice = new decimal(0.34)
                });
                dbContext.Add(new Product
                {
                    ProductId = int.Parse("76dec6a2-73d6-42ec-918c-d996eb02cba2"),
                    ProductTypeName = "Cherry",
                    NamePlural = "Cherries",
                    SalesPrice = new decimal(0.34)
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
