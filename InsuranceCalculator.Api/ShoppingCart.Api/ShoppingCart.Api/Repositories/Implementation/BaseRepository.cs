using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCart.Api.Contexts;
using ShoppingCart.Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Api.Repositories.Implementation
{
    public abstract class BaseRepository<T> where T : Entity
    {
        private readonly ApiDbContext _dbContext;

        protected BaseRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> FindByIdAsync(int id) => await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        public virtual async Task<List<T>> FetchAllAsync() => await _dbContext.Set<T>().ToListAsync();
    }
}
