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
    
    public partial class ClientModel
    {
        public ClientModel()
        {
            this.ClientUserRates = new HashSet<ClientUserRateModel>();
            this.Projects = new HashSet<ProjectModel>();
        }
    
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientLongName { get; set; }
        public string InvoiceType { get; set; }
        public bool IsBarterClient { get; set; }
        public Nullable<double> DiscountPercentage { get; set; }
        public bool HasTimeBlock { get; set; }
        public Nullable<double> BarterPercentage { get; set; }
        public Nullable<int> SalemanID { get; set; }
        public Nullable<int> Salesman1ID { get; set; }
        public Nullable<double> SalesmanPercentage { get; set; }
        public Nullable<double> Salesman1Percentage { get; set; }
    
        public virtual ICollection<ClientUserRateModel> ClientUserRates { get; set; }
        public virtual ICollection<ProjectModel> Projects { get; set; }
    }
}
