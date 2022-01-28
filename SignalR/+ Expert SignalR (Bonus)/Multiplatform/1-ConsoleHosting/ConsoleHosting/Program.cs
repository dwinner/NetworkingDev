using System;
using Microsoft.Owin.Hosting;

namespace ConsoleHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:11111"))
            {
                Console.WriteLine("Server running at http://localhost:11111");
                Console.ReadLine();
            }
        }
    }
}
