using TeleQuick.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TeleQuick.Core.Autopista.Model
{
    public class InvoiceFactoryAUSOL : InvoiceFactory, IInvoiceFactory
    {
        public InvoiceFactoryAUSOL(IEnumerable<Vehicle> vehicles) :
            base(vehicles)
        {

        }

        public async Task<List<InvoiceHeader>> Procees(List<HeaderResponse> hr)
        {
            List<InvoiceHeader> list = new List<InvoiceHeader>();

            foreach (var item in hr)
            {
                InvoiceHeader header = await Task.Run(() => CreateHeader(item));
                foreach (var item2 in item.Details)
                {
                    InvoiceDetail detail = await Task.Run(() => this.CreateDetail(item2, header.Date));
                    header.InvoiceDetails.Add(detail);
                }

                list.Add(header);
            }

            return list;
        }

        private InvoiceHeader CreateHeader(HeaderResponse hr)
        {
            InvoiceHeader header = new InvoiceHeader();

            header.Date = DateTime.ParseExact(hr.Campo1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            header.Voucher = hr.Campo0;
            //header.PointOfSale = Convert.ToInt32(hr.Campo7);
            //header.CurrentAccount = Convert.ToInt32(hr.Campo8);
            //header.CAE = Convert.ToInt32(hr.Campo9);

            //header.Subtotal = decimal.Parse(hr.Campo22);
            //header.Ivains = decimal.Parse(hr.Campo25);

            Regex rx = new Regex(@"^?[0-9]*\,?[0-9]+$");

            header.Total = decimal.Parse(rx.Match(hr.Campo2).Value);

            return header;
        }

        private InvoiceDetail CreateDetail(DetailResponse hr, DateTime dateHeader)
        {
            InvoiceDetail detail = new InvoiceDetail();

            detail.Date = dateHeader;
            detail.TollStation = string.Empty;
            detail.Way = string.Empty;
            detail.Quantity = Convert.ToInt32(hr.Campo2);
           // detail.Categoria = Convert.ToInt32(hr.Campo2);


            Regex rx = new Regex(@"^?[0-9]*\,?[0-9]+$");
            detail.Total = decimal.Parse(rx.Match(hr.Campo4).Value);
            detail.VehicleId = 1; // Campo0


            return detail;
        }
    }
}