using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingMallMVC.Models;

namespace ShoppingMallMVC.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: ShoppingController
        // GET: BooksController
        Uri baseAddress = new Uri("https://localhost:7133/api");
        HttpClient client;

        public ShoppingController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        #region GET METHOD
        public ActionResult Get()
        {
            List<ShoppingMallModel> shoppingMallList = new List<ShoppingMallModel>();

            HttpResponseMessage responseMessage = client.GetAsync(baseAddress + "/Shoppings").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                shoppingMallList = JsonConvert.DeserializeObject<List<ShoppingMallModel>>(data);
            }
            return View(shoppingMallList);

        }
        #endregion

        #region INDEX METHOD

        public ActionResult Index()
        {
            List<ShoppingMallModel> shoppingMall = new List<ShoppingMallModel>();

            HttpResponseMessage responseMessage = client.GetAsync(baseAddress + "/ShoppingMall/").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                shoppingMall = JsonConvert.DeserializeObject<List<ShoppingMallModel>>(data);
            }
            return View(shoppingMall);

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
        public ActionResult Create(ShoppingMallModel Shopping)
        {
            var postTask = client.PostAsJsonAsync<ShoppingMallModel>(baseAddress + "/ShoppingMall", Shopping);
            //postTask.Wait();
            var result = postTask.Result;


            return RedirectToAction("Get");

        }

        #endregion

        #region UPDATE METHOD

        public ActionResult Update(ShoppingMallModel Shopping)

        {
            return View("Update", Shopping);
        }


        public ActionResult UpdateShopping(ShoppingMallModel Shopping)
        {
            var putTask = client.PutAsJsonAsync<ShoppingMallModel>(baseAddress + "/Shopping/" + Shopping.ToString(), Shopping);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Get");
            }
            return View(Shopping);
        }

        #endregion

        #region DELETE METHOD

        public ActionResult Delete(int id)
        {

            //HTTP DELETE
            var deleteTask = client.DeleteAsync(baseAddress + "/ShoppingMall/" + id.ToString());
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Get");
            }

            return RedirectToAction("Delete");
        }
        #endregion




        //#region SEARCH METHOD
        //public ActionResult Search(string searchString)
        //{
        //    List<ShoppingMall> books = new List<ShoppingMall>();
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Books/" + searchString).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;
        //        books = JsonConvert.DeserializeObject<List<ShoppingMall>>(data);
        //    }
        //    return View("Get", shopping);
        //}
        //endregion

    }
}