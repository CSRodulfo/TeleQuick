using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models.Business
{
    public class AccountSession : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginUser { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginUserPassword { get; set; }

        [Required]
        public bool IsValid { get; set; }


        public int ConcessionaryId { get; set; }

        public Concessionary Concessionary { get; set; }
    }
}
