using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.ViewModels
{
    public class ProductNotSoldViewModel
    {
        public int ProductId { get; set; }
        public String ProductCode { get; set; }
        public String ProductName { get; set; }
        public int AvailableStock { get; set; }
        public String ProductCategory { get; set; }

    }
}
