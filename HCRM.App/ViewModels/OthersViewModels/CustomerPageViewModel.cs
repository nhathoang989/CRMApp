using HCRM.App.Framework;
using System;
using HCRM.App.ViewInterfaces;
using System.Windows.Input;
using HCRM.Data;
using System.Windows;
using HCRM.App.Helpers;
using HCRM.App.Ultilities;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using HCRM.App.Repositories;

namespace HCRM.App.ViewModels.OthersViewModels
{
    public class CustomerPageViewModel : ObjectBase, IPageViewModel
    {
        #region Properties

        //public CreateCustomerViewModel Model { get; private set; }
        private CRM_Customer _currentCustomer;
        private CRM_Address _currentAddress;
        private List<CRM_Customer> _Customers;
        private List<CRM_Customer> _listAllCustomer;
        private List<CRM_Customer> currentListCustomer;
        private string keyword;
        private ICommand _searchCommand;
        private ICommand _saveCommand;
        private ICommand _newCustomerCommand;
        private FileDialogViewModel _fileDlg;
        private string _filter;
        private string _currentAvatar;
        private string _selectedPath;
        public string SelectedPath
        {
            get { return _selectedPath; }
            set { _selectedPath = value; OnPropertyChanged("SelectedPath"); }
        }
        public CRM_Customer CurrentCustomer
        {
            get
            {
                if (_currentCustomer == null)
                {
                    _currentCustomer = new CRM_Customer();
                }
                return _currentCustomer;

            }
            set
            {
                if (value != _currentCustomer)
                {

                    _currentCustomer = value;
                    if (value != null)
                    {
                        if (_currentCustomer.CRM_Address != null && CurrentCustomer.CRM_Address.Count > 0)
                        {
                            CurrentAddress = CurrentCustomer.CRM_Address.First();
                        }
                        CurrentAvatar = common.getFullFilePath(_currentCustomer.Avatar);
                    }
                    else
                    {
                        CurrentAddress = null;
                        CurrentAvatar = null;
                    }
                    OnPropertyChanged("CurrentCustomer");
                }
            }
        }

        public string Key
        {
            get
            {
                return Helpers.Parameters.PageView.CustomerPage;
            }
        }

        public string PageTitle
        {
            get
            {
                return "Customer Page";
            }
        }

        public List<CRM_Customer> Customers
        {
            get
            {
                return _Customers;
            }

            set
            {
                _Customers = value;
                OnPropertyChanged("Customers");
            }
        }

        #endregion

        #region Commands



        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        p => SaveCustomer(),

                        p => CanSave());
                }

                return _saveCommand;
            }
        }

        public ICommand NewCustomerCommand
        {
            get
            {
                if (_newCustomerCommand == null)
                {
                    _newCustomerCommand = new RelayCommand(
                        p => RefreshForm());
                }
                return _newCustomerCommand;
            }

            set
            {
                _newCustomerCommand = value;
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
                return _filter;
            }

            set
            {
                _filter = value.ToLower();
                OnPropertyChanged("Filter");
                FilterCustomers();
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(
                        p => SearchCustomers(),
                        p => CanSearch());
                }
                return _searchCommand;
            }

            set
            {
                _searchCommand = value;
            }
        }

        public List<CRM_Customer> CurrentListCustomer
        {
            get
            {
                return currentListCustomer;
            }

            set
            {
                currentListCustomer = value;
                Customers = currentListCustomer;
            }
        }

        public CRM_Address CurrentAddress
        {
            get
            {
                if (_currentAddress == null)
                {
                    _currentAddress = new CRM_Address();
                }
                return _currentAddress;
            }

            set
            {
                _currentAddress = value;
                OnPropertyChanged("CurrentAddress");
            }
        }


        public FileDialogViewModel FileDlg
        {
            get
            {
                if (_fileDlg == null)
                {
                    _fileDlg = new FileDialogViewModel();
                }
                return _fileDlg;
            }

            set
            {
                _fileDlg = value;
            }
        }

        public string CurrentAvatar
        {
            get
            {
                return _currentAvatar;
            }

            set
            {
                _currentAvatar = value;
                OnPropertyChanged("CurrentAvatar");
            }
        }

        public List<CRM_Customer> ListAllCustomer
        {
            get
            {
                return _listAllCustomer;
            }

            set
            {
                _listAllCustomer = value;
            }
        }


        #endregion

        #region Functions

        bool CanSave()
        {
            return CurrentCustomer != null && CurrentCustomer.Name != null && CurrentCustomer.PhoneNumber != null;
            //return !string.IsNullOrEmpty(Keyword);
        }
        bool CanSearch()
        {
            return true;
            //return !string.IsNullOrEmpty(Keyword);
        }
        void RefreshForm()
        {
            CurrentCustomer = new CRM_Customer();
            CurrentAvatar = "";
            CurrentAddress = null;
        }
        async void ReFreshCustomers()
        {
            CurrentListCustomer = await CustomerRepo.GetCustomerList(0, 10);
        }

        async void SearchCustomers()
        {
            CurrentListCustomer = await CustomerRepo.SearchCustomers(Keyword);
            CurrentCustomer = CurrentListCustomer.FirstOrDefault();
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
        void FilterCustomers()
        {
            Customers = CurrentListCustomer.Where(p => Filter == "" || p.Name.ToLower().Contains(Filter) || p.Email.ToLower().Contains(Filter) || p.PhoneNumber.ToLower().Contains(Filter)).ToList();
        }
        async void SaveCustomer()
        {
            try
            {


                if (CurrentCustomer.CustomerID <= 0)
                {
                    CurrentCustomer.CreatedDate = DateTime.Now;
                    CurrentCustomer.CreatedBy = App.currUser.username;
                    CurrentCustomer.IsDeleted = false;
                }
                if (CurrentAddress != null && (!string.IsNullOrEmpty(CurrentAddress.Street) || !string.IsNullOrEmpty(CurrentAddress.City)))
                {
                    //CurrentAddress.CRM_Customer = CurrentCustomer;
                    CurrentAddress.CustomerID = CurrentCustomer.CustomerID;
                    CurrentCustomer.CRM_Address.Add(CurrentAddress);
                }
                CurrentCustomer.Email = CurrentCustomer.Email == null ? "" : CurrentCustomer.Email;
                var result = await CustomerRepo.CreateOrEditCustomer(CurrentCustomer, FileDlg.Info);
                if (result)
                {
                    CurrentAvatar = common.getFullFilePath(CurrentCustomer.Avatar);
                    ApiHelper.Alert("Lưu ý", "Lưu nhân viên thành công");
                }
                else
                {
                    ApiHelper.Alert("Lưu ý", "Không thể lưu nhân viên");
                }
            }
            catch (Exception ex)
            {
                ApiHelper.Alert("Lưu ý", ex.Message);
            }
        }


        #endregion
        public CustomerPageViewModel() : base()
        {
            ReFreshCustomers();

            //CurrentCustomer = new CustomerViewModel();
        }
    }
}
