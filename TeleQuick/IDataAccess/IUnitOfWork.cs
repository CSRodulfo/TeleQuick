// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using TeleQuick.IDataAccess.Business;

namespace IDataAccess
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicles { get; }
        IAccountSessionRepository AccountSessions { get; }

        int SaveChanges();
    }
}
