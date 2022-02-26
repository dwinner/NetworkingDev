using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using WinAppChatClient.Services;
using WinAppChatClient.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinAppChatClient
{
   /// <summary>
   ///    Provides application-specific behavior to supplement the default Application class.
   /// </summary>
   public partial class App
   {
      private readonly IHost _host;
      private Window? _mWindow;

      /// <summary>
      ///    Initializes the singleton application object.  This is the first line of authored code
      ///    executed, and as such is the logical equivalent of main() or WinMain().
      /// </summary>
      public App()
      {
         InitializeComponent();
         _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
               services.AddScoped<IDialogService, DialogService>();
               services.AddScoped<UrlService>();
               services.AddScoped<ChatViewModel>();
               services.AddScoped<GroupChatViewModel>();
            }).Build();
      }

      internal IServiceProvider Services => _host.Services;

      /// <summary>
      ///    Invoked when the application is launched normally by the end user.  Other entry points
      ///    will be used such as when the application is launched to open a specific file.
      /// </summary>
      /// <param name="args">Details about the launch request and process.</param>
      protected override void OnLaunched(LaunchActivatedEventArgs args)
      {
         _mWindow = new MainWindow();
         _mWindow.Activate();
      }
   }
}