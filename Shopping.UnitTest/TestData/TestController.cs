//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using ShoppingMallsProjectNewMVC.Controllers;
//using ClassLibraryForShoppingmall.Model;

//namespace Shopping.UnitTest.TestData
//{
//    public class TestController
//    {
//        ShoppingsController account = new ShoppingsController();
//        [Fact]
//        public void Test_Index()
//        {

//            var result = Controller.Shoppings();
//            var page = Assert.IsType<IActionResult>(result);
//            Assert.NotNull(page);
//        }
//        [Fact]
//        public void Test_ErrorPage()
//        {
//            var result = account.ErrorPage();
//            var errorPage = Assert.IsType<ViewResult>(result);
//            Assert.NotNull(errorPage.ViewName);

//        }
//        [Fact]
//        public void Test_IsEmail()
//        {
//            var result = account.IsEmailExsist("sanjay.singh@kellton.com") as IActionResult;

//            Assert.Equal("Exist", result!.ToString());
//        }
//    }
//}




