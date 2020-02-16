using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models.Business
{
    public class Concessionary
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Detail { get; set; }

        public ICollection<AccountSession> AccountSessions { get; set; }
    }
}
