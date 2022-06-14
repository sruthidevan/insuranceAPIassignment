using System.Linq;
using System.Threading.Tasks;
using InsuranceCalculator.Api.Contexts;
using InsuranceCalculator.Api.Models.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceCalculator.Api
{
    public static class TestData
    {
        public static async Task Seed(IApplicationBuilder app)
        {
           using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
           var dbContext = serviceScope.ServiceProvider.GetService<ApiDbContext>();
           await Seed(dbContext);
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
                    Id = int.Parse("1"),
                    ProductTypeName = "Apple",
                    NamePlural = "Apples",
                    SalesPrice = new decimal(0.34)
                });

                dbContext.Add(new Product
                {
                    Id = int.Parse("2"),
                    ProductTypeName = "Banana",
                    NamePlural = "Bananas",
                    SalesPrice = new decimal(0.34)
                });
                dbContext.Add(new Product
                {
                    Id = int.Parse("3"),
                    ProductTypeName = "Orange",
                    NamePlural = "Oranges",
                    SalesPrice = new decimal(0.34)
                });
                dbContext.Add(new Product
                {
                    Id = int.Parse("4"),
                    ProductTypeName = "Cherry",
                    NamePlural = "Cherries",
                    SalesPrice = new decimal(0.34)
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
