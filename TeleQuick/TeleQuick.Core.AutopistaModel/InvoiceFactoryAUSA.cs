using TeleQuick.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeleQuick.Core.Autopista.Model
{
    public class InvoiceFactoryAUSA 
    {
        public InvoiceFactoryAUSA()
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
                    InvoiceDetail detail = await Task.Run(() => this.CreateDetail(item2));
                    header.InvoiceDetails.Add(detail);
                }

                list.Add(header);
            }

            return list;
        }

        private InvoiceHeader CreateHeader(HeaderResponse hr)
        {
             
            InvoiceHeader header = new InvoiceHeader();

            header.Date = DateTime.ParseExact(hr.Campo4, "dd/MM/yyyy", null);
            header.Voucher = hr.Campo6;
            header.PointOfSale = Convert.ToInt32(hr.Campo7);
            header.CurrentAccount = Convert.ToInt32(hr.Campo8);
            //header.CAE = Convert.ToInt32(hr.Campo9);
            
            header.Subtotal = Convert.ToDecimal(hr.Campo22);
            header.Ivains = Convert.ToDecimal(hr.Campo25);
            header.Total = Convert.ToDecimal(hr.Campo32);
            header.ConcessionaryId = 1;



            return header;
        }

        private InvoiceDetail CreateDetail(DetailResponse hr)
        {
            InvoiceDetail detail = new InvoiceDetail();

            detail.Date = DateTime.ParseExact(hr.Campo0, "dd/MM/yyyy", null);
            detail.Hour = TimeSpan.ParseExact( hr.Campo1, "g",null);
            detail.Categoria = Convert.ToInt32( hr.Campo2);
            detail.Way = hr.Campo3;
            detail.TollStation = hr.Campo5;
            detail.Total = Convert.ToDecimal(hr.Campo6);
            detail.VehicleId = 1;


            return detail;
        }
    }
}