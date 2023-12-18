using Challenge.Ibge.Blazor.Domain.Enums;

namespace Challenge.Ibge.Blazor.Applications.ViewModel
{
    public  class SearchViewModel
    {
        public SearchViewModel()
        {
            SearchType = ESearcType.City;
            Search = string.Empty; 
        }
        public ESearcType SearchType{ get; set; }
        public string Search { get; set; }  
    }
}
