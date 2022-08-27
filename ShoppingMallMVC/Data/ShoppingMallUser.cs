using System.ComponentModel.DataAnnotations;

namespace ShoppingMallMVC.Data
{
    public class ShoppingMallUser
    {
        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string PANnumber { get; set; }
    }
}
