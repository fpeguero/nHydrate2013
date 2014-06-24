using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentScheduler;

namespace OSIS.PEPPAM.Mvc.Infrastructure.ScheduleTask
{
    public class TaskRegistry : Registry
    {
        public TaskRegistry()
        {
           // Schedule<ScheduleTask>().ToRunNow();
        }
    }
}