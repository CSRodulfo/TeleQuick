using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Business
{
    public class TruckCar : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(111)]
        public string Name { get; set; }
    }
}
