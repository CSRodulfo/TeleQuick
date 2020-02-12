// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

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
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IOrdersRepository Orders { get; }
        IVehicleRepository Vehicles{ get; }

        int SaveChanges();
    }
}
