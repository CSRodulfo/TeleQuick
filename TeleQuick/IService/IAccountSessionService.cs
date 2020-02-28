﻿using  TeleQuick.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.TeleQuick.Business
{
    public interface IAccountSessionService
    {
        Task<IEnumerable<AccountSession>> Get();
        Task<AccountSession> GetById(int id);
        Task<int> Create(AccountSession account);
        Task<int> Update(AccountSession account);
        Task<bool> ValidateConnection(AccountSession account);
        Task<List<InvoiceHeader>> Process(AccountSession account);
    }
}
