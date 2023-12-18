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
            => _context = context;


        public async Task CreateAsync(Locality locality)
        {
            await _context.Localities.AddAsync(locality);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Locality>> GetAllAsync()
        {
            return await _context.Localities.AsNoTracking().ToListAsync();
        }

        public async Task<Locality> GetByIdAsync(long id)
        {
            return await _context.Localities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(Locality locality)
        {
            _context.Localities.Remove(locality);
            await _context.SaveChangesAsync();
        }

        public async Task<Locality?> UpdateAsync(Locality locality)
        {
            var result = await _context.Localities.FirstAsync(x => x.Id == locality.Id);
            if (result is null)
            {
                return null;
            }
            _context.Entry(locality).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<Locality?>> GetByCityAsync(string city)
        {
            if (String.IsNullOrEmpty(city))
                return new List<Locality>(); 

            IQueryable<Locality> query = _context
                                            .Localities
                                            .Where(x => EF.Functions.Like(x.City, $"%{city}%")); 
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Locality?>> GetByStateAsync(string state)
        {
            IQueryable<Locality> query = _context
                                            .Localities
                                            .Where(x => EF.Functions.Like(x.State, $"%{state}%"));

            if (String.IsNullOrEmpty(state))
                return new List<Locality>();

            return await query.ToListAsync();

        }
    }
}
