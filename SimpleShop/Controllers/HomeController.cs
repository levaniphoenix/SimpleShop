using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShopRepository ShopRepository;
        private readonly ILogger<HomeController> Logger;

        public HomeController(ILogger<HomeController> logger, IShopRepository ShopRepository)
        {
            Logger = logger;
            this.ShopRepository = ShopRepository;
        }

        public IActionResult Index()
        {
            return View(ShopRepository.GetProducts());
        }
        public IActionResult CreateUserId()
        {
            if (HttpContext.Request.Cookies["user_id"] == null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(7);
                HttpContext.Response.Cookies.Append("user_id", Guid.NewGuid().ToString(), option);
            }
            return View("index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
