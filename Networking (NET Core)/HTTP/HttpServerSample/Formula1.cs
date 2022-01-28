using System.Collections.Generic;

namespace HttpServerSample
{
   public class Formula1
   {
      private List<Racer>? _racers;
      public IEnumerable<Racer> GetChampions() => _racers ??= InitializeRacers();

      private static List<Racer> InitializeRacers() => new()
      {
         new Racer("Nino", "Farina", "Italy", 33, 5, new[] { 1950 }, new[] { "Alfa Romeo" }),
         new Racer("Alberto", "Ascari", "Italy", 32, 13, new[] { 1952, 1953 }, new[] { "Ferrari" }),
         new Racer("Juan Manuel", "Fangio", "Argentina", 51, 24, new[] { 1951, 1954, 1955, 1956, 1957 },
            new[] { "Alfa Romeo", "Maserati", "Mercedes", "Ferrari" }),
         new Racer("Mike", "Hawthorn", "UK", 45, 3, new[] { 1958 }, new[] { "Ferrari" }),
         new Racer("Phil", "Hill", "USA", 48, 3, new[] { 1961 }, new[] { "Ferrari" }),
         new Racer("John", "Surtees", "UK", 111, 6, new[] { 1964 }, new[] { "Ferrari" }),
         new Racer("Jim", "Clark", "UK", 72, 25, new[] { 1963, 1965 }, new[] { "Lotus" }),
         new Racer("Jack", "Brabham", "Australia", 125, 14, new[] { 1959, 1960, 1966 }, new[] { "Cooper", "Brabham" }),
         new Racer("Denny", "Hulme", "New Zealand", 112, 8, new[] { 1967 }, new[] { "Brabham" }),
         new Racer("Graham", "Hill", "UK", 176, 14, new[] { 1962, 1968 }, new[] { "BRM", "Lotus" }),
         new Racer("Jochen", "Rindt", "Austria", 60, 6, new[] { 1970 }, new[] { "Lotus" }),
         new Racer("Jackie", "Stewart", "UK", 99, 27, new[] { 1969, 1971, 1973 }, new[] { "Matra", "Tyrrell" }),
         new Racer("Emerson", "Fittipaldi", "Brazil", 143, 14, new[] { 1972, 1974 }, new[] { "Lotus", "McLaren" }),
         new Racer("James", "Hunt", "UK", 91, 10, new[] { 1976 }, new[] { "McLaren" }),
         new Racer("Mario", "Andretti", "USA", 128, 12, new[] { 1978 }, new[] { "Lotus" }),
         new Racer("Jody", "Scheckter", "South Africa", 112, 10, new[] { 1979 }, new[] { "Ferrari" }),
         new Racer("Alan", "Jones", "Australia", 115, 12, new[] { 1980 }, new[] { "Williams" }),
         new Racer("Keke", "Rosberg", "Finland", 114, 5, new[] { 1982 }, new[] { "Williams" }),
         new Racer("Niki", "Lauda", "Austria", 173, 25, new[] { 1975, 1977, 1984 }, new[] { "Ferrari", "McLaren" }),
         new Racer("Nelson", "Piquet", "Brazil", 204, 23, new[] { 1981, 1983, 1987 }, new[] { "Brabham", "Williams" }),
         new Racer("Ayrton", "Senna", "Brazil", 161, 41, new[] { 1988, 1990, 1991 }, new[] { "McLaren" }),
         new Racer("Nigel", "Mansell", "UK", 187, 31, new[] { 1992 }, new[] { "Williams" }),
         new Racer("Alain", "Prost", "France", 197, 51, new[] { 1985, 1986, 1989, 1993 },
            new[] { "McLaren", "Williams" }),
         new Racer("Damon", "Hill", "UK", 114, 22, new[] { 1996 }, new[] { "Williams" }),
         new Racer("Jacques", "Villeneuve", "Canada", 165, 11, new[] { 1997 }, new[] { "Williams" }),
         new Racer("Mika", "Hakkinen", "Finland", 160, 20, new[] { 1998, 1999 }, new[] { "McLaren" }),
         new Racer("Michael", "Schumacher", "Germany", 287, 91, new[] { 1994, 1995, 2000, 2001, 2002, 2003, 2004 },
            new[] { "Benetton", "Ferrari" }),
         new Racer("Fernando", "Alonso", "Spain", 314, 32, new[] { 2005, 2006 }, new[] { "Renault" }),
         new Racer("Kimi", "Räikkönen", "Finland", 330, 21, new[] { 2007 }, new[] { "Ferrari" }),
         new Racer("Lewis", "Hamilton", "UK", 266, 95, new[] { 2008, 2014, 2015, 2017, 2018, 2019, 2020 },
            new[] { "McLaren", "Mercedes" }),
         new Racer("Jenson", "Button", "UK", 306, 16, new[] { 2009 }, new[] { "Brawn GP" }),
         new Racer("Sebastian", "Vettel", "Germany", 257, 53, new[] { 2010, 2011, 2012, 2013 },
            new[] { "Red Bull Racing" }),
         new Racer("Nico", "Rosberg", "Germany", 207, 24, new[] { 2016 }, new[] { "Mercedes" })
      };
   }
}