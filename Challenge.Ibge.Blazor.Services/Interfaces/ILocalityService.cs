using Challenge.Ibge.Blazor.Applications.ViewModel;

namespace Challenge.Ibge.Blazor.Applications.Interfaces
{
    public interface ILocalityService
    {
        Task SaveAsync(LocalityViewModel localityVm);
        Task<IEnumerable<LocalityViewModel>> GetAsync();
        Task<LocalityViewModel> GetbyIdAsync(long id);
        Task RemoveAsync(long id);
        Task UpdateLocalityAsync(LocalityViewModel viewModel); 
        Task<IEnumerable<LocalityViewModel>> GetLocalityByCityAsync(string city); 
        Task<IEnumerable<LocalityViewModel>> GetILocalityByStateAsync(string state);


    }
}
