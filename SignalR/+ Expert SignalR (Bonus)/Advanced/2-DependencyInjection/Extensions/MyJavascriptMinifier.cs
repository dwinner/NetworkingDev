using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR.Hubs;

namespace DependencyResolver.Extensions
{
    public class MyJavascriptMinifier : IJavaScriptMinifier
    {
        public MyJavascriptMinifier()
        {

        }
        public string Minify(string source)
        {
            return new Minifier().MinifyJavaScript(source);
        }
    }
}