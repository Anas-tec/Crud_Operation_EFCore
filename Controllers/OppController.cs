using CrudTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Runtime.CompilerServices;
using static System.Collections.Specialized.BitVector32;

namespace CrudTest.Controllers
{
    public class OppController : Controller
    {
        
        [HttpGet]
        public IActionResult Stu(StudentMarks model, string actiontype)
        {
            
            if (actiontype == "cal")
            {
                model.Sub1Result = model.Sub1 >= 35 ? "Pass" : "Fail";
                model.Sub2Result = model.Sub2 >= 35 ? "Pass" : "Fail";
                model.Sub3Result = model.Sub3 >= 35 ? "Pass" : "Fail";
                model.Sub4Result = model.Sub4 >= 35 ? "Pass" : "Fail";
                model.Sub5Result = model.Sub5 >= 35 ? "Pass" : "Fail";
                model.Sub6Result = model.Sub6 >= 35 ? "Pass" : "Fail";
                model.Total = model.Total + model.Sub1 + model.Sub2 + model.Sub3 + model.Sub4 + model.Sub5 + model.Sub6;
                model.Percentage = Math.Round(model.Total / 6.0, 2);
                model.Gpa = Math.Round(model.Percentage / 10, 2);
                if (model.Sub1 < 35 || model.Sub2 < 35 || model.Sub3 < 35 || model.Sub4 < 35 || model.Sub5 < 35 || model.Sub6 < 35)
                {
                    model.Result = "Fail";
                }
                else
                {
                    if (model.Percentage >= 80)
                    {
                        model.Result = "Great";
                    }
                    else if (model.Percentage >= 60)
                    {
                        model.Result = "Good";
                    }
                    else
                    {
                        model.Result = "OK,Pass";
                    }
                }
            }
            
            return View(model);
        }
        /*
        [HttpPost]
        public IActionResult Stu(StudentMarks model, string action)
        {
            if (action == "cal")
            {
                
                model.Total = 90;
                model.Percentage = 100;
                return View(model);
            }
            else
            {
                return View(model);
            }
        }*/
        /*public IActionResult Stu(StudentMarks model, string action)
        {

            if (action == "calculate")
            {
                model.Total = model.Sub1 + model.Sub2 + model.Sub3 + model.Sub4 + model.Sub5 + model.Sub6;
                model.Percentage = (model.Total / 600) * 100;
                return View(model);
            }
            else {
                
                return View(null);
            }
            
        }*/

        //[HttpPost]
        //public IActionResult Stu(StudentMarks modell)
        //{
        //    modell.Total=modell.Sub1+modell.Sub2+modell.Sub3+modell.Sub4+modell.Sub5+modell.Sub6;
        //    modell.Percentage = modell.Total;
        //    return View(modell);
        //}
    }
}
