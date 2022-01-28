using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiSample.Models
{

  [DataContract]
  public class MenuCard
  {
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public bool Active { get; set; }
    [DataMember]
    public int Order { get; set; }
    [IgnoreDataMember] 
    public ICollection<Menu> Menus { get; set; }
  }
}