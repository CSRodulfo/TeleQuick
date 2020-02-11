using Business;
using System;
using System.Collections.Generic;

namespace IDataAccess
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get();
    }
}
