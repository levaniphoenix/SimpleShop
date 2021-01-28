using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Product
    {
        public int Id { set; get; }
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        [Required]
        public double Price { set; get; }
        [MaxLength(250)]
        public string Description { set; get; }
        public string PhotoPath { set; get; }

        public ICollection<ShoppingCart> shoppingCart { get; set; }
    }
}
