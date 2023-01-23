using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaMiaPizzeriaEfPost.Models
{
    public class CategoryPizzaView
    {
        public Pizza pizza { get; set; }

        public List<Category>? categories { get; set; }

        public List<SelectListItem>? Ingredienti { get; set; }

        public List<string> IngredientiSelezionati { get; set; }
    }
}
