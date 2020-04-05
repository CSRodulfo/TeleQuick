using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business.Charts;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Business;
using TeleQuick.IService;
using System.Linq;
using System.Data;

namespace TeleQuick.Service
{
    public class InvoiceService : IInvoiceService
    {

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, IInvoiceDetailRepository invoiceDetailRepository)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public Task<IEnumerable<InvoiceHeader>> GetAll(int pageNumber, int pageSize)
        {
            return _invoiceRepository.GetAll(pageNumber, pageSize);
        }

        public Task<IEnumerable<InvoiceDetail>> GetAllDetails(int pageNumber, int pageSize)
        {
            return _invoiceDetailRepository.GetAllDetails(pageNumber, pageSize);

        }

        public Task<IEnumerable<InvoiceDetail>> GetByHeaderId(int id)
        {
            return _invoiceDetailRepository.GetByHeaderId(id);
        }

        public Task<IEnumerable<ChartConcessionaries>> GetChartDataByConcessionary()
        {
            return _invoiceRepository.GetChartDataByConcessionary();
        }

        public async Task<Chart> GetChartData()
        {
            Chart chart = new Chart();

            chart.chartData = await this.GetChartDataByMonth();
            chart.labels = this.GetChartMonth();

            return chart;
        }

        private async Task<IEnumerable<ChartData>> GetChartDataByMonth()
        {
            var startDate = System.DateTime.Now.AddMonths(-6);

            var months = Enumerable.Range(0, 6)
                                .Select(startDate.AddMonths)
                                .Select(m => m.ToString("yyyyM"));


            var a = await _invoiceRepository.GetChartDataByMonth();

            foreach (var item in a)
            {
                foreach (string month in months)
                {
                    var f = item.data.Any(x => x.Year == month);

                    if (!f)
                    {
                        ChartYear year = new ChartYear();
                        year.Concessionary = item.label;
                        year.Month = int.Parse(month.Substring(4, month.Length - 4));
                        year.Year = month;
                        item.data.Add(year);
                    }

                }
                item.data = item.data.OrderBy(m => m.Year).ToList();
            }

            return a;

            //return _invoiceRepository.GetChartDataByMonth();
        }

        private IEnumerable<string> GetChartMonth()
        {
            var startDate = System.DateTime.Now.AddMonths(-6);

            var months = Enumerable.Range(0, 6)
                                .Select(startDate.AddMonths)
                                .Select(m => System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m.ToString("MMMM")))
                                .AsEnumerable();

            return months;
        }


        public Task<IEnumerable<ChartVehicle>> GetChartDataByVehicle()
        {
            return _invoiceRepository.GetChartDataByVehicle();
        }
    }
}
