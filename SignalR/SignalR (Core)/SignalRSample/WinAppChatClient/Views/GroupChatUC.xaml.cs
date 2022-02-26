using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using WinAppChatClient.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinAppChatClient.Views
{
   public sealed partial class GroupChatUC
   {
      private readonly IServiceScope? _scope;

      public GroupChatUC()
      {
         InitializeComponent();

         if (Application.Current is App app)
         {
            _scope = app.Services.CreateScope();
            ViewModel = _scope.ServiceProvider.GetRequiredService<GroupChatViewModel>();
         }
         else
         {
            throw new InvalidOperationException("Application.Current is not App");
         }
      }

      public GroupChatViewModel ViewModel { get; }
   }
}