using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D3_Learning.Models
{
    public class TurnstileTrafficView
    {
        public double Count { get; set; }
        public long Time { get; set; }
    }

    public class TurnstileTrafficListView
    {
        public TurnstileTrafficListView()
        {
            GrandCentral = new List<TurnstileTrafficView>();
            TimesSquare = new List<TurnstileTrafficView>();
        }

        public IList<TurnstileTrafficView> GrandCentral { get; set; }
        public IList<TurnstileTrafficView> TimesSquare { get; set; }
    }
}