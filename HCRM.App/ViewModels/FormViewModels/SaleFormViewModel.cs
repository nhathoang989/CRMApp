﻿using HCRM.Data;
using HCRM.App.Behaviors;
using HCRM.App.Framework;
using HCRM.App.Helpers;
using HCRM.App.Repositories;
using HCRM.App.Services;
using HCRM.App.Ultilities;
using HCRM.App.ViewInterfaces;
using HCRM.App.ViewModels.ElementViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private CRM_Customer _selectedCustomer;

        private List<EmployeeViewModel> _employees;
        private List<CRM_Customer> _customers;
        private List<ProductViewModel> _products;
        
        private ICommand _addToCartCommand;
        private ICommand _removeCommand;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        

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
            return CurrentDetails.Product != null && !string.IsNullOrEmpty(CurrentDetails.Product.Code);
        }
        bool CanSaveReceipt() {
            return ErrorCount == 0 && CurrentReceipt.ListDetails.Count > 0;
        }
        void AddToCart() {
            common.showLoading(true);
            var details = CurrentReceipt.ListDetails.FirstOrDefault(d => d.Product.ProductID == CurrentDetails.Product.ProductID);
            if (details == null)
            {
                CurrentDetails.StrUnitPrice = common.FormatPrice(CurrentDetails.Product.NormalPrice.ToString());
                CurrentReceipt.ListDetails.Add(CurrentDetails);
            }
            else
            {
                details.StrReducePrice = common.FormatPrice(CurrentDetails.Product.NormalPrice.ToString());
                details.Quantity = CurrentDetails.Quantity;
            }
            GetTotal();
            Refresh();
            common.showLoading(false);

        }
        void Refresh() {
            LstDisplayDetails = new List<ReceiptDetailsViewModel>(CurrentReceipt.ListDetails);
            //CurrentDetails = new ReceiptDetailsViewModel();
        }
        void RefreshForm() {
            Refresh();
            CurrentReceipt = new ReceiptDeliveryViewModel();            
        }
        #region Filters
        public AutoCompleteFilterPredicate<object> ProductFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as ProductViewModel).Title.Contains(searchText)
                    || (obj as ProductViewModel).Code.Contains(searchText);
            }
        }
        public AutoCompleteFilterPredicate<object> EmployeeFilter
        {
            get
            {
                return (searchText, obj) =>
                   (obj as EmployeeViewModel).Name.Contains(searchText)
                   || (obj as EmployeeViewModel).PhoneNumber.Contains(searchText);
            }
        }
        public AutoCompleteFilterPredicate<object> CustomerFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as CRM_Customer).Name.ToLower().Contains(searchText.ToLower())
                    || (obj as CRM_Customer).PhoneNumber.Contains(searchText.ToLower())
                    || (obj as CRM_Customer).Email.ToLower().Contains(searchText.ToLower());
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
                    var details = CurrentReceipt.ListDetails.FirstOrDefault(d => d.Product.ProductID == CurrentDetails.Product.ProductID);
                    if (details != null)
                    {
                        CurrentDetails = details;
                    }
                    else
                    {
                        CurrentDetails = new ReceiptDetailsViewModel();
                        CurrentDetails.Product = _selectedProduct;
                        CurrentDetails.Product.Image = common.getFullFilePath(value.Image);
                    }
                }
                OnPropertyChanged("SelectedProduct");
            }
        }

        public List<CRM_Customer> Customers
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
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public CRM_Customer SelectedCustomer
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
                    CurrentReceipt.OrderName = value.Name;
                    if (value.CRM_Address!=null && value.CRM_Address.Count>0)
                    {
                        CurrentReceipt.OrderAddress = value.CRM_Address.First().Street;
                    }
                    CurrentReceipt.OrderPhone = value.PhoneNumber;
                    
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

        async void SaveReceipt() {
            
            common.showLoading(true);            
            
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

            Views.PrintViews.PrintPreview wd = new Views.PrintViews.PrintPreview(CurrentReceipt);
            wd.ShowDialog();
            //return;

            //var result = await ReceiptRepo.CreateReceipt(CurrentReceipt.Model);

            //if (result)
            //{
            //    RefreshForm();
            //    ApiHelper.Alert("Lưu ý", "Lưu hóa đơn thành công");
            //}
            //else {
            //    ApiHelper.Alert("Lưu ý", "Không thể lưu hóa đơn");
            //}

            common.showLoading(false);
        }

        bool validateReceipt() {
            return CurrentReceipt.ListDetails.Count > 0;                
        }
        
        void RemoveDetails() {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Xóa sản phẩm này khỏi danh sách?", "Lưu ý", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
            }
        }

        #endregion
        async void LoadModels() {
            Products = await ProductRepo.Instance.GetModelList();
            Employees = await EmployeeRepo.Instance.GetModelList();
            Customers = await CustomerRepo.GetCustomerList();
        }
        public SaleFormViewModel()
        {
            LoadModels();
            SaveReceiptDeliveryResultEvent _event = ApplicationService.Instance.EventAggregator.GetEvent<SaveReceiptDeliveryResultEvent>();
            _event.Subscribe(SaveResult);
        }

        private void SaveResult(bool result)
        {
            if (result)
            {
                RefreshForm();
                ApiHelper.Alert("Lưu ý", "Lưu hóa đơn thành công");
            }
            else
            {
                ApiHelper.Alert("Lưu ý", "Không thể lưu hóa đơn");
            }
        }
    }
}
