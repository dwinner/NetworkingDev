//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DynDataEntities.Entities
{
   using System;

   public partial class Orders_Qry
   {
      public int OrderID { get; set; }
      public string CustomerID { get; set; }
      public Nullable<int> EmployeeID { get; set; }
      public Nullable<System.DateTime> OrderDate { get; set; }
      public Nullable<System.DateTime> RequiredDate { get; set; }
      public Nullable<System.DateTime> ShippedDate { get; set; }
      public Nullable<int> ShipVia { get; set; }
      public Nullable<decimal> Freight { get; set; }
      public string ShipName { get; set; }
      public string ShipAddress { get; set; }
      public string ShipCity { get; set; }
      public string ShipRegion { get; set; }
      public string ShipPostalCode { get; set; }
      public string ShipCountry { get; set; }
      public string CompanyName { get; set; }
      public string Address { get; set; }
      public string City { get; set; }
      public string Region { get; set; }
      public string PostalCode { get; set; }
      public string Country { get; set; }
   }
}
