using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business.Charts;
using TeleQuick.Business.Models;
using TeleQuick.IDataAccess.Business;
using TeleQuick.IService;

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

        public async Task<Chart> GetChartData(int month)
        {
            Chart chart = new Chart();

            chart.chartData = await this.GetChartDataByMonth(month);
            chart.labels = this.GetChartMonth(month).Select(m => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m.ToString("MMMM").Substring(0, 3)));

            return chart;
        }

        private async Task<IEnumerable<ChartData>> GetChartDataByMonth(int month)
        {
            var months = GetChartMonth(month).Select(m => m.ToString("yyyyM"));
            var list = await _invoiceRepository.GetChartData(month);

            foreach (var charData in list)
            {
                List<ChartYear> data = new List<ChartYear>();
                foreach (string date in months)
                {
                    ChartYear chartYear = charData.data.FirstOrDefault(x => x.IdYearMonth == date);

                    if (chartYear == null)
                    {
                        ChartYear chart = new ChartYear();
                        chart.Description = charData.label;
                        chart.Month = int.Parse(date.Substring(0, 4));
                        chart.IdYearMonth = date;
                        data.Add(chart);
                    }
                    else
                    {
                        data.Add(chartYear);
                    }
                }
                charData.data = data;
            }

            return list;
        }

        private IEnumerable<DateTime> GetChartMonth(int month)
        {
            var startDate = System.DateTime.Now.AddMonths(month);

            return Enumerable.Range(0, 6).Select(startDate.AddMonths);
        }

        public Task<IEnumerable<ChartVehicle>> GetChartDataByVehicle()
        {
            return _invoiceRepository.GetChartDataByVehicle();
        }
    }
}
