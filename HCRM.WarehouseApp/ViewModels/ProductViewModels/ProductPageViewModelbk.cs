using HCRM.WarehouseApp.Framework;
using System;
using HCRM.WarehouseApp.ViewInterfaces;
using System.Windows.Input;
using HCRM.Data;
using System.Windows;
using HCRM.WarehouseApp.Helpers;
using HCRM.WarehouseApp.Ultilities;
using System.Collections.Generic;
using System.Linq;

namespace HCRM.WarehouseApp.ViewModels.ProductViewModels
{
    public class ProductPageViewModelbk : ObjectBase, IPageViewModel
    {
        #region Properties

        //public CreateProductViewModel Model { get; private set; }
        private CRM_Product _currentProduct;
        private List<CRM_Product> products;
        private List<CRM_Product> currentListproduct;
        private string keyword;
        private ICommand searchCommand;
        private ICommand createOrEditCommand;
        private ICommand newProductCommand;
        private string filter;

        public CRM_Product CurrentProduct
        {
            get {
                if (_currentProduct==null)
                {
                    _currentProduct = new CRM_Product();
                }
                return _currentProduct;

            }
            set
            {
                if (value != _currentProduct)
                {
                    _currentProduct = value;
                    OnPropertyChanged("CurrentProduct");
                }
            }
        }
     
        public string Key
        {
            get
            {
                return Helpers.Parameters.PageView.CreateProduct;
            }
        }

        public string PageTitle
        {
            get
            {
                return "Create Product Page";
            }
        }

        public List<CRM_Product> Products
        {
            get
            {                
                return products;
            }

            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }

        #endregion

        #region Commands
       
        

        public ICommand CreateOrEditCommand
        {
            get
            {
                if (createOrEditCommand == null)
                {
                    createOrEditCommand = new RelayCommand(
                        p => CreateOrEditProduct());
                }

                return createOrEditCommand;
            }
        }       

        public ICommand NewProductCommand
        {
            get
            {
                if (newProductCommand == null)
                {
                    newProductCommand = new RelayCommand(
                        p => RefreshProduct());
                }
                return newProductCommand;
            }

            set
            {
                newProductCommand = value;
            }
        }

        public string Keyword
        {
            get
            {
                return keyword;
            }

            set
            {
                keyword = value;
                OnPropertyChanged("Keyword");
            }
        }

        public string Filter
        {
            get
            {
                return filter;
            }

            set
            {
                filter = value.ToLower();
                OnPropertyChanged("Filter");
                FilterProducts();
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new RelayCommand(
                        p => SearchProducts());
                }
                return searchCommand;
            }

            set
            {
                searchCommand = value;
            }
        }

        public List<CRM_Product> CurrentListproduct
        {
            get
            {
                return currentListproduct;
            }

            set
            {
                currentListproduct = value;
                Products = currentListproduct;
            }
        }


        #endregion

        #region Functions

        void RefreshProduct() {
            CurrentProduct = new CRM_Product();            
        }
        async void ReFreshProducts() {
            CurrentListproduct = await ProductHelperbk.GetListProduct();
        }

        async void SearchProducts()
        {
            CurrentListproduct = await ProductHelperbk.SearchProducts(Keyword);
        }

        void FilterProducts() {
            Products = CurrentListproduct.Where(p => Filter == "" || p.Title.ToLower().Contains(Filter) || p.Code.ToLower().Contains(Filter) || p.Source.ToLower().Contains(Filter)).ToList();
        }



        async void CreateOrEditProduct()
        {
            try
            {


                if (CurrentProduct.ProductID<=0)
                {
                    CurrentProduct.CreatedDate = DateTime.Now;
                    CurrentProduct.Views = 0;
                    CurrentProduct.CreatedBy = App.currUser.username;
                    CurrentProduct.IsDeleted = false;
                    if (CurrentProduct.DisplayOrder == null)
                        CurrentProduct.DisplayOrder = 0;

                }

                var result = await ProductHelperbk.CreateOrEditProduct(CurrentProduct);
                if (result)
                {
                    ApiHelper.Alert("Lưu ý", "Lưu sản phẩm thành công");
                }
                else
                {
                    ApiHelper.Alert("Lưu ý", "Không thể lưu sản phẩm");
                }
            }
            catch (Exception ex)
            {
                ApiHelper.Alert("Lưu ý", ex.Message);
            }
        }

       
        #endregion
        public ProductPageViewModelbk() : base()
        {
            ReFreshProducts();
            //CurrentProduct = new ProductViewModel();
        }
    }
}
