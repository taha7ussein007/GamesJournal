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
    
    public partial class complaint
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public Nullable<int> responder_id { get; set; }
        public string content { get; set; }
        public string response { get; set; }
        public System.DateTime comp_timestamp { get; set; }
        public Nullable<System.DateTime> resp_timestamp { get; set; }
    
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}