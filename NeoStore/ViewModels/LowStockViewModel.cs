﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.ViewModels
{
    public class LowStockViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public int Quantity { get; set; }

        public string Catgeory { get; set; }
    }
}
