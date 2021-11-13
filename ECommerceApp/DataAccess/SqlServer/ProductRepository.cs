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
    public class ProductRepository : IProductRepository
    {
        public SqlDataDataContext DataContext { get; set; }
        public ProductRepository()
        {
            DataContext = new SqlDataDataContext();
        }
        public void AddData(Product data)
        {
            DataContext.Products.InsertOnSubmit(data);
            DataContext.SubmitChanges();
        }

        public void DeleteData(Product data)
        {
            DataContext.Products.DeleteOnSubmit(data);
            DataContext.SubmitChanges();
        }

        public ObservableCollection<Product> GetAllData()
        {
            var products = from p in DataContext.Products
                           select p;
            return ObservableHelper.ToObservableCollection(products);
        }

        public Product GetData(int id)
        {
            return DataContext.Products.SingleOrDefault(p => p.Id == id);
        }

        public void UpdateData(Product data)
        {
            var item = DataContext.Products.FirstOrDefault(p => p.Id == data.Id);
            item.Name = data.Name;
            item.Price = data.Price;
            item.Description = data.Description;
            item.Quantity = data.Quantity;
            item.Discount = data.Discount;
            DataContext.SubmitChanges();
        }
    }
}
