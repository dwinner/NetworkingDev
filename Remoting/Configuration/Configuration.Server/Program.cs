/**
 * Конфигурация сервера
 */

using System;
using System.Runtime.Remoting;

namespace Configuration.Server
{
   internal static class Program
   {
      private const string DefaultRmiConfig = "Configuration.Server.exe.config";

      private static void Main()
      {
         RemotingConfiguration.Configure(DefaultRmiConfig, false);
         Console.WriteLine("Application: {0}", RemotingConfiguration.ApplicationName);
         ShowActivatedServiceTypes();
         ShowWellKnownServiceTypes();
         Console.WriteLine("Press return to exit");
         Console.ReadLine();
      }

      private static void ShowWellKnownServiceTypes()
      {
         WellKnownServiceTypeEntry[] serviceTypeEntries = RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
         foreach (WellKnownServiceTypeEntry typeEntry in serviceTypeEntries)
         {
            Console.WriteLine("Assembly: {0}", typeEntry.AssemblyName);
            Console.WriteLine("Mode: {0}", typeEntry.Mode);
            Console.WriteLine("URI: {0}", typeEntry.ObjectUri);
            Console.WriteLine("Type: {0}", typeEntry.TypeName);
         }
      }

      private static void ShowActivatedServiceTypes()
      {
         ActivatedServiceTypeEntry[] entries = RemotingConfiguration.GetRegisteredActivatedServiceTypes();
         foreach (ActivatedServiceTypeEntry entry in entries)
         {
            Console.WriteLine("Assembly: {0}", entry.AssemblyName);
            Console.WriteLine("Type: {0}", entry.TypeName);
         }
      }
   }
}