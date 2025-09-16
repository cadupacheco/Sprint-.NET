using System.Collections.Generic;
using System.Threading.Tasks;
using Sprint1.Entities;

namespace Sprint1.Repositories
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetMotosPagedAsync(int pageNumber, int pageSize);
        Task<int> GetCountAsync();
        Task<Moto> GetMotoByIdAsync(int id);
        Task AddMotoAsync(Moto moto);
        void DeleteMoto(Moto moto);
        Task<bool> SaveChangesAsync();
    }
}
