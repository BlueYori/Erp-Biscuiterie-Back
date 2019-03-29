using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class Recipe
    {
        public int Id { get; set; }
        public int IngredientQuantity { get; set; }
        public int IngredientId { get; set; }
        public int ProductId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Product Product { get; set; }
    }
}
