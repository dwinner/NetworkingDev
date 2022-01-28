using System;
using System.Collections.Generic;

namespace HttpServerSample
{
   public record Racer(string FirstName,
      string LastName,
      string Country,
      int Starts,
      int Wins,
      IEnumerable<int> Years,
      IEnumerable<string> Cars) : IComparable<Racer>, IFormattable
   {
      public Racer(string firstName,
         string lastName,
         string country,
         int starts,
         int wins) : this(firstName, lastName, country, starts, wins, Array.Empty<int>(), Array.Empty<string>())
      {
      }

      public int CompareTo(Racer? other) =>
         string.Compare(LastName, other?.LastName, StringComparison.CurrentCultureIgnoreCase);

      public string ToString(string? format, IFormatProvider? formatProvider) =>
         format switch
         {
            null => ToString(),
            "N" => ToString(),
            "F" => FirstName,
            "L" => LastName,
            "C" => Country,
            "S" => Starts.ToString(),
            "W" => Wins.ToString(),
            "A" => $"{FirstName} {LastName}, country: {Country}, starts: {Starts}, wins: {Wins}",
            _ => throw new FormatException($"Format {format} not supported")
         };

      public override string ToString() => $"{FirstName} {LastName}";

      public string ToString(string format) => ToString(format, null);
   }
}