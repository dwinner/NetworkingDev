//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmsoHr.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobVacancyRequirement
    {
        public int Id { get; set; }
        public Nullable<int> JobId { get; set; }
        public string RequirementItem { get; set; }
    
        public virtual JobVacancy JobVacancy { get; set; }
    }
}
