using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
            ProductDisponibility = new HashSet<ProductDisponibility>();
            Recipe = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductDisponibility> ProductDisponibility { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
