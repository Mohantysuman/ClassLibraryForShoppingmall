using System.ComponentModel.DataAnnotations;

namespace ShoppingMallsProjectNewMVC.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PanNumber { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? RoleName { get; set; }
        [Required]
        public string? Status { get; set; }
        public string? IsApproved { get; set; }

    }
}
