using DAL;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IShopRepository ShopRepository;
        public CartController(IShopRepository ShopRepository)
        {
            this.ShopRepository = ShopRepository;
        }
        public IActionResult Index()
        {
            string userName = HttpContext.Request.Cookies["user_id"];
            return View(ShopRepository.GetShoppingCart(userName));
        }
        public IActionResult AddToCart(Product product)
        {
            string userName = HttpContext.Request.Cookies["user_id"];

            ShoppingCart cart = ShopRepository.GetShoppingCart(product.Id, userName);
            if(cart==null)
                    ShopRepository.AddToCart(product.Id, userName);
            return RedirectToAction("index");
        }
        public IActionResult RemoveFromCart(Product product)
        {
            string userName = HttpContext.Request.Cookies["user_id"];
            ShoppingCart cart = ShopRepository.GetShoppingCart(product.Id, userName);
            if (cart == null)
                return RedirectToAction("index");
            else
            {
                ShopRepository.RemoveFromCart(cart.Id);
                return RedirectToAction("index");
            }
        }
    }
}
