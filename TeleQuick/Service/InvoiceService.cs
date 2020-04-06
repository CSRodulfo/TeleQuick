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
using System.Globalization;
using System;

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
            chart.labels = this.GetChartMonth(month).Select(m => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m.ToString("MMMM")));

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
                    var f = charData.data.FirstOrDefault(x => x.IdYearMonth == date);

                    if (f == null)
                    {
                        ChartYear year = new ChartYear();
                        year.Description = charData.label;
                        year.Month = int.Parse(date.Substring(4, date.Length - 4));
                        year.IdYearMonth = date;
                        data.Add(year);
                    }
                    else
                    {
                        data.Add(f);

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
