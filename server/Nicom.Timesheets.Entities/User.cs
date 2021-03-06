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
    
    public partial class UserModel
    {
        public UserModel()
        {
            this.ClientUserRates = new HashSet<ClientUserRateModel>();
            this.ProjectUserRates = new HashSet<ProjectUserRateModel>();
            this.Timesheets = new HashSet<TimesheetModel>();
            this.UserTasks = new HashSet<UserTaskModel>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public string LoginName { get; set; }
        public bool IsAdministrator { get; set; }
        public double StandardRate { get; set; }
        public double HoursPerWeek { get; set; }
        public Nullable<double> PlannedBillUtilPct { get; set; }
        public bool IncludeUtilization { get; set; }
    
        public virtual ICollection<ClientUserRateModel> ClientUserRates { get; set; }
        public virtual ICollection<ProjectUserRateModel> ProjectUserRates { get; set; }
        public virtual ICollection<TimesheetModel> Timesheets { get; set; }
        public virtual ICollection<UserTaskModel> UserTasks { get; set; }
    }
}
