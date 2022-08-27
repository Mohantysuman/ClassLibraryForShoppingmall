using System.ComponentModel.DataAnnotations;

namespace ShoppingMallMVC.Models
{
    public class ShoppingMallModel
    {
        [Key]
        [Required]
        public string? ShoppingMallName { get; set; }
        [Required]
        public string? ShoppingMallCity { get; set; }
        [Required]
        public string? ShoppingMallState { get; set; }
        [Required]
        public int Year { get; set; }
    }
}
