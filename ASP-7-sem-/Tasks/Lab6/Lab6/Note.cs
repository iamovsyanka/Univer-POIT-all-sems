//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab6
{
    using System;
    using System.Collections.Generic;
    
    public partial class Note
    {
        public int id { get; set; }
        public Nullable<int> id_s { get; set; }
        public string subj { get; set; }
        public string note1 { get; set; }
    
        public virtual Students Students { get; set; }
    }
}
