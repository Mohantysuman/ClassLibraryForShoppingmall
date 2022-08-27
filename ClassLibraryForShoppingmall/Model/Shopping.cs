using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForShoppingmall.Model
{
    public class Shopping
    {
        [Key]
        [Required]
        public int Id { get; set; }
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
