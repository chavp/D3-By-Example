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

        public ActionResult Stack()
        {
            return View();
        }

        public ActionResult StackBar()
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

        public JsonResult GetTimesheetCostDays()
        {
            var results = new List<TimesheetCostDay>();

            var revRandom = new Random(DateTime.Now.Second);
            var randomPhase = new Random(DateTime.Now.Second);

            var max = 356 * 2;
            var startDate = new DateTime(2014, 1, 1).Date;
            var maxDate = startDate.AddDays(max);

            while (startDate < maxDate)
            {
                var rev = new TimesheetCostDay
                {
                    Day = startDate,
                };


                var cos = Convert.ToDecimal(revRandom.NextDouble() * 300);
                var phase = randomPhase.Next(4);
                switch (phase)
                {
                    case 0:
                        rev.PreSaleCost = cos;
                        break;
                    case 1:
                        rev.ImplementCost = cos;
                        break;
                    case 2:
                        rev.OperationCost = cos;
                        break;
                    case 3:
                        rev.WarrantyCost = cos;
                        break;
                    default:
                        break;
                }

                startDate = startDate.AddDays(1);

                results.Add(rev);
            }

            // Cumulative PreSaleCost
            var preSaleAmounts = new decimal[results.Count];
            var implementAmounts = new decimal[results.Count];
            var operationAmounts = new decimal[results.Count];
            var warrantyAmounts = new decimal[results.Count];
            for (int i = 0; i < results.Count; i++)
            {
                preSaleAmounts[i] = results[i].PreSaleCost;
                implementAmounts[i] = results[i].ImplementCost;
                operationAmounts[i] = results[i].OperationCost;
                warrantyAmounts[i] = results[i].WarrantyCost;
            }
            var cumPreSaleAmounts = preSaleAmounts.CumulativeSum().ToArray();
            var cumImplementAmounts = implementAmounts.CumulativeSum().ToArray();
            var cumOperationAmounts = operationAmounts.CumulativeSum().ToArray();
            var cumWarrantyAmounts = warrantyAmounts.CumulativeSum().ToArray();
            for (int i = 0; i < results.Count; i++)
            {
                results[i].PreSaleCost = cumPreSaleAmounts[i];
                results[i].ImplementCost = cumImplementAmounts[i];
                results[i].OperationCost = cumOperationAmounts[i];
                results[i].WarrantyCost = cumWarrantyAmounts[i];
            }

            return Json(results, JsonRequestBehavior.AllowGet);
        }


    }

    public static class Caculator
    {
        public static IEnumerable<decimal> CumulativeSum(this IEnumerable<decimal> numbers)
        {
            decimal summedNumber = 0;

            foreach (decimal number in numbers)
            {
                summedNumber = summedNumber + number;
                yield return summedNumber;
            }
        }
    }
}
