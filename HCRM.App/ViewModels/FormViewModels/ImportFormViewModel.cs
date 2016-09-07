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

namespace HCRM.App.ViewModels
{
    public class ImportFormViewModel : ObjectBase, IPageViewModel
    {
        #region Properties
        
        private ReceiptImportViewModel _currentReceipt;
        private ReceiptDetailsViewModel _currentDetails;
        private List<ReceiptDetailsViewModel> _lstDisplayDetails;
        private ProductViewModel _selectedProduct;
        private EmployeeViewModel _selectedEmployee;
        private ProviderViewModel _selectedProvider;

        private List<EmployeeViewModel> _employees;
        private List<ProviderViewModel> _providers;
        private List<ProductViewModel> _products;
        private PagingViewModel<CRM_Product, ProductViewModel> _pagingDataGrid;

        private ICommand _addToCartCommand;
        private ICommand _removeCommand;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        private PagingViewModel<CRM_Employee, EmployeeViewModel> _pagingViewModel;
        private int PageSize = 5;
        private bool _isBusy;
        private IEventAggregator _eventAggregator;

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
                        p => RemoveDetails()
                        );
                }
                return _removeCommand;
            }

            set
            {
                _removeCommand = value;
            }
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
           
            Refresh();

        }
        void Refresh() {
            GetTotal();
            LstDisplayDetails = new List<ReceiptDetailsViewModel>(CurrentReceipt.ListDetails);
            //CurrentDetails = new ReceiptDetailsViewModel();
        }
        void RefreshForm() {
            CurrentReceipt = new ReceiptImportViewModel();
            Refresh();
            CurrentReceipt = new ReceiptImportViewModel();            
        }
        #region Filters
        //public AutoCompleteFilterPredicate<object> ProductFilter
        //{
        //    get
        //    {
        //        return (searchText, obj) =>
        //             (!string.IsNullOrEmpty((obj as ProductViewModel).Title) && (obj as ProductViewModel).Title.Contains(searchText))
        //             || (!string.IsNullOrEmpty((obj as ProductViewModel).Code) && (obj as ProductViewModel).Code.Contains(searchText));
        //    }
        //}
        public AutoCompleteFilterPredicate<object> EmployeeFilter
        {
            get
            {
                return (searchText, obj) =>
                   (obj as EmployeeViewModel).Name.Contains(searchText)
                   || (obj as EmployeeViewModel).PhoneNumber.Contains(searchText);
            }
        }
        public AutoCompleteFilterPredicate<object> ProviderFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as CRM_Provider).Name.ToLower().Contains(searchText.ToLower())
                    || (obj as CRM_Provider).PhoneNumber.Contains(searchText.ToLower())
                    || (obj as CRM_Provider).Email.ToLower().Contains(searchText.ToLower());
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

        public List<ProviderViewModel> Providers
        {
            get
            {
                return _providers;
            }

            set
            {
                _providers = value;
                OnPropertyChanged("Providers");
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

        public ProviderViewModel SelectedProvider
        {
            get
            {
                return _selectedProvider;
            }

            set
            {
                _selectedProvider = value;
                if (value!=null)
                {
                    CurrentReceipt.Provider = _selectedProvider;
                    CurrentReceipt.ReceiveName = value.Name;
                    if (value.ListAddress!=null && value.ListAddress.Count>0)
                    {
                        CurrentReceipt.ReceiveAddress = value.ListAddress.First().Street;
                    }
                    CurrentReceipt.ReceivePhone = value.PhoneNumber;
                    
                }
                OnPropertyChanged("SelectedProvider");
            }
        }

        public ReceiptImportViewModel CurrentReceipt
        {
            get
            {
                if (_currentReceipt==null)
                {
                    _currentReceipt = new ReceiptImportViewModel();
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

            if (CurrentReceipt.TotalPaid >= CurrentReceipt.TotalMustPay)
            {
                CurrentReceipt.IsPaid = true;                
            }
            if (SelectedProvider!=null)
            {
                CurrentReceipt.ProviderID = SelectedProvider.ProviderID;
            }
            if (SelectedEmployee!=null)
            {
                CurrentReceipt.EmployeeID = SelectedEmployee.EmployeeID;
            }
         
        }
        
        bool validateReceipt() {
            return CurrentReceipt.ListDetails.Count > 0;                
        }
        
        void RemoveDetails() {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Xóa sản phẩm này khỏi danh sách?", "Lưu ý", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                CurrentReceipt.ListDetails.Remove(CurrentDetails);
                Refresh();
            }
        }

        #endregion

        async void RefreshPage() {
            IsBusy = true;
            Products = await ProductRepo.Instance.GetModelList();
            Employees = await EmployeeRepo.Instance.GetModelList();
            Providers = await ProviderRepo.Instance.GetModelList();
            CurrentReceipt = new ReceiptImportViewModel();
            SelectedProduct = null;
            Refresh();
            CurrentDetails = new ReceiptDetailsViewModel();
            PagingDataGrid = new PagingViewModel<CRM_Product, ProductViewModel>(Products, PageSize);
            IsBusy = false;
        }
        public ImportFormViewModel()
        {
            RefreshPage();
            _eventAggregator = ApplicationService.Instance.GlobalEventAggregator;

            SaveReceiptResultEvent<bool> _event = ApplicationService.Instance.ActiveEventAggregator.GetEvent<SaveReceiptResultEvent<bool>>();
            _event.Subscribe(SaveResult);

            ProductListChanged _productListEvent = ApplicationService.Instance.GlobalEventAggregator.GetEvent<ProductListChanged>();
            _productListEvent.Subscribe(ProductChanged);
        }

        private void ProductChanged(bool obj)
        {
            if (obj)
            {
                RefreshPage();
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
