using LaMiaPizzeriaEfPost.Models;
using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeriaEfPost.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }

        public string categoria { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public Category()
        {

        }
    }
}
