using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IShopRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        IEnumerable<ShoppingCart> GetShoppingCart(string userName);
        ShoppingCart GetShoppingCart(int productId, string userName);
        void AddToCart(int productId,string userName);
    }
}
