using IDataAccess;
using TeleQuick.DataAcces;
using TeleQuick.DataAcces.Business;
using TeleQuick.IDataAccess.Business;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        IVehicleRepository _vehicles;
        IAccountSessionRepository _accountSessions;
        IInvoiceRepository _invoice;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IVehicleRepository Vehicles
        {
            get
            {
                if (_vehicles == null)
                    _vehicles = new VehicleRepository(_context);

                return _vehicles;
            }
        }

        public IAccountSessionRepository AccountSessions
        {
            get
            {
                if (_accountSessions == null)
                    _accountSessions = new AccountSessionRepository(_context);

                return _accountSessions;
            }
        }

        public IInvoiceRepository Invoice
        {
            get
            {
                if (_invoice == null)
                    _invoice = new InvoiceRepository(_context);

                return _invoice;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
