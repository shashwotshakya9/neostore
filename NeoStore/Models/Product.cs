using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Code is required")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Prodcut Name is required")]
        public string ProductName { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }


        // foreign key of Category entity
        [ForeignKey("Category")]
        [Required(ErrorMessage = "Product Category is required")]
        public int ProductCategory { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Stock> Stock { get; set; }
    }
}
