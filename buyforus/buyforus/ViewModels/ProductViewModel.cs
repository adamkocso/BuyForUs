using System.ComponentModel.DataAnnotations;

namespace buyforus.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int Price { get; set; }
    }
}