﻿using HCRM.App.Framework;
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
        private bool _isShowDetails;
        private PagingViewModel<CRM_Product,ProductViewModel> _pagingDataGrid;
        private ProductViewModel _currentProduct;
        private List<ProductViewModel> _products;
        private List<ProductViewModel> _listAllProduct;
        private List<ProductViewModel> currentListProduct;
        private bool _isBusy;
        private IEventAggregator _eventHandler;
        private ICommand _newProductCommand;
        
        public ProductViewModel CurrentItem
        {
            get {
                if (_currentProduct==null)
                {
                    _currentProduct = new ProductViewModel(EventHandler);
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
            CurrentItem = new ProductViewModel(EventHandler);
            CurrentItem.Preview();
        }

        async void ReFreshProducts() {
            IsBusy = true;
            CurrentListProduct = await ProductRepo.Instance.GetModelList();
            PagingDataGrid = new PagingViewModel<CRM_Product, ProductViewModel>(CurrentListProduct, PageSize);
            IsBusy = false;
        }

        public AutoCompleteFilterPredicate<object> ProductFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as ProductViewModel).Title.Contains(searchText)
                    || (obj as ProductViewModel).Code.Contains(searchText);
            }
        }

        public PagingViewModel<CRM_Product, ProductViewModel> PagingDataGrid
        {
            get
            {
                return _pagingDataGrid;
            }

            set
            {
                _pagingDataGrid = value;
                OnPropertyChanged("PagingDataGrid");
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public bool IsShowDetails
        {
            get
            {
                if (_isShowDetails)
                {
                    return false;
                }
                return _isShowDetails;
            }

            set
            {
                _isShowDetails = value;
                OnPropertyChanged("IsShowDetails");
            }
        }

        public IEventAggregator EventHandler
        {
            get
            {
                if (_eventHandler==null)
                {
                    _eventHandler = ApplicationService.Instance.GlobalEventAggregator;
                }
                return _eventHandler;
            }

            set
            {
                _eventHandler = value;
            }
        }

        private void ProductChanged(bool isChanged)
        {
            if (isChanged)
            {
                ReFreshProducts();
            }
        }

        #endregion
        public ProductPageViewModel() : base()
        {

            ReFreshProducts();
            EventHandler = ApplicationService.Instance.GlobalEventAggregator;

            ProductListChanged _event = ApplicationService.Instance.GlobalEventAggregator.GetEvent<ProductListChanged>();
            _event.Subscribe(ProductChanged);

        }
    }
}
