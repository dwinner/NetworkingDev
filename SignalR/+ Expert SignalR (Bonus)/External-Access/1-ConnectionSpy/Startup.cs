using Owin;

namespace ConnectionSpy
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<ConnectionSpy>("/spy");
            app.Use<SpyMiddleware>();
        }
    }
}