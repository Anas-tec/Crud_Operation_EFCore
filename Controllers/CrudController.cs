using CrudTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Controllers
{
    public class CrudController : Controller
    {
        private readonly AppDbContext _context;
        public CrudController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var infos = _context.Informations.ToList();
            return View(infos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Information infos)
        {
            if (!ModelState.IsValid)
            {
                return View(infos);
            }
            else
            {
                _context.Informations.Add(infos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public IActionResult Edit(int id)
        {
            var infos = _context.Informations.Find(id);
            if (infos == null)
            {
                //ViewBag.Message = "";
                TempData["ErrorMessage"] = "No existing records found!";
                return RedirectToAction("Index");
            }
            return View(infos);
        }

        [HttpPost]
        public IActionResult Edit(Information info)
        {
            var existing = _context.Informations.Find(info.Id);

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Check the records !";
                return RedirectToAction("Edit");
            }
            else if (ModelState.IsValid) 
            {
                _context.Entry(existing).CurrentValues.SetValues(info);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var infos = _context.Informations.Find(id);
            if (infos == null)
            {
                //ViewBag.Message = "";
                TempData["ErrorMessage"] = "Id is wrong!";
                return RedirectToAction("Index");
            }
            return View(infos);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Information info, string action)
        {
            var existing = _context.Informations.Find(info.Id);
            _context.Informations.Remove(existing);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /*   [HttpPost]
           public IActionResult Edit(Information infos, string action)
           {
               var existing = _context.Informations.FirstOrDefault(p => p.Id == infos.Id);
               if (existing == null)
               {
                   ViewBag.Message = "No existing records found";
               }
               if (action == "update")
               {
                   if (!ModelState.IsValid)
                   {
                       return View("Check all are filled and id is correct");
                   }
                   _context.Entry(existing).CurrentValues.SetValues(infos);
                   _context.SaveChanges();
               }
               else if (action == "delete")
               {
                   _context.Informations.Remove(existing);
                   _context.SaveChanges();
               }
               return RedirectToAction("Index");
           } */
    }
}
    