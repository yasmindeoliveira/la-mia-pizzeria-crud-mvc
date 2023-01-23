using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeriaEfPost.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        public string Name { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public Ingredient ()
        {

        }
    }
}
