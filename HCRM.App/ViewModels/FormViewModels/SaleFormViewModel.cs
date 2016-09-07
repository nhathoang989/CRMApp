using HCRM.Data;
using HCRM.App.Behaviors;
using HCRM.App.Framework;
using HCRM.App.Repositories;
using HCRM.App.Services;
using HCRM.App.Ultilities;
using HCRM.App.ViewInterfaces;
using HCRM.App.ViewModels.ElementViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Events;
using System;

namespace HCRM.App.ViewModels
{
    public class SaleFormViewModel : ObjectBase, IPageViewModel
    {
        #region Properties
        
        private ReceiptDeliveryViewModel _currentReceipt;
        private ReceiptDetailsViewModel _currentDetails;
        private List<ReceiptDetailsViewModel> _lstDisplayDetails;
        private ProductViewModel _selectedProduct;
        private EmployeeViewModel _selectedEmployee;
        private CustomerViewModel _selectedCustomer;

        private List<EmployeeViewModel> _employees;
        private List<CustomerViewModel> _customers;
        private List<ProductViewModel> _products;
        private PagingViewModel<CRM_Product, ProductViewModel> _pagingDataGrid;

        private ICommand _addToCartCommand;
        private ICommand _removeCommand;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        private PagingViewModel<CRM_Employee, EmployeeViewModel> _pagingViewModel;
        private int PageSize = 5;
        private bool _isBusy;
        private IEventAggregator _saleEventAggregator;

        private int _errors;

        public ReceiptDetailsViewModel CurrentDetails
        {
            get
            {
                if (_currentDetails == null)
                {
                    _currentDetails = new ReceiptDetailsViewModel();
                }
                return _currentDetails;
            }

            set
            {

                _currentDetails = value;         
                OnPropertyChanged("CurrentDetails");
            }
        }        

        public ICommand AddToCartCommand
        {
            get
            {
                if (_addToCartCommand == null)
                {
                    _addToCartCommand = new RelayCommand(
                        p => AddToCart(),
                        p=> CanAddToCart());
                }
                return _addToCartCommand;
            }

            set
            {
                _addToCartCommand = value;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        p => SaveReceipt(),
                        p=> CanSaveReceipt()
                        );
                }
                return _saveCommand;
            }

