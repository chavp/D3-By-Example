using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D3_Learning.Models
{
    public class SubwayWaitStatisticView
    {
        public string LineID { get; set; }
        public string LineName { get; set; }

        public double Mean { get; set; }
    }
}