//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nicom.Timesheets.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
