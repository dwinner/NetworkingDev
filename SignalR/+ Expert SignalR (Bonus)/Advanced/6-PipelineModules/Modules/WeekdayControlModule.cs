using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.SignalR.Hubs;

namespace PipelineModules.Modules
{
    public class WeekdayControlModule : HubPipelineModule
    {
        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            var onlyAttr = context.MethodDescriptor.Attributes.OfType<OnlyOnAttribute>().FirstOrDefault();
            if (onlyAttr != null)
            {
                var today = DateTime.Today.DayOfWeek;
                var todayIsValidDay = onlyAttr.Weekdays & (Weekday)(1 << (int)today);
                var canContinue = todayIsValidDay != 0;
                if (!canContinue)
                {
                    Debug.WriteLine("Called " + context.MethodDescriptor.Name + "() on server, but today is not allowed");
                }
                return canContinue;
            }
            return true;
        }
    }
}