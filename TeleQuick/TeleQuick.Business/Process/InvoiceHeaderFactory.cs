using Business.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TeleQuick.Core.Autopista.Model;

namespace Business.Process
{
    public class InvoiceHeaderFactoryAUSA
    {
        public InvoiceHeaderFactoryAUSA()
        {

        }

        public InvoiceHeader Create(HeaderResponse hr)
        {
            InvoiceHeader header = new InvoiceHeader();

            header.Date = DateTime.ParseExact(hr.Campo4, "dd/MM/yyyy", null);
            header.Voucher = hr.Campo6;
            header.PointOfSale = Convert.ToInt32(hr.Campo7);
            header.CurrentAccount = Convert.ToInt32(hr.Campo8);
            header.CAE = Convert.ToInt32(hr.Campo9);
            
            header.Subtotal = Convert.ToDecimal(hr.Campo22);
            header.IVAIns = Convert.ToDecimal(hr.Campo25);
            header.Total = Convert.ToDecimal(hr.Campo32);



            return header;
        }
    }
}