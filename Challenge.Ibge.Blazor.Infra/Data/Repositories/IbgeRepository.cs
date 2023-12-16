using Microsoft.EntityFrameworkCore;

using Challenge.Ibge.Blazor.Infra.Data.Context;
using Challenge.Ibge.Blazor.Infra.Data.Entities;
using Challenge.Ibge.Blazor.Infra.Data.Interfaces;

namespace Challenge.Ibge.Blazor.Infra.Data.Repositories;

public class IbgeRepository : IIbgeRepository
{
    private readonly IbgeDbContext _ctx;

    public IbgeRepository(IbgeDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IList<IbgeEntity>> GetIbges()
    {
        return await _ctx.Ibge.ToListAsync();
    }

    public async Task<IbgeEntity?> UpdateIbge(IbgeEntity ibge)
    {
        var result = await _ctx.Ibge.FindAsync(ibge.Id);
        if (result != null)
        {
            result.Id = ibge.Id;
            result.State = ibge.State;
            result.City = ibge.City;
            await _ctx.SaveChangesAsync();
            return result;
        }
        return null;
    }

    public async Task<IEnumerable<IbgeEntity?>> GetIbgeByCity(string city)
    {
        IQueryable<IbgeEntity> query = _ctx.Ibge;
        if (String.IsNullOrEmpty(city))
            return new List<IbgeEntity>();
        query = query.Where(c => c.City!.Contains(city));
        return await query.ToListAsync();
    } 

    public async Task<IEnumerable<IbgeEntity?>> GetIbgeByState(string state)
    {
        IQueryable<IbgeEntity> query = _ctx.Ibge;
        if (String.IsNullOrEmpty(state))
            return new List<IbgeEntity>();
        query = query.Where(c => c.State!.Contains(state));
        return await query.ToListAsync();
    }

    public async Task<IbgeEntity?> GetIbgeById(string id)
    {
        if (String.IsNullOrEmpty(id))
            return new IbgeEntity();
        var result = await _ctx.Ibge
            .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToLower());
        if (result != null)
            return result;
        return null;
    }
}