using AutoMapper;
using Business;
using DAL;
using IService;
using System;
using System.Collections.Generic;

namespace Service
{
    public class CustomerService : ICustomerService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public CustomerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
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
