//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SupermarketChainOracle.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT
    {
        public decimal ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public decimal VENDOR_ID { get; set; }
        public decimal MEASURE_ID { get; set; }
        public decimal PRICE { get; set; }
    
        public virtual MEASURE MEASURE { get; set; }
        public virtual VENDOR VENDOR { get; set; }
    }
}
