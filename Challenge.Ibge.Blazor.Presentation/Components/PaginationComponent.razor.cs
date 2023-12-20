using Microsoft.AspNetCore.Components;

namespace Challenge.Ibge.Blazor.Presentation.Components
{
    public partial class PaginationComponent : ComponentBase
    {
        [Parameter]
        public int CurrentPage { get; set; } = 1;
        [Parameter]
        public int TotalItems { get; set; }
        [Parameter]
        public int ItemsPerPage { get; set; } = 10;
        [Parameter]
        public EventCallback<int> PageChanged { get; set; }
        [Parameter]
        public EventCallback<int> ItemsPerPageChanged { get; set; }
        private int NumberPages => (int)Math.Ceiling(TotalItems / (double)ItemsPerPage);
        private async Task ChangePage(int page)
        {
            if (page >= 1 && page <= NumberPages && page != CurrentPage)
            {
                CurrentPage = page;
                await PageChanged.InvokeAsync(CurrentPage);
                StateHasChanged();
            }
        }

        private async Task ChangeItemsPerPage(int itemsPerPage)
        {
            if (itemsPerPage > 0 && itemsPerPage != ItemsPerPage)
            {
                ItemsPerPage = itemsPerPage;
                await ItemsPerPageChanged.InvokeAsync(ItemsPerPage);
                await PageChanged.InvokeAsync(1);
                StateHasChanged();
            }
        }
    }
}
