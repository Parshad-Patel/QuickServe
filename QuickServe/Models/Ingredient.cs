using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace QuickServe.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        [ValidateNever]
        public ICollection<ProductIngredient> ProductIngredients { get; set; }
        
    }
}