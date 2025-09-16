using System.Collections.Generic;
using System.Threading.Tasks;
using Sprint1.Entities;

namespace Sprint1.Repositories
{
    public interface IModeloRepository
    {
        Task<IEnumerable<Modelo>> GetModelosPagedAsync(int pageNumber, int pageSize);
        Task<int> GetCountAsync();
        Task<Modelo> GetModeloByIdAsync(int id);
        Task AddModeloAsync(Modelo modelo);
        void DeleteModelo(Modelo modelo);
        Task<bool> SaveChangesAsync();
    }
}
