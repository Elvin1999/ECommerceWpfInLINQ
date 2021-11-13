using ECommerceApp.Commands;
using ECommerceApp.DataAccess.SqlServer;
using ECommerceApp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp.Domain.ViewModels
{
   public class MainViewModel:BaseViewModel
    {

        private readonly IRepository<Product> _productRepo;
        public RelayCommand SelectProductCommand { get; set; }
        public MainViewModel(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
            AllProducts = _productRepo.GetAllData();

            SelectProductCommand = new RelayCommand((sender) =>
              {
                  MessageBox.Show(SelectedProduct.Name);
              });
        }

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }
        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }


    }
}
