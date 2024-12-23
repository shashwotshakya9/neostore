using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.Models
{
    public class SaleDetail
    {
        [Key]
        public int Id { get; set; }

        // foreign key of sale entity
        [ForeignKey("Sale")]
        [Required(ErrorMessage = "Sale id required!")]
        public int SaleId { get; set; }

        // foreign key of product entity
        [ForeignKey("Product")]
        [Required(ErrorMessage = "Product id required!")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
