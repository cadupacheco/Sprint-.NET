using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sprint1.Data;
using Sprint1.Entities;

namespace Sprint1.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly AppDbContext _context;

        public ModeloRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Modelo>> GetModelosPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Modelos
                .OrderBy(m => m.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Modelos.CountAsync();
        }

        public async Task<Modelo> GetModeloByIdAsync(int id)
        {
            return await _context.Modelos.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddModeloAsync(Modelo modelo)
        {
            await _context.Modelos.AddAsync(modelo);
        }

        public void DeleteModelo(Modelo modelo)
        {
            _context.Modelos.Remove(modelo);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
