using System;
using System.Collections.Generic;

namespace OrderArrayApi.Models
{
    public class WorkOrderDuration
    {
        public required string OrderNumber { get; set; }
        public Dictionary<string, int> Durations { get; set; } = new Dictionary<string, int>();
        public int Total { get; set; }
    }
}