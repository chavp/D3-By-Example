using D3_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D3_Learning.Controllers
{
    public class D3Controller : Controller
    {
        //
        // GET: /D3/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InteractionAndTransitions()
        {
            return View();
        }

        public ActionResult WorkingWithArrays()
        {
            return View();
        }
        public ActionResult FilteringWithData()
        {
            return View();
        }
        public ActionResult UsingQuantitativeScales()
        {
            return View();
        }
        public ActionResult PlayingWithAxes()
        {
            return View();
        }
        public ActionResult TransitionWithStyle()
        {
            return View();
        }

        public JsonResult GetServiceStatus()
        {
            var results = new List<ServiceStatusView>
            {
                new ServiceStatusView
                {
                    Name = "123",
                    Status = Models.ServiceStatus.PlannedWork,
                },

                new ServiceStatusView
                {
                    Name = "456",
                    Status = Models.ServiceStatus.PlannedWork,
                },

                new ServiceStatusView
                {
                    Name = "7",
                    Status = Models.ServiceStatus.GoodService,
                },

                new ServiceStatusView
                {
                    Name = "ACE",
                    Status = Models.ServiceStatus.PlannedWork,
                },

                new ServiceStatusView
                {
                    Name = "BDFM",
                    Status = Models.ServiceStatus.PlannedWork,
                },
            };

            return Json(results, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMeanDailyPlazaTraffic()
        {
            var results = new List<PlazaTrafficView>
            {
                new PlazaTrafficView
                {
                    Name = "Robert F. Kennedy Bridge Bronx Plaza",
                    Count = 26774,
                },

                new PlazaTrafficView
                {
                    Name = "Robert F. Kennedy Bridge Manhattan Plaza",
                    Count = 18163,
                },

                new PlazaTrafficView
                {
                    Name = "Bronx-Whitestone Bridge",
                    Count = 31343,
                },

                new PlazaTrafficView
                {
                    Name = "Henry Hudson Bridge",
                    Count = 9864,
                },

                new PlazaTrafficView
                {
                    Name = "Marine Parkway-Gil Hodges Memorial Bridge",
                    Count = 3806,
                },

                new PlazaTrafficView
                {
                    Name = "Cross Bay Veterans Memorial Bridge",
                    Count = 4577,
                },

                new PlazaTrafficView
                {
                    Name = "Queens Midtown Tunnel",
                    Count = 13831,
                },

                new PlazaTrafficView
                {
                    Name = "Brooklyn-Battery Tunnel",
                    Count = 6900,
                },

                new PlazaTrafficView
                {
                    Name = "Throgs Neck Bridge",
                    Count = 25262,
                },

                new PlazaTrafficView
                {
                    Name = "Verrazane-Narrows Bridge",
                    Count = 18275,
                },
            };
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBusBreakdownAccidentAndInjuryView()
        {
            var results = new List<BusBreakdownAccidentAndInjuryView>
            {
                 new BusBreakdownAccidentAndInjuryView
                {
                    CollisionWithInjury = 3.2,
                    DistBetweenFail = 3924.0,
                    CustomerAccidentRate = 2.12,
                },
            };

            var ran = new Random();
            for (int i = 0; i < 100; i++)
            {
                var collisionWithInjury = 3 * ran.NextDouble();
                var distBetweenFail = 9999 * ran.NextDouble();
                var customerAccidentRate = 5 * ran.NextDouble();
                results.Add(new BusBreakdownAccidentAndInjuryView
                {
                    CollisionWithInjury = collisionWithInjury,
                    DistBetweenFail = distBetweenFail,
                    CustomerAccidentRate = customerAccidentRate,
                });
            }
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTurnstileTrafficView()
        {
            var results = new TurnstileTrafficListView();

            var ran = new Random();
            for (DateTime i = DateTime.Now.Date; i <= DateTime.Now.Date.AddDays(1); i = i.AddHours(1))
            {
                var c = 100 * ran.NextDouble();
                results.GrandCentral.Add(new TurnstileTrafficView
                {
                    Count =c,
                    Time = i.Ticks,
                });

                c = 100 * ran.NextDouble();
                results.TimesSquare.Add(new TurnstileTrafficView
                {
                    Count = c,
                    Time = i.Ticks,
                });
            }

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubwayWaits()
        {
            var results = new {
                SubwayWaitStatistics = new List<SubwayWaitStatisticView>(),
                SubwayWaits = new List<SubwayWaitView>(),
            };

            var ran = new Random();
            for (int i = 1; i <= 12; i++)
            {
                var subwayWaitStatisticView = new SubwayWaitStatisticView
                {
                    LineID = string.Format("{0}_Line", i),
                    LineName = string.Format("{0} Line", i),
                };

                results.SubwayWaitStatistics.Add(subwayWaitStatisticView);

                var subwayWaits = new List<SubwayWaitView>();
                for (int j = 0; j < 30; j++)
                {
                    var subwayWaitView = new SubwayWaitView
                    {
                        LineID = subwayWaitStatisticView.LineID,
                        LineName = subwayWaitStatisticView.LineName,
                        LatePercent = 100 * ran.NextDouble(),
                        Month = i,
                    };

                    subwayWaits.Add(subwayWaitView);
                }
                results.SubwayWaits.AddRange(subwayWaits);
                subwayWaitStatisticView.Mean = subwayWaits.Average(d => d.LatePercent);
            }
            return Json(results.SubwayWaits, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubwayWaitStatistics()
        {
            var results = new
            {
                SubwayWaitStatistics = new List<SubwayWaitStatisticView>(),
                SubwayWaits = new List<SubwayWaitView>(),
            };

            var ran = new Random();
            for (int i = 1; i <= 12; i++)
            {
                var subwayWaitStatisticView = new SubwayWaitStatisticView
                {
                    LineID = string.Format("{0}_Line", i),
                    LineName = string.Format("{0} Line", i),
                };

                results.SubwayWaitStatistics.Add(subwayWaitStatisticView);

                var subwayWaits = new List<SubwayWaitView>();
                for (int j = 0; j < 30; j++)
                {
                    var subwayWaitView = new SubwayWaitView
                    {
                        LineID = subwayWaitStatisticView.LineID,
                        LineName = subwayWaitStatisticView.LineName,
                        LatePercent = 100 * ran.NextDouble(),
                        Month = i,
                    };

                    subwayWaits.Add(subwayWaitView);
                }
                results.SubwayWaits.AddRange(subwayWaits);
                subwayWaitStatisticView.Mean = subwayWaits.Average(d => d.LatePercent);
            }
            return Json(results.SubwayWaitStatistics, JsonRequestBehavior.AllowGet);
        }
    }
}
