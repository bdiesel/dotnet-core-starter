using System.ComponentModel.DataAnnotations;
using TestApp.Entities;

namespace TestApp.ViewModels
{
    public class DataEntityEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine{get; set;}
    }
}
