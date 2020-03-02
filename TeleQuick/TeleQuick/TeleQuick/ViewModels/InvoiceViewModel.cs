using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleQuick.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public string Voucher { get; set; }
        //public int PointOfSale { get; set; }
        //public int CurrentAccount { get; set; }
        //public decimal Cae { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Ivains { get; set; }
        //public decimal Ivarni { get; set; }
        //public decimal Ivarg3337 { get; set; }
        //public decimal Iibb { get; set; }
        //public decimal Total { get; set; }
        public int ConcessionaryId { get; set; }

        //public virtual Concessionary Concessionary { get; set; }
        //public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
