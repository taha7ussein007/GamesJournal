//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class pc_specs
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int pc_no { get; set; }
        public string cpu_model { get; set; }
        public string memory_size { get; set; }
        public string gpu_model { get; set; }
        public string resolution { get; set; }
    
        public virtual user user { get; set; }
    }
}