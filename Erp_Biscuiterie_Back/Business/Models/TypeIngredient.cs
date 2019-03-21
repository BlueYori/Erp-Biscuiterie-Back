using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class TypeIngredient
    {
        public TypeIngredient()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public int Id { get; set; }
        public string Unit { get; set; }
        public int Divider { get; set; }

        public ICollection<Ingredient> Ingredient { get; set; }
    }
}
