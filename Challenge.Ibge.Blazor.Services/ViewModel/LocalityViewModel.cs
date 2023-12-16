using Challenge.Ibge.Blazor.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Ibge.Blazor.Presentation.ViewModel
{
    public class LocalityViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "The State must be exactly 2 characters long")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [MinLength(2, ErrorMessage = "The City must be at least 3 characters long")]
        [MaxLength(60, ErrorMessage = "The City must be at least 60 characters long")]
        public string City { get; set; } = string.Empty;

        public static implicit operator LocalityViewModel(Locality locality)
            => new LocalityViewModel
            {
                Id = locality.Id,
                State = locality.State,
                City = locality.City,
            }; 

        public static implicit operator Locality(LocalityViewModel viewModel)
            =>new Locality(viewModel.City, viewModel.State);
    }
}
