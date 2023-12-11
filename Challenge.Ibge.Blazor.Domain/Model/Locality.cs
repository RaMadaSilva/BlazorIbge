using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Ibge.Blazor.Domain.Model
{
    public class Locality 
    {
        public Locality()
        {
            Idlocality = GenerateRandomNumericId(7);
            DateCreate = DateTime.Now;
        }

        [Key]
        public string Idlocality { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "The State must be exactly 2 characters long")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [MinLength(3, ErrorMessage = "The City must be at least 3 characters long")]
        [MaxLength(60, ErrorMessage = "The City must be at least 60 characters long")]
        public string City { get; set; } = string.Empty;

        public DateTime DateCreate { get; set; }


        private string GenerateRandomNumericId(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
