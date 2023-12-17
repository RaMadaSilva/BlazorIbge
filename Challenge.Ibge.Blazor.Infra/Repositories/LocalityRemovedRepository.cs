using Challenge.Ibge.Blazor.Domain.Entities;
using Challenge.Ibge.Blazor.Domain.Interfaces;
using Challenge.Ibge.Blazor.Infra.Data;

namespace Challenge.Ibge.Blazor.Infra.Repositories
{
    public class LocalityRemovedRepository : ILocalityRemovedRepository
    {
        private readonly ApplicationDbContext _context;

        public LocalityRemovedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(LocalityRemoved removed)
        {
            await _context.LocalityRemoveds.AddAsync(removed);
            await _context.SaveChangesAsync(); 
            return true;
        }
    }
}
