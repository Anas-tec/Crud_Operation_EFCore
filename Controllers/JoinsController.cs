using CrudTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.Controllers
{
    public class JoinsController : Controller
    {

        private readonly AppDbContext _context;
         public JoinsController(AppDbContext context)
         {
             _context = context;
         }

         public async Task<IActionResult> Index()
         {
            var countries = await _context.Countries.ToListAsync();
            ViewBag.Countries = countries; 
            return View(countries);
         }
         [HttpGet]
         public async Task<JsonResult> GetStates(int countryId)
         {
             var states = await _context.States
                 .Where(s => s.CountryId == countryId)
                 .ToListAsync();
             return Json(states);
         }

        [HttpGet]
        public async Task<JsonResult> GetCities(int stateId)
        {
            var cities = await _context.Cities
                .Where(c => c.StateId == stateId)
                .ToListAsync();
            return Json(cities);
        }

        // public IActionResult Index() { return View(); }

    }

}


