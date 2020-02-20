using Business;
using IDataAccess;
using IService.Business;
using System.Collections.Generic;

namespace Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/values
        public IEnumerable<Customer> Get()
        {
            var allCustomers = _unitOfWork.Customers.GetAllCustomersData();
            return allCustomers;
        }
    }
}
