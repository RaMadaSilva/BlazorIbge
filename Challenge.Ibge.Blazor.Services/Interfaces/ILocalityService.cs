using Challenge.Ibge.Blazor.Presentation.ViewModel;

namespace Challenge.Ibge.Blazor.Applications.Interfaces
{
    public interface ILocalityService
    {

        Task SaveAsync(LocalityViewModel localityVm);
    }
}
