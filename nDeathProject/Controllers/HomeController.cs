using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using nDeathProject.Models;

namespace nDeathProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetDataPoints([Bind("ACoeff,BCoeff,CCoeff,Step,LowerBorder,UpperBorder")]ChartEntity chart)
        {
            if (chart.LowerBorder > chart.UpperBorder)
            {
                ModelState.AddModelError("Error", "Border Error");
            }
            if (ModelState.IsValid)
            {
                Dictionary<int, int> values = new Dictionary<int, int>();
                int yValue = 0;
                for (int i = chart.LowerBorder; i < chart.UpperBorder; ++i)
                {
                    yValue = chart.ACoeff * (i * i) + chart.BCoeff * i + chart.CCoeff;
                    values.Add(i, yValue);
                }
                return Json(values);
            }
            return Json(new object());
            
            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
