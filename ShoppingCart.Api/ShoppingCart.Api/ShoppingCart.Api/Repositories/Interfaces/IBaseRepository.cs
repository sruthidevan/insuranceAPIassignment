using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceCalculator.Api.Models.Data;

namespace InsuranceCalculator.Api.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> FindByIdAsync(int id);
        Task<T> AddSurchargeRateByProductId(int id);
        Task<List<T>> FetchAllAsync();
    }
}
