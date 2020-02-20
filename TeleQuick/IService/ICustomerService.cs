using Business;
using System;
using System.Collections.Generic;

namespace IService.Business
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get();
    }
}
