﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainSQLServer.Data
{
    public class ProductDto
    {
        public string ProductName { get; set; }

        public int VendorId { get; set; }

        public decimal Incomes { get; set; }
    }
}