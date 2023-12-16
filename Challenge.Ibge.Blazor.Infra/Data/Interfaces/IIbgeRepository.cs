using Challenge.Ibge.Blazor.Infra.Data.Entities;

namespace Challenge.Ibge.Blazor.Infra.Data.Interfaces;

public interface IIbgeRepository
{
    Task<IList<IbgeEntity>>GetIbges();
    Task<IbgeEntity?> UpdateIbge(IbgeEntity ibge);
    Task<IEnumerable<IbgeEntity?>> GetIbgeByCity(string city);
    Task<IEnumerable<IbgeEntity?>> GetIbgeByState(string state);
    Task<IbgeEntity?> GetIbgeById(string id);
}