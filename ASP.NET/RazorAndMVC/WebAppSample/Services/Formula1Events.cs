using EventViews.Models;

namespace WebAppSample.Services;

public class Formula1Events : IEventsService
{
   private List<Event>? _events;
   public IEnumerable<Event> Events => _events ??= GetEvents();

   private List<Event> GetEvents() =>
      new()
      {
         new Event("GP Bahrain, Sachir", new DateTime(2021, 3, 28)),
         new Event("GP Emilia Romagna, Imola", new DateTime(2021, 4, 18)),
         new Event("GP Portugal, Portimao", new DateTime(2021, 5, 2)),
         new Event("GP Spain, Barcelona", new DateTime(2021, 5, 9)),
         new Event("GP Monaco, Monte Carlo", new DateTime(2021, 5, 23)),
         new Event("GP Azerbaijan, Baku", new DateTime(2021, 6, 6)),
         new Event("GP Canada, Montreal", new DateTime(2021, 6, 13)),
         new Event("GP France, Le Castellet", new DateTime(2021, 6, 20)),
         new Event("GP Styria, Spielberg", new DateTime(2021, 6, 27)),
         new Event("GP Austria, Spielberg", new DateTime(2021, 7, 4)),
         new Event("GP Great Britain, Silverstone", new DateTime(2021, 7, 18)),
         new Event("GP Hungary, Budapest", new DateTime(2021, 8, 1)),
         new Event("GP Belgium, Spa-Francorchamps", new DateTime(2021, 8, 29)),
         new Event("GP Netherlands, Zandvoort", new DateTime(2021, 9, 5)),
         new Event("GP Italy, Monza", new DateTime(2021, 9, 12)),
         new Event("GP Russia, Sotschi", new DateTime(2021, 9, 26)),
         new Event("GP Turkey", new DateTime(2021, 10, 10)),
         new Event("GP United States, Austin", new DateTime(2021, 10, 24)),
         new Event("GP Mexico, Mexico-City", new DateTime(2021, 11, 7)),
         new Event("GP Brazil, Sao Paulo", new DateTime(2021, 11, 7)),
         new Event("GP Qatar, Lusail", new DateTime(2021, 11, 21)),
         new Event("GP Saudi Arabia, Dschidda", new DateTime(2021, 12, 5)),
         new Event("GP Abu Dhabi", new DateTime(2021, 12, 12)),
         new Event("GP Bahrain, Sachir", new DateTime(2022, 3, 20)),
         new Event("GP Saudi Arabia, Dschidda", new DateTime(2022, 3, 27)),
         new Event("GP Australia, Melbourne", new DateTime(2022, 4, 8)),
         new Event("GP Emilia Romagna, Imola", new DateTime(2022, 4, 24)),
         new Event("GP Miami", new DateTime(2022, 5, 8)),
         new Event("GP Spain, Barcelona", new DateTime(2022, 5, 22)),
         new Event("GP Monaco, Monte Carlo", new DateTime(2022, 5, 29)),
         new Event("GP Azerbaijan, Baku", new DateTime(2022, 6, 12)),
         new Event("GP Canada, Montreal", new DateTime(2022, 6, 19)),
         new Event("GP Great Britain, Silverstone", new DateTime(2022, 7, 3)),
         new Event("GP Austria, Spielberg", new DateTime(2022, 7, 10)),
         new Event("GP France, Le Castellet", new DateTime(2022, 7, 24)),
         new Event("GP Hungary, Budapest", new DateTime(2022, 8, 31)),
         new Event("GP Belgium, Spa-Francorchamps", new DateTime(2022, 8, 28)),
         new Event("GP Netherlands, Zandvoort", new DateTime(2022, 9, 4)),
         new Event("GP Italy, Monza", new DateTime(2022, 9, 11)),
         new Event("GP Russia, Sotschi", new DateTime(2022, 9, 25)),
         new Event("GP Singapore", new DateTime(2022, 10, 2)),
         new Event("GP Japan, Suzuka", new DateTime(2022, 10, 9)),
         new Event("GP United States, Austin", new DateTime(2022, 10, 23)),
         new Event("GP Mexico, Mexico-City", new DateTime(2022, 10, 30)),
         new Event("GP Brazil, Sao Paulo", new DateTime(2022, 11, 13)),
         new Event("GP Abu Dhabi", new DateTime(2022, 11, 20))
      };
}