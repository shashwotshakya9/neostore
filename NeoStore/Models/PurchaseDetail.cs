using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.Models
{
    public class PurchaseDetail
    {
        [Key]
        public int Id { get; set; }

        //foreign key of product entity
        [ForeignKey("Product")]
        [Required(ErrorMessage = "Product Id is required!")]
        public int ProductId { get; set; }

        //foreign key of purchase entity 
        [ForeignKey("Purchase")]
        [Required(ErrorMessage = "Purchase Id is required!")]
        public int PurchaseId { get; set; }

        [Required(ErrorMessage = "Purchase Quantity is required!")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Unit Price is required!")]
        public float UnitPrice { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        public float Total { get; set; }

        public virtual Purchase Purchase { get; set; }

        public virtual Product Product { get; set; }
    }
}
