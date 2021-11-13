using ECommerceApp.Commands;
using ECommerceApp.DataAccess.SqlServer;
using ECommerceApp.Domain.Abstractions;
using ECommerceApp.Domain.Services;
using ECommerceApp.Domain.Views;
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
        private readonly ProductService _productService;
        public RelayCommand SelectProductCommand { get; set; }
        public RelayCommand ToLowerCommand { get; set; }
        public RelayCommand OpenAdminCommand { get; set; }
        public MainViewModel(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
            _productService = new ProductService();
            AllProducts = _productRepo.GetAllData();
            OpenAdminCommand = new RelayCommand((sender) =>
              {
                  var vm = new AdminViewModel();
                  var view = new AdminWindow();
                  view.DataContext = vm;
                  view.ShowDialog();
              });
            ToLowerCommand = new RelayCommand((sender) =>
              {
                  AllProducts = _productService.GetFromLowerToHigher();
              });

            SelectProductCommand = new RelayCommand((sender) =>
              {
                  var vm = new ProductInfoViewModel();
                  vm.ProductInfo = SelectedProduct;
                  var view = new ProductWindow();
                  view.DataContext = vm;
                  view.ShowDialog();
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
