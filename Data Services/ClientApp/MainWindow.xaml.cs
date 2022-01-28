using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ClientApp.Properties;
using R = ClientApp.RestaurantServiceReference;

namespace ClientApp
{
   public partial class MainWindow
   {
      private readonly R.RestaurantEntities _data;
      private DataServiceCollection<R.Menu> _trackedMenus;

      public MainWindow()
      {
         var serviceRoot = new Uri(Settings.Default.RestaurantServiceUrl);
         _data = new R.RestaurantEntities(serviceRoot);
         _data.SendingRequest += DataOnSendingRequest;
         InitializeComponent();
         DataContext = this;
      }

      public IEnumerable<R.Category> Categories
      {
         get
         {
            return from category in _data.Categories
                   orderby category.Name
                   select category;
         }
      }

      public IEnumerable<R.Menu> Menus
      {
         get
         {
            if (_trackedMenus == null)
            {
               _trackedMenus = new DataServiceCollection<R.Menu>(_data);
               var category = CategoriesComboBox.SelectedItem as R.Category;
               if (category != null)
               {
                  _trackedMenus.Load(from menu in _data.Menus
                                     where menu.CategoryId == category.Id && menu.Active
                                     select menu);
               }
            }

            return _trackedMenus;
         }
      }

      private void DataOnSendingRequest(object sender, SendingRequestEventArgs sendingRequestEventArgs)
      {
         var stringBuilder = new StringBuilder();
         stringBuilder.AppendFormat("Method: {0}{1}", sendingRequestEventArgs.Request.Method, Environment.NewLine)
            .AppendFormat("Uri: {0}{1}", sendingRequestEventArgs.Request.RequestUri, Environment.NewLine);
         TextStatus.Text = stringBuilder.ToString();
      }

      private void OnCategorySelection(object sender, SelectionChangedEventArgs e)
      {
         var selectedCategory = CategoriesComboBox.SelectedItem as R.Category;
         if (selectedCategory != null && _trackedMenus != null)
         {
            _trackedMenus.Clear();
            _trackedMenus.Load(from menu in _data.Menus
                               where menu.CategoryId == selectedCategory.Id
                               select menu);
         }
      }

      private void OnAddMenu(object sender, RoutedEventArgs e)
      {
         var category = CategoriesComboBox.SelectedItem as R.Category;

         if (category != null)
         {
            var newMenu = new R.Menu
            {
               Category = category,
               CategoryId = category.Id,
               Name = "[Please Add Name]",
               Description = "[Please Add Description]",
               Price = 0m,
               Active = true
            };

            _trackedMenus.Add(newMenu);
         }
      }

      private void OnShowEntities(object sender, RoutedEventArgs e)
      {
         var stateBuilder = new StringBuilder();
         foreach (EntityDescriptor entityDescriptor in _data.Entities)
         {
            stateBuilder.AppendFormat("State = {0}, Uri = {1}, Element = {2}{3}", entityDescriptor.State,
               entityDescriptor.Identity, entityDescriptor.Entity, Environment.NewLine);
         }

         TextStatus.Text = stateBuilder.ToString();
      }

      private async void OnSave(object sender, RoutedEventArgs e)
      {
         try
         {
            await
               Task<DataServiceResponse>.Factory.FromAsync(_data.BeginSaveChanges, _data.EndSaveChanges,
                  SaveChangesOptions.Batch, null);
         }
         catch (DataServiceRequestException dataServiceRequestException)
         {
            TextStatus.Text = dataServiceRequestException.ToString();
         }
      }

      private void OnExit(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }
   }
}