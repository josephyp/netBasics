//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RESTful
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
    }
}
