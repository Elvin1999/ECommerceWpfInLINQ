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
    public class OrderRepository : IOrderRepository
    {
        public SqlDataDataContext DataContext { get; set; }

        public OrderRepository()
        {
            DataContext =  new SqlDataDataContext();
        }

        public void AddData(Order data)
        {
            DataContext.Orders.InsertOnSubmit(data);
            DataContext.SubmitChanges();
        }

        public void DeleteData(Order data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Order> GetAllData()
        {
            var orders = from o in DataContext.Orders
                           select o;
            return ObservableHelper.ToObservableCollection(orders);
        }

        public Order GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Order data)
        {
            throw new NotImplementedException();
        }
    }
}
