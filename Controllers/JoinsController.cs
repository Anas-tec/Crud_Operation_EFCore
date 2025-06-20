﻿using CrudTest.Models;
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
            var flatData = await (from state in _context.States
                                  join country in _context.Countries
                                  on state.CountryId equals country.CountryId
                                  select new CountryStateViewModel
                                  {
                                      CountryName = country.Name,
                                      StateName = state.Name
                                  }).ToListAsync();

            // Group by CountryName and create grouped data with states combined as a string
            var groupedData = flatData
                .GroupBy(x => x.CountryName)
                .Select(g => new
                {
                    CountryName = g.Key,
                    States = string.Join(", ", g.Select(x => x.StateName))
                }).ToList();

            // Passing groupedData to ViewBag (since groupedData is anonymous type)
            ViewBag.GroupedCountryStates = groupedData;

            return View(flatData);

            /*
            var groupedData = await (from state in _context.States
                                     join country in _context.Countries
                                     on state.CountryId equals country.CountryId
                                     group state by country.Name into countryGroup
                                     select new CountryStateViewModel
                                     {
                                         CountryName = countryGroup.Key,
                                         StateNames = countryGroup.Select(s => s.Name).ToList()
                                     }).ToListAsync();

            return View(groupedData);*/
        }




    /*
             public async Task<IActionResult> Index()
             {
                 var countries = await _context.Countries.ToListAsync();
                 ViewBag.Countries = countries;
                 return View();
             }

             public async Task<IActionResult> CountryStateList()
             {
                 var query = await _context.States
                     .Include(s => s.Country)
                     .Select(s => new CountryStateViewModel
                     {
                         CountryName = s.Country.Name,
                         StateName = s.Name
                     })
                     .ToListAsync();

                 return View(query);
             }

               public async Task<JsonResult> GetStates(int CountryId)
              {
                  var states = await _context.States
                      .Where(s => s.CountryId == CountryId)
                      .Select(s => new { s.StateId, s.Name })
                      .ToListAsync();
                  return Json(states);
              }*/

    /* Working table model
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
                */
    //        public IActionResult Index() { return View(); }

}

}


