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
    
    public partial class Position
    {
        public Position()
        {
            this.Worker = new HashSet<Worker>();
        }
    
        public int IdPosition { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Worker> Worker { get; set; }
    }
}