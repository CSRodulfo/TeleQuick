using  Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class InvoiceHeader
    {
        public int Id { get; set; }

        [Required]
        public DateTime  Date { get; set; }

        [Required]
        public DateTime Hours { get; set; }

        [Required]
        [StringLength(5)]
        public string Voucher { get; set; }
        public int PointOfSale { get; set; }
        public int CurrentAccount { get; set; }
        public int CAE { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVAIns { get; set; }
        public decimal IVARni { get; set; }
        public decimal IVARG3337 { get; set; }

        public decimal IIBB { get; set; }

        [Required]
        public decimal Total { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
