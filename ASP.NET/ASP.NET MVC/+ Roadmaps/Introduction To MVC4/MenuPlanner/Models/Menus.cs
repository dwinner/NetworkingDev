//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MenuPlanner.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menus
    {
        public int Id { get; set; }
        public int MenuCardId { get; set; }
        public string Text { get; set; }
        public Nullable<decimal> Price { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Day { get; set; }
    
        public virtual MenuCards MenuCards { get; set; }
    }
}
