using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibraryForShoppingmall.Model;
using ClassLibraryForShoppingmall.ShoppingDbContext;
using Newtonsoft.Json;

namespace ShoppingMallProjectMVC.Controllers
{
    public class ShoppingsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7133/api");
        HttpClient client;


        public ShoppingsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public IActionResult Index()
        {
            List<Shopping> ShoppingMall = new List<Shopping>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Shopping").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ShoppingMall = JsonConvert.DeserializeObject<List<Shopping>>(data);
            }
            return View(ShoppingMall);
        }
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(Shopping ShoppingMall)
        {
            var postTask = client.PostAsJsonAsync<Shopping>(baseAddress + "/Shopping/", ShoppingMall);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Shopping Create");
            return View(ShoppingMall);
        }

        public ActionResult Delete(int id)
        {


            var deleteTask = client.DeleteAsync(baseAddress + "/Shopping/" + id.ToString());
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete");
        }

    }
}
    

