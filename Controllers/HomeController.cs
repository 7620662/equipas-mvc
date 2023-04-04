using equipas_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace equipas_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        private static IList<Liga> equipas = new List<Liga>()
        { 
            new Liga()
            {
                Id = 1,
                Equipa = "Joaquim FC",
                Pontos = 5,
                Jogos = 2,
                Cidade = "Aveiro"
            },
            new Liga()
            {
                Id = 2,
                Equipa = "Marco Paulo FC",
                Pontos = 13,
                Jogos = 21,
                Cidade = "Biseu"
            },
            new Liga()
            {
                Id = 3,
                Equipa = "Porto FC",
                Pontos = 2,
                Jogos = 8,
                Cidade = "Porto"
            },
        };
        public IActionResult Index()
        {
            return View(equipas.OrderBy(i => i.Equipa));
        }

        public IActionResult Edit(long id)
        {
            return View(equipas.Where(i => i.Id == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Liga updatedEquipa)
        {
            equipas.Remove(equipas.Where(i => i.Id == updatedEquipa.Id).First());
            equipas.Add(updatedEquipa);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Liga newEquipa)
        {
            equipas.Add(newEquipa);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            return View(equipas.Where(i => i.Id == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Liga deletedEquipa)
        {
            equipas.Remove(equipas.Where(i => i.Id == deletedEquipa.Id).First());
            return RedirectToAction("Index");
        }

        public IActionResult Details(long id)
        {
            return View(equipas.Where(i => i.Id == id).First());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}