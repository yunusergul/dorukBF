using System;

namespace OrderArrayApi.Models
{
    public class WorkOrder
    {
        public required string OrderNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}