using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ShoppingMallProjectMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ShoppingMallProjectMVCUser class
public class ShoppingMallProjectMVCUser : IdentityUser
{
    [Required]
    [StringLength(100, ErrorMessage = "The String must be 10 character long!.")]
    public string PanNumber { get; set; }
}

