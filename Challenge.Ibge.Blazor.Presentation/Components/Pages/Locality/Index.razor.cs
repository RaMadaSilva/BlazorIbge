using Challenge.Ibge.Blazor.Applications.ViewModel;
using Microsoft.AspNetCore.Components;

namespace Challenge.Ibge.Blazor.Presentation.Components.Pages.Locality
{
    public partial class Index : ComponentBase
    {
        private bool IsAutenticated;
        private int currentPage = 1;
        private int itemPerPage = 10;
        private string? error = null;

        private SearchViewModel search = new();

        public IEnumerable<LocalityViewModel> localityViewModels { get; set; } = Enumerable.Empty<LocalityViewModel>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var authSate = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                IsAutenticated = authSate.User.Identity.IsAuthenticated;

                localityViewModels = await Service.GetAsync();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
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
            try
            {
                if (search.SearchType == Domain.Enums.ESearcType.CodeIBGE)
                {
                    long result;

                    if (!long.TryParse(search.Search, out result))
                    {
                        error = "deve informar valores inteiros";
                        return;
                    }
                    var locality = await Service.GetbyIdAsync(result); 

                    if(locality is null)
                    {
                        validation(); 
                    }

                    localityViewModels = new List<LocalityViewModel> {locality};
                }
                else if (search.SearchType == Domain.Enums.ESearcType.State)
                {
                    var localities = await Service.GetILocalityByStateAsync(search.Search);

                    if (!localities.Any()) 
                    {
                        validation();
                        return; 
                    }
                    localityViewModels = localities; 
                }
                else
                {
                    var localities = await Service.GetLocalityByCityAsync(search.Search);
                    if (!localities.Any())
                    {
                        validation();
                        return; 
                    }
                       
                    localityViewModels = localities; 
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        private async Task HandlerSeachEmpty()
        {
            try
            {
                if (string.IsNullOrEmpty(search.Search))
                {
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message; 
            }
        }
        private void RefreshPage()
        {
            Navigation.NavigateTo("/locality", forceLoad:true); 
        }
        private void validation()
        {
            error = $"Not found";
            localityViewModels = Enumerable.Empty<LocalityViewModel>();
        }
    }
}
