//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudioByPhoto
{
    using System;
    using System.Collections.Generic;
    
    public partial class Discount
    {
        public Discount()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int IdDiscount { get; set; }
        public string NameOfShare { get; set; }
        public int SizeDiscount { get; set; }
    
        public virtual ICollection<Order> Order { get; set; }
    }
}
