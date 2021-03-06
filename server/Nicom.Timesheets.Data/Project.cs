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
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.ProjectUserRates = new HashSet<ProjectUserRate>();
            this.TimesheetEntries = new HashSet<TimesheetEntry>();
            this.UserTasks = new HashSet<UserTask>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ClientId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public Nullable<float> EstimatedEffort { get; set; }
        public bool IsBillable { get; set; }
        public Nullable<int> ParentProjectId { get; set; }
        public Nullable<bool> IsFixedPrice { get; set; }
        public Nullable<int> ProjectType { get; set; }
        public bool IsComplete { get; set; }
        public Nullable<double> BarterPercentage { get; set; }
        public Nullable<double> FixedPriceAmount { get; set; }
        public bool RegularMaintenance { get; set; }
        public bool IsSRED { get; set; }
        public bool IsParentProject { get; set; }
        public Nullable<float> InternalEstimatedHours { get; set; }
        public Nullable<System.DateTime> ProjectedStartDate { get; set; }
        public Nullable<System.DateTime> ProjectedEndDate { get; set; }
        public Nullable<System.DateTime> ActualStartDate { get; set; }
        public Nullable<System.DateTime> ActualEndDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public Nullable<int> SalemanID { get; set; }
        public Nullable<int> Salesman1ID { get; set; }
        public Nullable<double> SalesmanPercentage { get; set; }
        public Nullable<double> Salesman1Percentage { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectUserRate> ProjectUserRates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimesheetEntry> TimesheetEntries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
