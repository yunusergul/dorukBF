using System;

namespace OrderArrayApi.Models
{
    public class Downtime
    {
        public required string Reason { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}