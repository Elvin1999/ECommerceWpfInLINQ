using ECommerceApp.Domain.Abstractions;
using ECommerceApp.Domain.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.SqlServer
{
    public class CustomerRepository : ICustomerRepository
    {
        public SqlDataDataContext DataContext { get; set; }

        public CustomerRepository()
        {
            DataContext = new SqlDataDataContext();
        }
        public void AddData(Customer data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Customer data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetAllData()
        {
            var customers = from c in DataContext.Customers
                            select c;
            return ObservableHelper.ToObservableCollection(customers);
        }

        public Customer GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
