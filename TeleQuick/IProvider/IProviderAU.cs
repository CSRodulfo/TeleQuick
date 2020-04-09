using TeleQuick.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.Autopista.Model;
using TeleQuick.Business;

namespace IProvider
{
    public interface IProviderAU
    {
        Task<bool> ValidateLogin();

        Task<List<InvoiceHeader>> Process(MessageDictionary messages);
    }
}
