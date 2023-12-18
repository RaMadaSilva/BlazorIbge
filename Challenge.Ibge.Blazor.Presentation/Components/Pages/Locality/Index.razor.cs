using Challenge.Ibge.Blazor.Applications.ViewModel;
using Microsoft.AspNetCore.Components;

namespace Challenge.Ibge.Blazor.Presentation.Components.Pages.Locality
{
    public partial class Index : ComponentBase
    {
        private bool IsAutenticated;
        private int currentPage = 1;
        private int itemPerPage = 10;

        private SearchViewModel search = new();

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

        private async Task SearchAsync()
        {
            if (search.SearchType == Domain.Enums.ESearcType.Code)
            {
                long result;

                if (long.TryParse(search.Search, out result))
                {
                    localityViewModels = new List<LocalityViewModel> { await Service.GetbyIdAsync(result) };
                }
            }else if(search.SearchType == Domain.Enums.ESearcType.State)
            {
                localityViewModels = await Service.GetILocalityByStateAsync(search.Search); 
            }
            else
            {
                localityViewModels = await Service.GetLocalityByCityAsync(search.Search);
            }
        }

        private async Task HandlerSeachEmpty()
        {
            if (string.IsNullOrEmpty(search.Search))
            {
                await OnInitializedAsync(); 
            }
        }
    }
}
