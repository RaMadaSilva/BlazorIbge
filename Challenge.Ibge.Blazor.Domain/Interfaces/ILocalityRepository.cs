using Challenge.Ibge.Blazor.Domain.Entities;

namespace Challenge.Ibge.Blazor.Domain.Interfaces
{
    public interface ILocalityRepository
    {
        Task CreateAsync(Locality locality); 
    }
}
