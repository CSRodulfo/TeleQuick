using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Business
{
    public class UserAccount : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(111)]
        public string Name { get; set; }
        [Required]
        [StringLength(111)]
        public string Email { get; set; }
        [Required]
        [StringLength(111)]
        public string PhoneNumber { get; set; }
    }
}
