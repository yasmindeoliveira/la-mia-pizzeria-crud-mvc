using LaMiaPizzeriaEfPost.Database;
using LaMiaPizzeriaEfPost.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizzas.Add(formData);
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
