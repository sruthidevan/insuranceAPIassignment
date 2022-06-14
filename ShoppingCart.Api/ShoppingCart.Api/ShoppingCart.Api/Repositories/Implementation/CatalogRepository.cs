using InsuranceCalculator.Api.Contexts;
using InsuranceCalculator.Api.Models.Data;
using InsuranceCalculator.Api.Repositories.Interfaces;

namespace InsuranceCalculator.Api.Repositories.Implementation
{
    public class CatalogRepository : BaseRepository<Product>, ICatalogRepository
    {
        private readonly ApiDbContext _dbContext;
        
        public CatalogRepository(ApiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
