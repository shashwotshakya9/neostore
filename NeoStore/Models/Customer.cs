using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeoStore.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name Required !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Customer Address Required !")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Customer Contact Required !")]
        public string Contact { get; set; }

        public string Email { get; set; }

        public string MemberType { get; set; }

        public virtual List<Sale> Sale { get; set; }

    }
}