            set
            {
                _saveCommand = value;
            }
        }
       
        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand(
                        p => RemoveDetails(),
                        p=>CanRemove()
                        );
                }
                return _removeCommand;
            }

            set
            {
                _removeCommand = value;
            }
        }

        private bool CanRemove()
        {
            return CurrentReceipt.ListDetails.Contains(CurrentDetails);
        }

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(
                        p => CancelReceipt()
                        );
                }
                return _cancelCommand;
            }

            set
            {
                _cancelCommand = value;
            }
        }

        public string PageTitle
        {
            get
            {
                return "Bán hàng";
            }
        }

        public string Key
        {
            get
            {
                return "SaleForm";
            }
        }
        
        public int ErrorCount
        {
            get
            {
                return _errors;
            }

            set
            {
                _errors = value;                
            }
        }

        #endregion

        #region Functions
        void CancelReceipt() {

        }
        bool CanAddToCart() {            
            return CurrentDetails.Product != null && !string.IsNullOrEmpty(CurrentDetails.Product.Code) && CurrentDetails.Quantity<=CurrentDetails.Product.TotalRemain;
        }
        bool CanSaveReceipt() {
            return ErrorCount == 0 && CurrentReceipt.ListDetails.Count > 0;
        }
        void AddToCart() {
            var details = CurrentReceipt.ListDetails.FirstOrDefault(d => d.Product.ProductID == CurrentDetails.Product.ProductID);
            
            if (details == null)
            {
                //CurrentDetails.StrUnitPrice = common.FormatPrice(CurrentDetails.Product.NormalPrice.ToString());
                CurrentDetails.ReducePrice = common.ReversePrice(CurrentDetails.StrReducePrice);
                CurrentDetails.UnitPrice = SelectedProduct.NormalPrice;
                CurrentDetails.StrUnitPrice = common.FormatPrice(SelectedProduct.NormalPrice.ToString());
                CurrentReceipt.ListDetails.Add(CurrentDetails);
            }
            else
            {
                details.Quantity = CurrentDetails.Quantity;
                details.ReducePrice = common.ReversePrice(CurrentDetails.StrReducePrice);
                details.UnitPrice = CurrentDetails.UnitPrice;
                details.StrUnitPrice = CurrentDetails.StrUnitPrice;
                details.StrReducePrice = CurrentDetails.StrReducePrice;
                details.Quantity = CurrentDetails.Quantity;
            }
           
            RefreshReceiptValues();

        }
        void RefreshReceiptValues() {
            GetTotal();
            LstDisplayDetails = new List<ReceiptDetailsViewModel>(CurrentReceipt.ListDetails);
            //CurrentDetails = new ReceiptDetailsViewModel();
        }
        void RefreshForm() {
            CurrentReceipt = new ReceiptDeliveryViewModel();
            RefreshReceiptValues();
            CurrentReceipt = new ReceiptDeliveryViewModel();            
        }
        #region Filters
        public AutoCompleteFilterPredicate<object> ProductFilter
        {
            get
            {
                return (searchText, obj) =>
                     (!string.IsNullOrEmpty((obj as ProductViewModel).Title) && (obj as ProductViewModel).Title.ToLower().Contains(searchText.ToLower()))
                    || (!string.IsNullOrEmpty((obj as ProductViewModel).Code) && (obj as ProductViewModel).Code.ToLower().Contains(searchText.ToLower()));
            }
        }
        public AutoCompleteFilterPredicate<object> EmployeeFilter
        {
            get
            {
                return (searchText, obj) =>
                   (!string.IsNullOrEmpty((obj as EmployeeViewModel).Name) && (obj as EmployeeViewModel).Name.ToLower().Contains(searchText))
                   || (!string.IsNullOrEmpty((obj as EmployeeViewModel).PhoneNumber) && (obj as EmployeeViewModel).PhoneNumber.ToLower().Contains(searchText));
            }
        }
        public AutoCompleteFilterPredicate<object> CustomerFilter
        {
            get
            {
                return (searchText, obj) =>
                    (!string.IsNullOrEmpty((obj as CustomerViewModel).Name) && (obj as CustomerViewModel).Name.ToLower().Contains(searchText.ToLower()))
                    || (!string.IsNullOrEmpty((obj as CustomerViewModel).PhoneNumber) && (obj as CustomerViewModel).PhoneNumber.Contains(searchText.ToLower()))
                    || (!string.IsNullOrEmpty((obj as CustomerViewModel).Email) && (obj as CustomerViewModel).Email.ToLower().Contains(searchText.ToLower()));
            }
        }
        #endregion

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

        public ProductViewModel SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }

            set
            {
                _selectedProduct = value;
                if (_selectedProduct != null)
                {
                    var details = CurrentReceipt.ListDetails.FirstOrDefault(d => d.Product.ProductID == SelectedProduct.ProductID);
                    if (details != null)
                    {
                        CurrentDetails = details;
                    }
                    else
                    {
                        CurrentDetails = new ReceiptDetailsViewModel();
                        CurrentDetails.Product = _selectedProduct;
                        CurrentDetails.UnitPrice = _selectedProduct.NormalPrice;
                        CurrentDetails.StrUnitPrice = _selectedProduct.StrNormalPrice;
                        CurrentDetails.Product.Image = common.getFullFilePath(value.Image);
                    }
                    CurrentDetails.ProductID = _selectedProduct.ProductID;
                }
                OnPropertyChanged("SelectedProduct");
            }
        }

        public List<CustomerViewModel> Customers
        {
            get
            {
                return _customers;
            }

            set
            {
                _customers = value;
                OnPropertyChanged("Customers");
            }
        }

        public List<EmployeeViewModel> Employees
        {
            get
            {
                return _employees;
            }

            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public EmployeeViewModel SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }

            set
            {
              _selectedEmployee = value;
                CurrentReceipt.Employee = _selectedEmployee;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public CustomerViewModel SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }

            set
            {
                _selectedCustomer = value;
                if (value!=null)
                {
                    CurrentReceipt.Customer = _selectedCustomer;
                    CurrentReceipt.ReceiveName = value.Name;
                    if (value.ListAddress != null && value.ListAddress.Count>0)
                    {
                        CurrentReceipt.ReceiveAddress = value.ListAddress.First().Street;
                    }
                    CurrentReceipt.ReceivePhone = value.PhoneNumber;
                    
                }
                OnPropertyChanged("SelectedCustomer");
            }
        }

        public ReceiptDeliveryViewModel CurrentReceipt
        {
            get
            {
                if (_currentReceipt==null)
                {
                    _currentReceipt = new ReceiptDeliveryViewModel();
                }
                return _currentReceipt;
            }

            set
            {
                _currentReceipt = value;
                OnPropertyChanged("CurrentReceipt");
            }
        }

        public List<ReceiptDetailsViewModel> LstDisplayDetails
        {
            get
            {
                return _lstDisplayDetails;
            }

            set
            {
                _lstDisplayDetails = value;
                OnPropertyChanged("LstDisplayDetails");
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

        public PagingViewModel<CRM_Employee, EmployeeViewModel> PagingViewModel
        {
            get
            {
                return _pagingViewModel;
            }

            set
            {
                _pagingViewModel = value;
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

        public IEventAggregator SaleEventAggregator
        {
            get
            {
                if (_saleEventAggregator==null)
                {
                    _saleEventAggregator = new EventAggregator();
                }
                return _saleEventAggregator;
            }

            set
            {
                _saleEventAggregator = value;
            }
        }

        public IEventAggregator PageEvent
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        void GetTotal() {
            double totalAmount = 0;
            double totalReduce = 0;
            foreach (var details in CurrentReceipt.ListDetails)
            {
                totalAmount += details.UnitPrice * details.Quantity;
                totalReduce += details.ReducePrice * details.Quantity;
            }
            CurrentReceipt.TotalAmount = totalAmount;
            CurrentReceipt.TotalReduceAmount = totalReduce;            
            CurrentReceipt.TotalMustPay = totalAmount - totalReduce;
            CurrentReceipt.TotalRemain = totalAmount - totalReduce - CurrentReceipt.TotalPaid;

        }

        void SaveReceipt() {

            //IsBusy = true;
            if (CurrentReceipt.TotalPaid >= CurrentReceipt.TotalMustPay)
            {
                CurrentReceipt.IsPaid = true;                
            }
            if (SelectedCustomer!=null)
            {
                CurrentReceipt.CustomerID = SelectedCustomer.CustomerID;
            }
            if (SelectedEmployee!=null)
            {
                CurrentReceipt.EmployeeID = SelectedEmployee.EmployeeID;
            }

            
            
            //Views.PrintViews.PrintPreview wd = new Views.PrintViews.PrintPreview(CurrentReceipt);
            //wd.ShowDialog();
            ////return;

            //var result = await ReceiptDeliveryRepo.Instance.SaveModel(CurrentReceipt.Model);

            //if (result.StatusCode== System.Net.HttpStatusCode.OK)
            //{
            //    RefreshPage();
            //    //ApiHelper.Alert("Lưu ý", "Lưu hóa đơn thành công");
            //}
            //else
            //{
            //    //ApiHelper.Alert("Lưu ý", "Không thể lưu hóa đơn");
            //}

            //IsBusy = false;
        }
        
        bool validateReceipt() {
            return CurrentReceipt.ListDetails.Count > 0;                
        }
        
        void RemoveDetails() {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Xóa sản phẩm này khỏi danh sách?", "Lưu ý", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                CurrentReceipt.ListDetails.Remove(CurrentDetails);
                RefreshReceiptValues();
            }
        }

        #endregion
        async void RefreshPage() {
            IsBusy = true;
            Products = await ProductRepo.Instance.GetModelList();
            Employees = await EmployeeRepo.Instance.GetModelList();
            Customers = await CustomerRepo.Instance.GetModelList();
            CurrentReceipt = new ReceiptDeliveryViewModel(SaleEventAggregator);
            SelectedProduct = null;
            RefreshReceiptValues();
            CurrentDetails = new ReceiptDetailsViewModel();
            PagingDataGrid = new PagingViewModel<CRM_Product, ProductViewModel>(Products, PageSize);
            IsBusy = false;
        }
        public SaleFormViewModel()
        {
            RefreshPage();
            //ApplicationService.Instance.ActiveEventAggregator = new EventAggregator();

            SaveReceiptResultEvent<bool> _event = SaleEventAggregator.GetEvent<SaveReceiptResultEvent<bool>>(); //ApplicationService.Instance.ActiveEventAggregator.GetEvent<SaveReceiptResultEvent<bool>>();
            _event.Subscribe(SaveResult);

            ProductListChanged _productListEvent = ApplicationService.Instance.GlobalEventAggregator.GetEvent<ProductListChanged>();
            _productListEvent.Subscribe(ProductChanged);
        }

        private void ProductChanged(bool obj)
        {
            if (obj)
            {
                //RefreshPage();
                foreach (var details in CurrentReceipt.ListDetails)
                {
                    details.Product = Products.FirstOrDefault(p => p.ProductID == details.ProductID);
                    details.UnitPrice = details.Product.NormalPrice;
                    details.StrUnitPrice = common.FormatPrice(details.UnitPrice.ToString());
                }
                RefreshReceiptValues();
            }
        }

        private void SaveResult(bool result)
        {
            if (result)
            {
                RefreshPage();
            }
        }
    }
}
