using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleQuick.ViewModels
{
    public class InvoiceDetailViewModel
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string TollStation { get; set; }
        public string Way { get; set; }
        public int Category { get; set; }
        public decimal Total { get; set; }
        public int InvoiceHeaderId { get; set; }
        public virtual string VehicleRegistration { get; set; }
    }
}
