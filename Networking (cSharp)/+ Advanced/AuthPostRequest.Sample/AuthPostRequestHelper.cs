using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.String;
using static AuthPostRequest.Sample.NetworkingUtils;

namespace AuthPostRequest.Sample
{
   public sealed class AuthPostRequestHelper
   {
      private readonly NetworkCredential _authCredential;
      private readonly string _domain;
      private readonly Encoding _encoding;
      private readonly Tuple<string, string>[] _postData;
      private readonly IWebProxy _proxy;

      public AuthPostRequestHelper(string domain, Tuple<string, string>[] postData,
         KeyValuePair<string, string> credentials, IWebProxy proxy, Encoding encoding)
      {
         _postData = postData;
         _domain = domain;
         _proxy = proxy;
         _encoding = encoding;

         if (!IsNullOrEmpty(credentials.Key) && !IsNullOrEmpty(credentials.Value))
         {
            _authCredential = new NetworkCredential(credentials.Key, credentials.Value, domain);
         }
      }

      public AuthPostRequestHelper(string domain, Tuple<string, string>[] postData,
         KeyValuePair<string, string> credentials, IWebProxy proxy = null)
         : this(domain, postData, credentials, proxy, Encoding.Default)
      {
      }

      public AuthPostRequestHelper(string domain, Tuple<string, string>[] postData)
         : this(domain, postData, new KeyValuePair<string, string>(null, null))
      {
      }

      public string Apply()
      {
         var request = BuildHttpRequest();
         string responseData;

         var postData = BuildPostData(_postData);
         var postBytes = _encoding.GetBytes(postData);
         request.Method = "POST";
         request.ContentType = "application/x-www-form-urlencoded";
         request.ContentLength = postBytes.Length;

         using (var responseStream = request.GetRequestStream())
         {
            responseStream.Write(postBytes, 0, postData.Length);
         }

         var webResponse = request.GetResponse() as HttpWebResponse;
         var httpResponseStream = webResponse?.GetResponseStream();
         if (httpResponseStream == null)
         {
            return Empty;
         }

         using (TextReader reader = new StreamReader(httpResponseStream))
         {
            responseData = reader.ReadToEnd();
         }

         return responseData;
      }


      public async Task<string> ApplyAsync()
      {
         var request = BuildHttpRequest();
         string responseData;

         var postData = BuildPostData(_postData);
         var postBytes = _encoding.GetBytes(postData);
         request.Method = "POST";
         request.ContentType = "application/x-www-form-urlencoded";
         request.ContentLength = postBytes.Length;

         using (var responseStream = await request.GetRequestStreamAsync())
         {
            responseStream.Write(postBytes, 0, postData.Length);
         }

         var webResponse = await request.GetResponseAsync() as HttpWebResponse;
         var httpResponseStream = webResponse?.GetResponseStream();
         if (httpResponseStream == null)
         {
            return Empty;
         }

         using (TextReader reader = new StreamReader(httpResponseStream))
         {
            responseData = await reader.ReadToEndAsync();
         }

         return responseData;
      }

      private HttpWebRequest BuildHttpRequest()
      {
         var request = WebRequest.Create(_domain) as HttpWebRequest;
         if (request == null)
         {
            throw new ArgumentException("request");
         }

         if (_proxy != null)
         {
            if (_authCredential != null)
            {
               _proxy.Credentials = _authCredential;
            }

            request.Proxy = _proxy;
         }
         else
         {
            if (_authCredential != null)
            {
               request.Credentials = _authCredential;
            }
         }

         return request;
      }
   }
}