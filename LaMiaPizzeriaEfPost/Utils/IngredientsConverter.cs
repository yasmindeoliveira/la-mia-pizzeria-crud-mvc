using LaMiaPizzeriaEfPost.Database;
using LaMiaPizzeriaEfPost.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaMiaPizzeriaEfPost.Utils
{
    public class IngredientsConverter
    {
        public static List<SelectListItem> getIngredientsForSelect()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Ingredient> ingredientFromDb = db.Ingredients.ToList();

                List<SelectListItem> IngredientsForSelect = new List<SelectListItem>();

                foreach (Ingredient ingredient in ingredientFromDb)
                {
                    SelectListItem SingleSelect = new SelectListItem() { Text = ingredient.Name, Value = ingredient.IngredientId.ToString() };
                    IngredientsForSelect.Add(SingleSelect);
                }

                return IngredientsForSelect;
            }
        }
    }
}
