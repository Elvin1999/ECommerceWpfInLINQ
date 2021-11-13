using ECommerceApp.DataAccess.SqlServer;
using ECommerceApp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Services
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepo;
        public CustomerService()
        {
            _customerRepo = new CustomerRepository();
        }

        public Customer GetCustomerByUsername(string username)
        {
            var customer = _customerRepo.GetAllData().FirstOrDefault(c => c.Username == username);
            return customer;
        }
    }
}
