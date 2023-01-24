using LaMiaPizzeriaEfPost.Database;
using LaMiaPizzeriaEfPost.Models;
using LaMiaPizzeriaEfPost.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LaMiaPizzeriaModel.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Home() 
        {
            return View(); 
        }
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzas= db.Pizzas.ToList<Pizza>();
                return View("Index", pizzas);
            }
   
        }

        public IActionResult Dettagli(string nome)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizza = db.Pizzas.Where(p => p.nome == nome).Include(c => c.Category).Include(c => c.Ingredients).FirstOrDefault();

                if (pizza != null)
                {
                    return View(pizza);
                }

                return NotFound("La pizza con il nome cercato non è disponibile");
            }
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            using PizzaContext db = new();

            List<Category> categories= db.Categories.ToList();
            CategoryPizzaView Modello = new();
            Modello.pizza = new Pizza();
            Modello.categories = categories;
            Modello.Ingredienti = IngredientsConverter.getIngredientsForSelect();

            return View("Create", Modello);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryPizzaView formData)
        {
            if (!ModelState.IsValid)
            {
                using PizzaContext db = new();

                List<Category> categories = db.Categories.ToList();
                formData.categories = categories;

                formData.Ingredienti = IngredientsConverter.getIngredientsForSelect();

                return View("Create", formData);
            }

            using (PizzaContext db = new PizzaContext())
            {
                if(formData.IngredientiSelezionati != null)
                {
                    formData.pizza.Ingredients = new List<Ingredient>();

                    foreach(string ingredientId in formData.IngredientiSelezionati)
                    {
                        int IngredientIdSelected = int.Parse(ingredientId);

                        Ingredient ingredient = db.Ingredients.Where(ingredientDb => ingredientDb.IngredientId == IngredientIdSelected).FirstOrDefault();

                        formData.pizza.Ingredients.Add(ingredient);
                    }
                }

                db.Pizzas.Add(formData.pizza);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(string nome)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizza = db.Pizzas.Where(p => p.nome == nome).Include(c => c.Category).Include(c => c.Ingredients).FirstOrDefault();

                if (pizza == null)
                {
                    return NotFound("La pizza con il nome cercato non è disponibile");
                }

                List<Category> categories = db.Categories.ToList();
                CategoryPizzaView Modello = new();
                Modello.pizza = pizza;
                Modello.categories = categories;

                List<Ingredient> IngredientList = db.Ingredients.ToList();
                List<SelectListItem> ListForSelect = new();

                foreach(Ingredient ingredient in IngredientList)
                {
                    bool selected = pizza.Ingredients.Any(SelectedIngredient => SelectedIngredient.IngredientId == ingredient.IngredientId);

                    SelectListItem select = new() { Text = ingredient.Name, Value = ingredient.IngredientId.ToString(), Selected = selected };
                    ListForSelect.Add(select);
                }

                Modello.Ingredienti = ListForSelect;

                return View("Update", Modello);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CategoryPizzaView formData)
        {
            if (!ModelState.IsValid)
            {
                using PizzaContext db = new();

                List<Category> categories = db.Categories.ToList();
                formData.categories = categories;

                return View("Update", formData);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizza = db.Pizzas.Where(p => p.nome == formData.pizza.nome).Include(c => c.Ingredients).FirstOrDefault();

                if (pizza != null)
                {
                    pizza.descrizione = formData.pizza.descrizione;
                    pizza.prezzo = formData.pizza.prezzo;
                    pizza.foto = formData.pizza.foto;
                    pizza.CategoryId = formData.pizza.CategoryId;

                    pizza.Ingredients.Clear();

                    if (formData.IngredientiSelezionati != null)
                    {
                        foreach (string ingredientId in formData.IngredientiSelezionati)
                        {
                            int ingredientIdSelected = int.Parse(ingredientId);

                            Ingredient ingredient = db.Ingredients.Where(ingredientId =>ingredientId.IngredientId== ingredientIdSelected).FirstOrDefault();

                            pizza.Ingredients.Add(ingredient);
                        }
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("La pizza non è stata trovata");
                }
 
            }

        }

        [HttpPost]
        public IActionResult Remove(string nome)
        {

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizza = (from p in db.Pizzas
                               where p.nome == nome
                               select p).FirstOrDefault();

                db.Remove(pizza);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
