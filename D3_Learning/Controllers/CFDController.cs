using D3_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D3_Learning.Controllers
{
    public class CFDController : Controller
    {
        //
        // GET: /CFD/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTimeSeriesData()
        {
            var results = new List<RevenueViewModel>
            {
                
            };

            var revRandom = new Random(DateTime.Now.Second);
            for (int i = 0; i < 100; i++)
            {
                var rev = new RevenueViewModel 
                { 
                    ID = i + 1,
                    Day = DateTime.Now.AddDays(i),
                    Amount = i * 10,
                    Amount2 = i * 20,
                    Amount3 = i * 30,
                    Amount4 = i * 60,
                };

                results.Add(rev);
            }

            return Json(results, JsonRequestBehavior.AllowGet);
        }

    }
}
