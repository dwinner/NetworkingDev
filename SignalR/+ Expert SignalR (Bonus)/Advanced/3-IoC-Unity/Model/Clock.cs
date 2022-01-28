using System;
using System.Diagnostics;

namespace IocUnity.Model
{
    public class Clock : IClock
    {
        private readonly int _clockId;
        public Clock()
        {
            _clockId = new Random().Next(100000);
            Debug.WriteLine("    Creating clock");
        }
        public string GetCurrentDateTime()
        {
            return "[Clock#" + _clockId + "] " + DateTime.Now.ToString("F");
        }

        public void Dispose()
        {
            Debug.WriteLine("    Disposing clock");
        }
    }
}