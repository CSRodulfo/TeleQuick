using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class TagRfid : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public int TAGNumber { get; set; }

        [Required]
        public bool TAGEneable { get; set; }
    }
}
