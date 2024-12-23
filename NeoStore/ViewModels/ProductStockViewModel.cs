using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.ViewModels
{
    public class ProductStockViewModel
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public String ProductModel { get; set; }
        public int StockQuantity { get; set; }
      
    }
}
