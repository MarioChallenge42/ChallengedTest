//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Challenged.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ModuleUser
    {
        public int IdModuleUser { get; set; }
        public int IdModule { get; set; }
        public string IdUser { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Module Module { get; set; }
    }
}