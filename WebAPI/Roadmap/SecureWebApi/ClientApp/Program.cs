/**
 * Клиент аутентифицированного WebAPI-сервиса
 */

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClientApp
{
   internal static class Program
   {
      private const string BaseAddress = "http://localhost:3656/";

      private static void Main()
      {
         //NotAuthenticated();
         //RegisterUser();
         //dynamic result = GetToken().Result;
         //Console.WriteLine(result);
         //Authenticated();
         UserInfo();

         Console.ReadLine();
      }

      private static async void NotAuthenticated() // Неавторизованный запрос
      {
         const string valuesUri = "api/Values";
         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            HttpResponseMessage response = await client.GetAsync(valuesUri);
            Console.WriteLine(response.StatusCode);
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
         }
      }

      private static async void RegisterUser() // Регистрация пользователя
      {
         const string registerUri = "api/account/register";

         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            var user = new
            {
               UserName = "dwinner",
               Password = "bboytronik",
               ConfirmPassword = "bboytronik"
            };

            try
            {
               HttpResponseMessage resp = await client.PostAsJsonAsync(registerUri, user);
               resp.EnsureSuccessStatusCode();
               Console.WriteLine("Registered successfully");
            }
            catch (HttpRequestException httpRequestEx)
            {
               Console.WriteLine(httpRequestEx.Message);
            }
         }
      }

      private static async Task<dynamic> GetToken() // Получение токена авторизации
      {
         const string tokenUri = "/Token";
         HttpResponseMessage resp;
         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            HttpContent content = new FormUrlEncodedContent(
               new List<KeyValuePair<string, string>>
               {
                  new KeyValuePair<string, string>("grant_type", "password"),
                  new KeyValuePair<string, string>("username", "dwinner"),
                  new KeyValuePair<string, string>("password", "bboytronik"),
               });
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded")
            {
               CharSet = "UTF-8"
            };

            resp = await client.PostAsync(tokenUri, content);
         }

         resp.EnsureSuccessStatusCode();
         dynamic token = await resp.Content.ReadAsAsync<dynamic>();
         Console.WriteLine("{0}", token.token_type);
         Console.WriteLine("{0}", token.access_token);
         Console.WriteLine();

         return token;
      }

      private static async void Authenticated() // Запрос, прошедший аутенфикацию
      {
         dynamic token = await GetToken();
         const string valuesUri = "api/values";

         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            client.DefaultRequestHeaders.Add("Authorization",
               string.Format("{0} {1}", token.token_type, token.access_token));
            HttpResponseMessage resp = await client.GetAsync(valuesUri);
            Console.WriteLine(resp.StatusCode);
            string content = await resp.Content.ReadAsStringAsync();
            Console.WriteLine(content);
         }
      }

      private static async void UserInfo()   // Информация о зарегистрированном пользователе
      {
         const string userInfoUri = "api/Account/UserInfo";
         dynamic token = await GetToken();
         HttpResponseMessage resp;
         using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
         {
            client.DefaultRequestHeaders.Add("Authorization",
               string.Format("{0} {1}", token.token_type, token.access_token));

            resp = await client.GetAsync(userInfoUri);
         }

         resp.EnsureSuccessStatusCode();
         UserInfo userInfo = await resp.Content.ReadAsAsync<UserInfo>();
         Console.WriteLine("user: {0}, registered: {1}, provider: {2}", userInfo.UserName, userInfo.HasRegistered,
            userInfo.LoginProvider);
      }
   }
}