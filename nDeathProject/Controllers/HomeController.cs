using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using nDeathProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                List<Point> values = new List<Point>();
                int yValue = 0;
                for (int i = chart.LowerBorder; i < chart.UpperBorder; i += chart.Step)
                {
                    yValue = chart.ACoeff * (i * i) + chart.BCoeff * i + chart.CCoeff;
                    values.Add(new Point(i, yValue));
                }
                return Json(new SelectList(values, "X", "Y"));
            }
            return Json(new object());
            
            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
