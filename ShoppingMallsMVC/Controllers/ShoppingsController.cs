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

namespace ShoppingMallsMVC.Controllers
{
    public class ShoppingsController : Controller
    {
        // GET: ShoppingController
        // GET: BooksController
        Uri baseAddress = new Uri("https://localhost:7268/api");
        HttpClient client;

        public ShoppingsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        #region GET METHOD
        public ActionResult Get()
        {
            List<Shopping> shoppingsList = new List<Shopping>();

            HttpResponseMessage responseMessage = client.GetAsync(baseAddress + "/Shopping").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                shoppingsList = JsonConvert.DeserializeObject<List<Shopping>>(data);
            }
            return View(shoppingsList);

        }
        #endregion

        #region INDEX METHOD

        public ActionResult Index()
        {
            List<Shopping> shopping = new List<Shopping>();

            HttpResponseMessage responseMessage = client.GetAsync(baseAddress + "/Shopping/").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                shopping = JsonConvert.DeserializeObject<List<Shopping>>(data);
            }
            return View(shopping);

        }

        #endregion

        #region CREATE METHOD

        public ActionResult Create()
        {
            return View();
        }

        #endregion

        #region POST METHOD Using Create

        [HttpPost]
        public ActionResult Create(Shopping shopping)
        {
            var postTask = client.PostAsJsonAsync<Shopping>(baseAddress + "/Shoppings", shopping);
            postTask.Wait();
            var result = postTask.Result;


            return RedirectToAction("Get");

        }

        #endregion

        #region UPDATE METHOD

        public ActionResult Update(Shopping shopping)

        {
            return View("Update", shopping);
        }


        public ActionResult UpdateShoppingMall(Shopping shopping)
        {
            var putTask = client.PutAsJsonAsync<Shopping>(baseAddress + "/Shopping" + shopping.Id.ToString(), shopping);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Get");
            }
            return View(shopping);
        }

        #endregion

        #region DELETE METHOD

        public ActionResult Delete(int id)
        {

            //HTTP DELETE
            var deleteTask = client.DeleteAsync(baseAddress + "/Shopping" + id.ToString());
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Get");
            }

            return RedirectToAction("Delete");
        }
        #endregion


    }
}

