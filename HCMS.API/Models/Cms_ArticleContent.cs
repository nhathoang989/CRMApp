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
    
    public partial class Cms_ArticleContent
    {
        public int ArticleContentID { get; set; }
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string BriefContent { get; set; }
        public string FullContent { get; set; }
        public string LanguageID { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public string SEOKeywords { get; set; }
        public string SEName { get; set; }
        public string URL { get; set; }
    
        public virtual Cms_Article Cms_Article { get; set; }
    }
}
