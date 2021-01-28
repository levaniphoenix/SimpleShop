using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLShopRepository : IShopRepository
    {
        private readonly AppDbContext context;
        public SQLShopRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }
        public Product GetProductById(int id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
                return product;
            else
                return null;
        }
        public IEnumerable<ShoppingCart> GetShoppingCart(string userName)
        {
            IEnumerable<ShoppingCart> shoppingCart = context.ShoppingCarts.Where<ShoppingCart>(e => e.Username == userName);
            return shoppingCart;
        }
        public ShoppingCart GetShoppingCart(int productId, string userName)
        {
            try
            {
                ShoppingCart cart = context.ShoppingCarts.Single(e => e.ProductId == productId && e.Username == userName);
                return cart;
            }
            catch(Exception e)
            {
                if(e.Message == "NoElementsException")
                    return null;
            }
            return null;
        }
        public void AddToCart(int productId,string userName)
        {
            Product product = GetProductById(productId);
            ShoppingCart cart=new ShoppingCart { ProductId=product.Id,Username=userName};
            context.ShoppingCarts.Add(cart);
            context.SaveChanges();
        }
        
    }
}
