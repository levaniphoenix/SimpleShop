using DAL;
using DAL.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<IdentityUser> SignInManager;
        public CartController(IShopRepository shopRepository, SignInManager<IdentityUser> signInManager)
        {
            this.ShopRepository = shopRepository;
            this.SignInManager = signInManager;            
        }
        public IActionResult Index()
        {
            //string userName = HttpContext.Request.Cookies["user_id"];
            return View(ShopRepository.GetShoppingCart(UserName()));
        }
        public IActionResult AddToCart(Product product)
        {
            //string userName = HttpContext.Request.Cookies["user_id"];

            ShoppingCart cart = ShopRepository.GetShoppingCart(product.Id, UserName());
            if(cart==null)
                    ShopRepository.AddToCart(product.Id, UserName());
            return RedirectToAction("index");
        }
        public IActionResult RemoveFromCart(Product product)
        {
            //string userName = HttpContext.Request.Cookies["user_id"];
            ShoppingCart cart = ShopRepository.GetShoppingCart(product.Id, UserName());
            if (cart == null)
                return RedirectToAction("index");
            else
            {
                ShopRepository.RemoveFromCart(cart.Id);
                return RedirectToAction("index");
            }
        }
        public string UserName()
        {
            if (SignInManager.IsSignedIn(User))
                return User.Identity.Name;
            else
            {
                string userName=HttpContext.Request.Cookies["user_id"];
                if(userName==null)
                {
                    userName = Guid.NewGuid().ToString();
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddDays(7);
                    HttpContext.Response.Cookies.Append("user_id", userName, option);
                }
                return userName;
            }
        }
    }
}
