using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        // foreign key of Product entity 
        [ForeignKey("Product")]
        [Required(ErrorMessage = "Product id required!")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public virtual Product Product { get; set; }


    }
}
