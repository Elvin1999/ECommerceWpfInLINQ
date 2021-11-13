using ECommerceApp.DataAccess.SqlServer;
using ECommerceApp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Services
{
    public class ProductService
    {

        private readonly IRepository<Product> _productRepo;
        public ProductService()
        {
            _productRepo = new ProductRepository();
        }

        public ObservableCollection<Product> GetFromLowerToHigher()
        {
            var items = _productRepo
                        .GetAllData()
                        .OrderBy(p => p.Price)
                        .ToList();
            return new ObservableCollection<Product>(items);
        }
    }
}
