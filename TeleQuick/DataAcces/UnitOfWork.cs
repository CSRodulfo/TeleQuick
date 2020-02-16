// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.Business;
using DataAccess.Repositories;
using IDataAccess;
using IDataAccess.Business;
using IDataAccess.Repositories;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        ICustomerRepository _customers;
        IProductRepository _products;
        IOrdersRepository _orders;
        IVehicleRepository _vehicles;
        IAccountSessionRepository _accountSessions;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }



        public ICustomerRepository Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(_context);

                return _customers;
            }
        }



        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_context);

                return _products;
            }
        }



        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrdersRepository(_context);

                return _orders;
            }
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

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
