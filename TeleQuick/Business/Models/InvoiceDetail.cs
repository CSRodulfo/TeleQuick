using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        public string Date { get; set; }
        public string Hour { get; set; }
        public string TollStation { get; set; }
        public string Way { get; set; }
        public int Categoria { get; set; }

        [Required]
        [StringLength(5)]
        public decimal Total { get; set; }

    }
}
