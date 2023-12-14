using Challenge.Ibge.Blazor.Domain.Entities;

namespace Challenge.Ibge.Blazor.Domain.Interfaces
{
    public interface ILocalityRemovedRepository
    {
        Task<bool> Create(LocalityRemoved removed); 
    }
}
