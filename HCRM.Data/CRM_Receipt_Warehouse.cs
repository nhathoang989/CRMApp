//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCRM.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CRM_Receipt_Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRM_Receipt_Warehouse()
        {
            this.CRM_Receipt_Details = new HashSet<CRM_Receipt_Details>();
        }
    
        public long ReceiptID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Total { get; set; }
        public bool IsPaid { get; set; }
        public bool IsReceived { get; set; }
        public string Status { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string FormPayment { get; set; }
        public long UserId { get; set; }
        public int ProviderID { get; set; }
    
        public virtual CRM_Provider CRM_Provider { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRM_Receipt_Details> CRM_Receipt_Details { get; set; }
    }
}
