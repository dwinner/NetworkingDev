using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiSample.Models
{
  public class MenuContextInitializer : DropCreateDatabaseAlways<MenuCardModel> // : DropCreateDatabaseIfModelChanges<MenuCardModel>
  {
    protected override void Seed(MenuCardModel context)
    {
      var cards = new List<MenuCard>
      {
        new MenuCard { Id = 1, Active = true, Name = "Soups", Order = 1 },
        new MenuCard { Id=2, Active = true, Name = "Main", Order = 2 }
      };
      cards.ForEach(c => context.MenuCards.Add(c));

      new List<Menu>
      {
        new Menu { Id=1, Active = true, Text = "Fritattensuppe", Order = 1, Price = 2.4M, MenuCard = cards[0] },
        new Menu { Id=2, Active = true, Text = "Wiener Schnitzel", Order = 2, Price= 6.9M, MenuCard=cards[1] }
      }.ForEach(m => context.Menus.Add(m));
      base.Seed(context);
    }
  }
}