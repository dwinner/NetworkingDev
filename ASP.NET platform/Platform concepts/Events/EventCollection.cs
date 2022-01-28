using System.Collections.Generic;
using System.Diagnostics;

namespace Events
{
   public static class EventCollection
   {
      private static readonly List<EventDescription> EventDescriptions = new List<EventDescription>();

      public static IEnumerable<EventDescription> Events
      {
         get { return EventDescriptions; }
      }

      public static void Add(EventSource level, string type)
      {
         EventDescriptions.Add(new EventDescription { Source = level, Type = type });
         Debug.WriteLine("Event: {0}, {1}", level, type);
      }
   }

   public enum EventSource
   {
      Application,
      Page,
      MasterPage,
      Control
   }

   public class EventDescription
   {
      public EventSource Source { get; set; }

      public string Type { get; set; }
   }
}