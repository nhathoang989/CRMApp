//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCMS.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cms_AdminMenu
    {
        public int AdminMenuID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<int> AdminMenuParentID { get; set; }
    }
}