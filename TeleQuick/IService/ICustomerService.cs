using Business;
using System;
using System.Collections.Generic;

namespace IService
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get();
    }
}
