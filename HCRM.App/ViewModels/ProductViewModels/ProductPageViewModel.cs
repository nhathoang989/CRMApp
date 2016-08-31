using HCRM.App.Framework;
using System;
using HCRM.App.ViewInterfaces;
using System.Windows.Input;
using HCRM.Data;
using System.Windows;
using HCRM.App.Helpers;
using HCRM.App.Ultilities;
using System.Collections.Generic;
using System.Windows.Controls;
using HCRM.App.ViewModels.ElementViewModels;
using HCRM.App.Repositories;
using Prism.Events;
using HCRM.App.Behaviors;
using HCRM.App.Services;

namespace HCRM.App.ViewModels.ProductViewModels
{
    public class ProductPageViewModel : ObjectBase, IPageViewModel
    {
        #region Properties

        //public CreateProductViewModel Model { get; private set; }
        private int PageSize = 5;
        private PagingViewModel<CRM_Product,ProductViewModel> _pagingViewModel;
        private ProductViewModel _currentProduct;
        private List<ProductViewModel> _products;
        private List<ProductViewModel> _listAllProduct;
        private List<ProductViewModel> currentListProduct;

        private IEventAggregator _eventAggregator;
        private ICommand _newProductCommand;
        
        public ProductViewModel CurrentItem
        {
            get {
                if (_currentProduct==null)
                {
                    _currentProduct = new ProductViewModel();
                }
                return _currentProduct;

            }
            set
            {
                if (value != _currentProduct)
                {
                    
                    _currentProduct = value;
                    
                    OnPropertyChanged("CurrentItem");
                }
            }
        }
     
        public string Key
        {
            get
            {
                return Helpers.Parameters.PageView.ProductPage;
            }
        }

        public string PageTitle
        {
            get
            {
                return "Product Page";
            }
        }

        public List<ProductViewModel> Products
        {
            get
            {
                return _products;
            }

            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        #endregion

        #region Commands
       
        public ICommand NewProductCommand
        {
            get
            {
                if (_newProductCommand == null)
                {
                    _newProductCommand = new RelayCommand(
                        p => NewProduct());
                }
                return _newProductCommand;
            }

            set
            {
                _newProductCommand = value;
            }
        }
       
        public List<ProductViewModel> CurrentListProduct
        {
            get
            {
                return currentListProduct;
            }

            set
            {
                currentListProduct = value;
                Products = currentListProduct;
            }
        }

        public List<ProductViewModel> ListAllProduct
        {
            get
            {                
                return _listAllProduct;
            }

            set
            {
                _listAllProduct = value;
            }
        }


        #endregion

        #region Functions

        private void NewProduct()
        {
            CurrentItem = new ProductViewModel();
        }

        async void ReFreshProducts() {
            PagingViewModel = new PagingViewModel<CRM_Product, ProductViewModel>("api/Product","Product", PageSize);

            CurrentListProduct = await ProductRepo.Instance.GetModelList();
        }

        public AutoCompleteFilterPredicate<object> ProductFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as ProductViewModel).Title.ToLower().Contains(searchText.ToLower())
                    || (obj as ProductViewModel).Code.ToLower().Contains(searchText.ToLower());
            }
        }

        public PagingViewModel<CRM_Product, ProductViewModel> PagingViewModel
        {
            get
            {
                return _pagingViewModel;
            }

            set
            {
                _pagingViewModel = value;
                OnPropertyChanged("PagingViewModel");
            }
        }

        private void ItemsChanged(bool isChanged)
        {
            if (isChanged)
            {
                ApiHelper.Alert("Kết quả", "Thành công");
                ReFreshProducts();
            }
            else
            {
                ApiHelper.Alert("Kết quả", "Thất bại");
            }
        }

        #endregion
        public ProductPageViewModel() : base()
        {

            ReFreshProducts();
            _eventAggregator = ApplicationService.Instance.EventAggregator;

            ItemListChanged<bool> _event = ApplicationService.Instance.EventAggregator.GetEvent<ItemListChanged<bool>>();
            _event.Subscribe(ItemsChanged);

        }
    }
}
