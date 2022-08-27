using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ShoppingMallsMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ShoppingMallsMVCUser class
public class ShoppingMallsMVCUser : IdentityUser
{
    [Required]
    [StringLength(10, ErrorMessage = "The string must be 10 character long.")]
    public string PanNumber { get; set; }
}

