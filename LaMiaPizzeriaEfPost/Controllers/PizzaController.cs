using LaMiaPizzeriaEfPost.Database;
using LaMiaPizzeriaEfPost.Models;
using Microsoft.AspNetCore.Mvc;
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
                Pizza pizza = db.Pizzas.Where(p => p.nome == nome).Include(c => c.Category).FirstOrDefault();

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

                return View("Create", formData);
            }

            using (PizzaContext db = new PizzaContext())
            {
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
                Pizza pizza = (from p in db.Pizzas
                               where p.nome == nome
                               select p).FirstOrDefault();

                if (pizza != null)
                {
                    return View(pizza);
                }

                return NotFound("La pizza con il nome cercato non è disponibile");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", formData);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizza = (from p in db.Pizzas
                               where p.nome == formData.nome
                               select p).FirstOrDefault();

                pizza.descrizione = formData.descrizione;
                pizza.prezzo = formData.prezzo;
                pizza.foto = formData.foto;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
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
