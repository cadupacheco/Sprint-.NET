using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sprint1.Data;
using Sprint1.Entities;

namespace Sprint1.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly AppDbContext _context;

        public MotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Moto>> GetMotosPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Motos
                .Include(m => m.Modelo)
                .Include(m => m.Patio)
                .OrderBy(m => m.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Motos.CountAsync();
        }

        public async Task<Moto> GetMotoByIdAsync(int id)
        {
            return await _context.Motos
                .Include(m => m.Modelo)
                .Include(m => m.Patio)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddMotoAsync(Moto moto)
        {
            await _context.Motos.AddAsync(moto);
        }

        public void DeleteMoto(Moto moto)
        {
            _context.Motos.Remove(moto);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
