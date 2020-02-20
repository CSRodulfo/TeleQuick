// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business;
using IDataAccess.Repositories;

namespace DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        { }


        public IEnumerable<Customer> GetAllCustomersData()
        {
            return _appContext.Customers
                .OrderBy(c => c.Name)
                .ToList();
        }



        private ApplicationDbContext _appContext => (ApplicationDbContext)Context;
    }
}
