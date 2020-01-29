
using System.ComponentModel.DataAnnotations;

namespace OdeToFood_Core.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Type of Cuisine")]
        public CuisineType Cuisine { get; set; }
    }
}