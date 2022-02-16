using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebSampleApp.Services
{
   public class SessionSample
   {
      private const string SessionVisits = nameof(SessionVisits);
      private const string SessionTimeCreated = nameof(SessionTimeCreated);

      public async Task SessionAsync(HttpContext context)
      {
         var visits = context.Session.GetInt32(SessionVisits) ?? 0;
         var timeCreated = context.Session.GetString(SessionTimeCreated) ?? string.Empty;
         if (string.IsNullOrEmpty(timeCreated))
         {
            timeCreated = DateTime.Now.ToString("t", CultureInfo.InvariantCulture);
            context.Session.SetString(SessionTimeCreated, timeCreated);
         }

         var timeCreated2 = DateTime.Parse(timeCreated);
         context.Session.SetInt32(SessionVisits, ++visits);
         await context.Response.WriteAsync(
            $"Number of visits within this session: {visits} " +
            $"that was created at {timeCreated2:T}; " +
            $"current time: {DateTime.Now:T}").ConfigureAwait(false);
         Debug.WriteLine(nameof(SessionAsync));
      }
   }
}