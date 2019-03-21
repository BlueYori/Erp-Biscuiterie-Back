using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientDisponibily = new HashSet<IngredientDisponibily>();
            Recipe = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int TypeIngredientId { get; set; }

        public TypeIngredient TypeIngredient { get; set; }
        public ICollection<IngredientDisponibily> IngredientDisponibily { get; set; }
        public ICollection<Recipe> Recipe { get; set; }
    }
}
