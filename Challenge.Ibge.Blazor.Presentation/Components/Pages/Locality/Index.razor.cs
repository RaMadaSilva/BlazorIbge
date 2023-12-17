using Challenge.Ibge.Blazor.Presentation.ViewModel;
using Microsoft.AspNetCore.Components;

namespace Challenge.Ibge.Blazor.Presentation.Components.Pages.Locality
{
    public partial class Index : ComponentBase
    {
        private bool IsAutenticated;
        private int currentPage = 1;
        private int itemPerPage = 10;

        private long id;
        private string? state;
        private string? city;

        public IEnumerable<LocalityViewModel> localityViewModels { get; set; } = Enumerable.Empty<LocalityViewModel>();

        protected override async Task OnInitializedAsync()
        {
            var authSate = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            IsAutenticated = authSate.User.Identity.IsAuthenticated;

            localityViewModels = await Service.GetAsync();
        }

        private IEnumerable<LocalityViewModel> GetLocalityPaginated()
        {
            int start = (currentPage - 1) * itemPerPage;

            return localityViewModels.Skip(start).Take(itemPerPage).ToList(); 
        }

        private void HandlerPageChanged(int newPage) => currentPage = newPage;

        private void HandlerItemsPerPageChenged(int newItemsPerPage) => itemPerPage = newItemsPerPage;

    }
}
