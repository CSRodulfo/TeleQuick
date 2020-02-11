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
        [StringLength(30)]
        public string Model { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }
    }
}
