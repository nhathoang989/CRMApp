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
    
    public partial class CRM_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRM_Product()
        {
            this.CRM_Product_Property = new HashSet<CRM_Product_Property>();
            this.CRM_Receipt_Details = new HashSet<CRM_Receipt_Details>();
        }
    
        public long ProductID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Material { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string FullDetails { get; set; }
        public Nullable<double> DealPrice { get; set; }
        public double NormalPrice { get; set; }
        public double Discount { get; set; }
        public string Size { get; set; }
        public int CountRemain { get; set; }
        public int CountSaled { get; set; }
        public int CountImported { get; set; }
        public string SubImages { get; set; }
        public string Language { get; set; }
        public string Infos { get; set; }
        public Nullable<int> Views { get; set; }
        public Nullable<int> CateId { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDraft { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRM_Product_Property> CRM_Product_Property { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRM_Receipt_Details> CRM_Receipt_Details { get; set; }
    }
}
