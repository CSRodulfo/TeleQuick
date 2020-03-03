using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Business.Models;

namespace TeleQuick.Core.Autopista.Model
{
    public interface IInvoiceFactory
    {
        Task<List<InvoiceHeader>> Procees(List<HeaderResponse> hr);
    }
}
