using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D3_Learning.Models
{
    public class TimesheetCostDay
    {
        public DateTime Day { get; set; }
        public decimal PreSaleCost { get; set; }
        public decimal ImplementCost { get; set; }
        public decimal OperationCost { get; set; }
        public decimal WarrantyCost { get; set; }

        public string DayFormat
        {
            get
            {
                return Day.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            }
            protected set
            {

            }
        }
    }
}