using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D3_Learning.Models
{
    public class RevenueViewModel
    {
        public int ID { get; set; }
        public DateTime Day { get; set; }
        public string DayFormat
        {
            get
            {
                return Day.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            }
            protected set
            {

            }
        }
        public double Amount { get; set; }
        public double Amount2 { get; set; }
        public double Amount3 { get; set; }
        public double Amount4 { get; set; }
    }
}