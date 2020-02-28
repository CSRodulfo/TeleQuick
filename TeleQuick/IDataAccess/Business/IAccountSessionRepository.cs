﻿using  TeleQuick.Business.Models;
using IDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess.TeleQuick.Business
{
    public interface IAccountSessionRepository: IRepository<AccountSession>
    {
        Task<IEnumerable<AccountSession>> GetAllData();

        Task<AccountSession> GetById(int id);
    }
}