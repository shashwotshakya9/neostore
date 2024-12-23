using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Purchase Date is required")]
        public DateTime PurchaseDate { get; set; }

        public String BillNumber { get; set; }

        public virtual List<PurchaseDetail> PurchaseDetail { get; set; }
    }
}
