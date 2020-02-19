﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;

namespace Business.Models
{
    public partial class Concessionary
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Detail { get; set; }

        [Required]
        [StringLength(500)]
        public string Uri { get; set; }

        [Required]
        [StringLength(50)]
        public string MainForm { get; set; }

    }
}