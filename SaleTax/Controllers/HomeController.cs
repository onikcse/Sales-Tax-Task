using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaleTax.Data.DatabaseHandler;
using SaleTax.Data.Interface;
using SaleTax.Models;
using SaleTax.Repository.Products;
using SaleTax.Repository.Shopping;
using SaleTax.ViewModel;

namespace SaleTax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProducts iProducts;

        private readonly ShoppingCart shoppingCart = new ShoppingCart();
        private readonly DataHandler dataHandler = new DataHandler();

        public HomeController(ILogger<HomeController> logger, IProducts iproducts)
        {
            _logger = logger;
            this.iProducts = iproducts;
        }

        public IActionResult Index()
        {
            ProductListViewModel vm = new ProductListViewModel();
            vm.Products = iProducts.Products;
            ViewBag.Count = dataHandler.GetCartSize();
            return View(vm);
        }

        public RedirectToActionResult AddToCart(string productName)
        {
            string name = productName;
            dataHandler.AddToCart(name);
            return RedirectToAction("Index");
        }

        public IActionResult CheckOut(bool clear)
        {
            if (clear) dataHandler.ClearCart();

            var productAtCart = dataHandler.GetCartProducts();

            foreach(var product in productAtCart)
            {
                shoppingCart.AddItemToCart(product);

            }

            ViewBag.CartSize = shoppingCart.GetCartSize();
            return View(shoppingCart);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
