// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using IDataAccess.TeleQuick.Business;
using IDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicles { get; }
        IAccountSessionRepository AccountSessions { get; }

        int SaveChanges();
    }
}
