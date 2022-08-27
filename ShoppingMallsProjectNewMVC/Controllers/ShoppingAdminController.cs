using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingMallsProjectNewMVC.Models;

namespace ShoppingMallsProjectNewMVC.Controllers
{
    public class ShoppingAdminController : Controller
    {
        private readonly ShoppingAdminDbContext _shoppingAdminDbContext;
        public ShoppingAdminController(ShoppingAdminDbContext shoppingAdminDbContext)
        {
            _shoppingAdminDbContext = shoppingAdminDbContext;
        }
        public IActionResult RegisteredPage()
        {
            return View();
        }
        [Authorize(Policy = "Admin")]


        public IActionResult Index()
        {
            if (_shoppingAdminDbContext.ShoppingMallModels == null)
            {
                return NotFound();
            }
            List<AdminModel> shoppingMallModels = new List<AdminModel>();
            shoppingMallModels = _shoppingAdminDbContext.ShoppingMallModels.ToList();
            if (shoppingMallModels == null)
            {
                return NotFound();
            }
            return View(shoppingMallModels);
        }

        //public async Task<IActionResult> ChangeUserStatus(int id, bool isApprove)
        //{
        //    if (_shoppingAdminDbContext.ShoppingMallModels == null)
        //    {
        //        return BadRequest("table doesn't exist");
        //    }
        //    var filterusers = _shoppingAdminDbContext.ShoppingMallModels.Where(x => x.Id == id).FirstOrDefault();
        //    if (isApprove)
        //    {
        //        filterusers.IsApproved = true;
        //        filterusers.Status = "Approved";
        //    }
        //    else
        //    {
        //        filterusers.IsApproved = false;
        //        filterusers.Status = "rejected";

        //    }
        //    _shoppingAdminDbContext.SaveChanges();
        //    return Ok("Updated successfully");
        //}


    }
}




