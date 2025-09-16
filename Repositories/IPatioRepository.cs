using System.Collections.Generic;
using System.Threading.Tasks;
using Sprint1.Entities;

namespace Sprint1.Repositories
{
    public interface IPatioRepository
    {
        Task<IEnumerable<Patio>> GetPatiosPagedAsync(int pageNumber, int pageSize);
        Task<int> GetCountAsync();
        Task<Patio> GetPatioByIdAsync(int id);
        Task AddPatioAsync(Patio patio);
        void DeletePatio(Patio patio);
        Task<bool> SaveChangesAsync();
    }
}
