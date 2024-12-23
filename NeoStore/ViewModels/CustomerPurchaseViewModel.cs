using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.ViewModels
{
    public class CustomerPurchaseViewModel
    {
        public int CustomerId { get; set; }
        public String CustomerName { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public String ProductCode { get; set; }
        public String ProductName { get; set; }
        public String ProductModel { get; set; }
        public int PurchaseQunatity { get; set; }
        public float UnitPrice { get; set; }
        public float Total { get; set; }

        public DateTime SaleDate { get; set; }
        public string BillNumber { get; set; }

    }
}
