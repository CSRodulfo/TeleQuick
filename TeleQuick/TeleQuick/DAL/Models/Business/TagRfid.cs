using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models.Business
{
    public class TagRfid : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(111)]
        public string Name { get; set; }
    }
}
