using System.Collections.Specialized;
using System.Web;

namespace Routing
{
   public class ContextMapper : HttpContextBase
   {
      private readonly HttpRequestBase _requestMapper;

      public ContextMapper(string path, HttpRequest request)
      {
         _requestMapper = new RequestMapper(path, request);
      }

      public override HttpRequestBase Request
      {
         get { return _requestMapper; }
      }

      private class RequestMapper : HttpRequestBase
      {
         private readonly string _appRequestPath;
         private readonly HttpRequest _request;
         private readonly string _requestPath;

         public RequestMapper(string requestPath, HttpRequest request)
         {
            _requestPath = requestPath;
            _appRequestPath = VirtualPathUtility.ToAppRelative(requestPath);
            _request = request;
         }

         public override string AppRelativeCurrentExecutionFilePath
         {
            get { return _appRequestPath; }
         }

         public override string PathInfo
         {
            get { return string.Empty; }
         }

         public override string HttpMethod
         {
            get { return _request.HttpMethod; }
         }

         public override NameValueCollection Form
         {
            get { return _request.Form; }
         }

         public override NameValueCollection Headers
         {
            get { return _request.Headers; }
         }

         public override string CurrentExecutionFilePath
         {
            get { return _requestPath; }
         }
      }
   }
}