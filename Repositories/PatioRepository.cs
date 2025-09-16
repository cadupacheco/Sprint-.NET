using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sprint1.Data;
using Sprint1.Entities;

namespace Sprint1.Repositories
{
    public class PatioRepository : IPatioRepository
    {
        private readonly AppDbContext _context;

        public PatioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patio>> GetPatiosPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Patios
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Patios.CountAsync();
        }

        public async Task<Patio> GetPatioByIdAsync(int id)
        {
            return await _context.Patios.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPatioAsync(Patio patio)
        {
            await _context.Patios.AddAsync(patio);
        }

        public void DeletePatio(Patio patio)
        {
            _context.Patios.Remove(patio);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
