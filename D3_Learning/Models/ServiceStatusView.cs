using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D3_Learning.Models
{
    public class ServiceStatusView
    {
        public string Name { get; set; }
        public ServiceStatus Status { get; set; }
    }

    public enum ServiceStatus
    {
        PlannedWork, GoodService
    }
}