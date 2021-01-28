using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class ShoppingCart
    {
        public int Id { set; get; }
        [Required]
        public int ProductId { set; get; }
        [Required]
        public string Username { set; get; }

        public Product Products { get; set; }
    }
}
