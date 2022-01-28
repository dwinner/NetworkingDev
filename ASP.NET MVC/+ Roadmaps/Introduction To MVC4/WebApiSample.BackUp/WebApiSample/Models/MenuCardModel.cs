using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiSample.Models
{
  public class MenuCardModel : DbContext
  {
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuCard> MenuCards { get; set; }
  }

 
}