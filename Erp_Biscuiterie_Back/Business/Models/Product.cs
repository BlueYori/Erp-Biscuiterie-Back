using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
            Recipe = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Recipe> Recipe { get; set; }
    }
}
