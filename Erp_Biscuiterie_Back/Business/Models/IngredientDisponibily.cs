using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class IngredientDisponibily
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
