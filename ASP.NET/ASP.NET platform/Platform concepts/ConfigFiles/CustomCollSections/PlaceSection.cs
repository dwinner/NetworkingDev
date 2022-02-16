using System.Configuration;

namespace ConfigFiles.CustomCollSections
{
   public class PlaceSection : ConfigurationSection
   {
      private const string MagicEmpty = "";
      private const string DefaultMagicKey = "default";

      [ConfigurationProperty(MagicEmpty, IsDefaultCollection = true)]
      [ConfigurationCollection(typeof (PlaceCollection))]
      public PlaceCollection Places
      {
         get { return (PlaceCollection) base[MagicEmpty]; }
      }

      [ConfigurationProperty(DefaultMagicKey)]
      public string Default
      {
         get { return (string) base[DefaultMagicKey]; }
         set { base[DefaultMagicKey] = value; }
      }
   }
}