using ECommerceApp.DataAccess.SqlServer;
using ECommerceApp.Domain.Abstractions;
using ECommerceApp.Domain.AdditionalClasses;
using ECommerceApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.ViewModels
{
    public class AdminViewModel :BaseViewModel
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Order> _orderRepo;
        public AdminViewModel()
        {
            _productRepo = new ProductRepository();
            _orderRepo = new OrderRepository();
            AllProducts = _productRepo.GetAllData();
            var orders= _orderRepo.GetAllData();
            var myAllOrders = orders.Select(o =>
            {
                var order_model = new OrderModel
                {
                       Order=o,
                       Total=o.Product.Price*o.Amount
                };
                return order_model;
            });
            AllOrders=ObservableHelper.ToObservableCollection(myAllOrders);
        }
        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

        private ObservableCollection<OrderModel> allOrders;

        public ObservableCollection<OrderModel> AllOrders
        {
            get { return allOrders; }
            set { allOrders = value; OnPropertyChanged(); }
        }
    }
}
