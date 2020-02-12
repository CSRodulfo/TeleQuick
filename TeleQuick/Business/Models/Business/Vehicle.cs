using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace Business.Business
{
    public class Vehicle : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Make { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(10)]
        public string RegistrationNumber { get; set; }

        public ICollection<TagRfid> TAGs { get; set; }

        public ICollection<InvoiceHeader> InvoiceHeaders { get; set; }

    }
}
