using System;

namespace PipelineModules.Modules
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class OnlyOnAttribute : Attribute
    {
        private readonly Weekday _weekdays;
        public OnlyOnAttribute(Weekday weekdays)
        {
            _weekdays = weekdays;
        }

        public Weekday Weekdays
        {
            get { return _weekdays; }
        }
    }
}