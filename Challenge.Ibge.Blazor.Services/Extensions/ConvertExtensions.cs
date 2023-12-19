using Challenge.Ibge.Blazor.Domain.Entities;
using Challenge.Ibge.Blazor.Applications.ViewModel;

namespace Challenge.Ibge.Blazor.Applications.Extensions
{
    public static class ConvertExtensions
    {
        public static IEnumerable<LocalityViewModel> ToListViewModel(this IEnumerable<Locality> localities) 
        {
            if (localities is null)
                return null;
            return localities.Select(x => new LocalityViewModel
            {
                Id = x.Id,
                State = x.State,
                City = x.City,
            });
        }
    }
}
