using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Web.Configuration;
using System.Web.UI;
using ConfigFiles.CustomCollSections;

namespace ConfigFiles
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IEnumerable<string> GetConfig()
      {
         // Параметры приложения
         IEnumerable<string> appSettings =
            from object appSettingKey in WebConfigurationManager.AppSettings
            select
               string.Format("{0} = {1}", appSettingKey, WebConfigurationManager.AppSettings[appSettingKey.ToString()]);

         // Параметры строк подключения
         IEnumerable<string> connectionStrings =
            from ConnectionStringSettings connectionString in WebConfigurationManager.ConnectionStrings
            select
               string.Format("name: {0}, connectionString: {1}", connectionString.Name,
                  connectionString.ConnectionString);

         // Получение одиночного раздела конфигурации
         IEnumerable<string> compilationSectionParams = CompilationSectionParams();

         // Работа с полной конфигурацией
         IEnumerable<string> sectionGroups = SectionGroups();

         // Навигация по конфигурации
         IEnumerable<string> configNavigation = ConfigNavigation();

         // Использование специальных разделов конфигурации
         IEnumerable<string> customSectionParams = CustomSectionParams();

         // Использование раздела конфигурации в виде коллекции
         IEnumerable<string> collParams = CustomSectionCollectionParams();

         return
            appSettings.Union(connectionStrings)
               .Union(compilationSectionParams)
               .Union(sectionGroups)
               .Union(configNavigation)
               .Union(customSectionParams)
               .Union(collParams);
      }

      private IEnumerable<string> CustomSectionCollectionParams()
      {
         Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.Path);
         var @group = (UserAndPlaceSectionGroup) config.SectionGroups["customDefaults"];
         Debug.Assert(@group != null, "@group != null");

         var placeSection = @group.Places;
         if (placeSection != null)
         {
            Place defaultPlace = placeSection.Places[placeSection.Default];
            yield return
               string.Format("The default is: {0} (City: {1}, Country: {2})", placeSection.Default, defaultPlace.City,
                  defaultPlace.Country);
            foreach (Place place in placeSection.Places)
            {
               yield return string.Format("{0} {1}", place.City, place.Country);
            }
         }
         else
         {
            yield return string.Empty;
         }
      }

      private IEnumerable<string> CustomSectionParams()
      {
         Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.Path);
         var @group = (UserAndPlaceSectionGroup)config.SectionGroups["customDefaults"];
         Debug.Assert(@group != null, "@group != null");

         var section = @group.NewUserDefaults;
         if (section != null)
         {
            yield return string.Format("city = {0}", section.City);
            yield return string.Format("country = {0}", section.Country);
            yield return string.Format("language = {0}", section.Language);
            yield return string.Format("region = {0}", section.Region);
         }
         else
         {
            yield return string.Empty;
         }
      }

      private IEnumerable<string> ConfigNavigation()
      {
         Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.Path);
         return config.SectionGroups.Cast<ConfigurationSectionGroup>().SelectMany(ProcessSectionGroup);
      }

      private static IEnumerable<string> ProcessSectionGroup(ConfigurationSectionGroup @group)
      {
         yield return string.Format("<b>Section Group: {0}</b>", @group.Name);
         foreach (ConfigurationSectionGroup innerGroup in @group.SectionGroups)
         {
            // ReSharper disable IteratorMethodResultIsIgnored
            ProcessSectionGroup(innerGroup);
            // ReSharper restore IteratorMethodResultIsIgnored
         }
         foreach (ConfigurationSection section in @group.Sections)
         {
            yield return string.Format("Section: {0}", section.SectionInformation.Name);
         }
      }

      private IEnumerable<string> SectionGroups()
      {
         Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.Path);
         var @group = config.SectionGroups["system.web"] as SystemWebSectionGroup;
         if (@group != null)
         {
            yield return string.Format("debug = {0}", @group.Compilation.Debug);
            yield return string.Format("target framework = {0}", @group.Compilation.TargetFramework);
            yield return string.Format("batch = {0}", @group.Compilation.Batch);
         }
         else
         {
            yield return string.Empty;
         }
      }

      private static IEnumerable<string> CompilationSectionParams()
      {
         object configObject = WebConfigurationManager.GetWebApplicationSection("system.web/compilation");
         var sectionHandler = configObject as CompilationSection;
         if (sectionHandler != null)
         {
            yield return string.Format("debug = {0}", sectionHandler.Debug);
            yield return string.Format("target framework = {0}", sectionHandler.TargetFramework);
            yield return string.Format("batch = {0}", sectionHandler.Batch);
         }
         else
         {
            yield return string.Format("Unexpected object type: {0}", configObject.GetType());
         }
      }

      #region Получение строки подключения и ее использование для отправки запроса базе данных

      public IEnumerable<string> GetConnectionStringSample()
      {
         string csName = WebConfigurationManager.AppSettings["dbConnectionString"];
         ConnectionStringSettings conString = WebConfigurationManager.ConnectionStrings[csName];

         using (DbConnection dbConn = DbProviderFactories.GetFactory(conString.ProviderName).CreateConnection())
         {
            if (dbConn == null)
               yield break;

            dbConn.ConnectionString = conString.ConnectionString;
            dbConn.Open();

            using (DbCommand dbCommand = dbConn.CreateCommand())
            {
               dbCommand.CommandText = "SELECT UserName FROM Users";
               dbCommand.CommandType = CommandType.Text;

               using (DbDataReader reader = dbCommand.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     yield return reader[0].ToString();
                  }
               }
            }
         }
      }

      #endregion
   }
}