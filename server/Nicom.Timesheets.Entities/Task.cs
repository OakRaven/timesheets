//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nicom.Timesheets.Entities
{
    using System;
    using System.Collections.Generic;
    
    [Serializable()]
    public partial class TaskModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public double RemainingEffort { get; set; }
        public bool IsProspect { get; set; }
        public int Priority { get; set; }
    }
}