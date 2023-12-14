using Challenge.Ibge.Blazor.Domain.Entities;
using Challenge.Ibge.Blazor.Domain.Interfaces;
using Challenge.Ibge.Blazor.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Ibge.Blazor.Infra.Repositories
{
    public class LocalityRepository : ILocalityRepository
    {
        private readonly ApplicationDbContext _context;

        public LocalityRepository(ApplicationDbContext context)
            =>_context = context;
        

        public  async Task CreateAsync(Locality locality)
        {
            await _context.Localities.AddAsync(locality);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Locality>> GetAllAsync()
        {
           return  await _context.Localities.AsNoTracking().ToListAsync();
        }

        public async Task RemoveAsync(Locality locality)
        {
            _context.Localities.Remove(locality);
            await _context.SaveChangesAsync();
        }
    }
}
