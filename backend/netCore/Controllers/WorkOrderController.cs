using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using OrderArrayApi.Models;

namespace OrderArrayApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class WorkOrderController : ControllerBase
   {
       private readonly List<WorkOrder> workOrders = new List<WorkOrder>
       {
            new WorkOrder { OrderNumber = "1001", StartTime = DateTime.Parse("2017-01-01 08:00:00"), EndTime = DateTime.Parse("2017-01-01 16:00:00") },
            new WorkOrder { OrderNumber = "1002", StartTime = DateTime.Parse("2017-01-01 16:00:00"), EndTime = DateTime.Parse("2017-01-02 00:00:00") },
            new WorkOrder { OrderNumber = "1003", StartTime = DateTime.Parse("2017-01-02 00:00:00"), EndTime = DateTime.Parse("2017-01-02 08:00:00") },
            new WorkOrder { OrderNumber = "1004", StartTime = DateTime.Parse("2017-01-02 08:00:00"), EndTime = DateTime.Parse("2017-01-02 16:00:00") },

       };

       private readonly List<Downtime> downtimes = new List<Downtime>
       {
            new Downtime { Reason = "Mola", StartTime = DateTime.Parse("2017-01-01 10:00:00"), EndTime = DateTime.Parse("2017-01-01 10:10:00") },
            new Downtime { Reason = "Ariza", StartTime = DateTime.Parse("2017-01-01 10:30:00"), EndTime = DateTime.Parse("2017-01-01 11:00:00") },
            new Downtime { Reason = "Mola", StartTime = DateTime.Parse("2017-01-01 12:00:00"), EndTime = DateTime.Parse("2017-01-01 12:30:00") },
            new Downtime { Reason = "Mola", StartTime = DateTime.Parse("2017-01-01 14:00:00"), EndTime = DateTime.Parse("2017-01-01 14:10:00") },
       };

       [HttpGet("durations")]
       public ActionResult<IEnumerable<WorkOrderDuration>> GetWorkOrderDurations()
       {
           var workOrderDurations = new List<WorkOrderDuration>();

           foreach (var workOrder in workOrders)
           {
               var duration = new WorkOrderDuration
               {
                   OrderNumber = workOrder.OrderNumber
               };

               var relevantDowntimes = downtimes.Where(d =>
                   (d.StartTime >= workOrder.StartTime && d.StartTime < workOrder.EndTime) ||
                   (d.EndTime > workOrder.StartTime && d.EndTime <= workOrder.EndTime) ||
                   (d.StartTime <= workOrder.StartTime && d.EndTime >= workOrder.EndTime)
               );

               foreach (var downtime in relevantDowntimes)
               {
                   var start = downtime.StartTime < workOrder.StartTime ? workOrder.StartTime : downtime.StartTime;
                   var end = downtime.EndTime > workOrder.EndTime ? workOrder.EndTime : downtime.EndTime;
                   var minutes = (int)(end - start).TotalMinutes;

                   if (!duration.Durations.ContainsKey(downtime.Reason))
                       duration.Durations[downtime.Reason] = 0;

                   duration.Durations[downtime.Reason] += minutes;
               }

               duration.Total = duration.Durations.Values.Sum();
               workOrderDurations.Add(duration);
           }

           return Ok(workOrderDurations);
       }
   }
}