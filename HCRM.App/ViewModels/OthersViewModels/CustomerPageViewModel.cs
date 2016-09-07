using HCRM.App.Framework;
using HCRM.App.ViewInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using HCRM.App.ViewModels.ElementViewModels;
using HCRM.App.Repositories;
using Prism.Events;
using HCRM.App.Services;
using HCRM.App.Behaviors;
using System.Windows.Input;
using HCRM.Data;
using System;
using HCRM.App.Helpers;
using CodeReason.Reports;
using System.Windows.Xps.Packaging;
using System.Data;
using HCRM.App.Views.CustomControls;
using System.IO;
using System.Windows.Media.Imaging;

namespace HCRM.App.ViewModels.OthersViewModels
{
    public class CustomerPageViewModel : ObjectBase, IPageViewModel
    {
        #region Properties

        //public CreateCustomerViewModel Model { get; private set; }
        private PagingViewModel<CRM_Customer, CustomerViewModel> _pagingViewModel;
        private int PageSize = 5;
        private bool _isBusy;
        private CustomerViewModel _currentCustomer;
        private List<CustomerViewModel> _customers;
        private AddressViewModel _currentAddress;
        private List<CustomerViewModel> _listAllCustomer;
        private List<CustomerViewModel> currentListCustomer;
        private ICommand _exportCommand;
        private IEventAggregator _eventAggregator;
        private ICommand _newCustomerCommand;
        public ICommand NewCustomerCommand
        {
            get
            {
                if (_newCustomerCommand == null)
                {
                    _newCustomerCommand = new RelayCommand(p => NewCustomer());
                }
                return _newCustomerCommand;
            }

            set
            {
                NewCustomerCommand = value;
            }
        }

        private void NewCustomer()
        {
            CurrentCustomer = new CustomerViewModel();
        }

        public CustomerViewModel CurrentCustomer
        {
            get
            {
                if (_currentCustomer == null)
                {
                    _currentCustomer = new CustomerViewModel();
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
                        if (_currentCustomer.ListAddress != null && CurrentCustomer.ListAddress.Count > 0)
                        {
                            CurrentAddress = CurrentCustomer.ListAddress.First();
                        }

                    }
                    else
                    {
                        CurrentAddress = null;

                    }
                    // Publish event.  

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

        #endregion

        #region Commands

        public List<CustomerViewModel> CurrentListCustomer
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
        public AddressViewModel CurrentAddress
        {
            get
            {
                //return CurrentItem.ListAddress.FirstOrDefault();
                if (CurrentCustomer.ListAddress != null)
                {
                    _currentAddress = CurrentCustomer.ListAddress.FirstOrDefault();
                }
                return _currentAddress;
            }

            set
            {
                _currentAddress = value;
                OnPropertyChanged("CurrentAddress");
            }
        }
        public List<CustomerViewModel> ListAllCustomer
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

        void ExportPage()
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.ImageProcessing += reportDocument_ImageProcessing;
                StreamReader reader = new StreamReader(new FileStream(@"ReportTemplates\RPListCustomers.xaml", FileMode.Open, FileAccess.Read));
                reportDocument.XamlData = reader.ReadToEnd();
                reportDocument.XamlImagePath = Path.Combine(Environment.CurrentDirectory, @"ReportTemplates\");
                reader.Close();

                DateTime dateTimeStart = DateTime.Now; // start time measure here

                List<ReportData> listData = new List<ReportData>();

                ReportData data = new ReportData();
                data.ReportDocumentValues.Add("PrintDate", dateTimeStart);
                DataTable table = new DataTable("Data");
                table.Columns.Add("Order", typeof(int));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Avatar", typeof(string));
                table.Columns.Add("Position", typeof(string));

                foreach (var item in CurrentListCustomer)
                {
                    //MemoryStream ms = new MemoryStream();
                    //BitmapImage bi = new BitmapImage();
                    //byte[] bytArray = File.ReadAllBytes(item.Avatar);
                    //ms.Write(bytArray, 0, bytArray.Length);
                    //ms.Position = 0;
                    //bi.BeginInit();
                    //bi.StreamSource = ms;
                    //bi.EndInit();
                    //Image avatar = new Image();
                    //avatar.Source = bi;
                    table.Rows.Add(new object[] { CurrentListCustomer.IndexOf(item) + 1, item.Name, "Avatar", item.Position });
                }
                data.DataTables.Add(table);

                listData.Add(data);
                XpsDocument xps = reportDocument.CreateXpsDocument(listData);
                ReportViewer rp = new ReportViewer(xps);

                rp.ShowDialog();

                // show the elapsed time in window title
                //Title += " - generated in " + (DateTime.Now - dateTimeStart).TotalMilliseconds + "ms";
            }
            catch (Exception ex) { }
        }

        private void reportDocument_ImageProcessing(object sender, ImageEventArgs e)
        {

            //throw new NotImplementedException();
        }

        public AutoCompleteFilterPredicate<object> CustomerFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as CustomerViewModel).Name.Contains(searchText)
                    || (obj as CustomerViewModel).PhoneNumber.Contains(searchText)
                    || (obj as CustomerViewModel).Email.Contains(searchText);
            }
        }

        public PagingViewModel<CRM_Customer, CustomerViewModel> PagingViewModel
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

        public int PageSize1
        {
            get
            {
                return PageSize;
            }

            set
            {
                PageSize = value;
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

        public ICommand ExportCommand
        {
            get
            {
                if (_exportCommand == null)
                {
                    _exportCommand = new RelayCommand(p => ExportPage());
                }
                return _exportCommand;
            }

            set
            {
                _exportCommand = value;
            }
        }

        async void RefreshCustomers()
        {
            IsBusy = true;
            CurrentListCustomer = await CustomerRepo.Instance.GetModelList();
            PagingViewModel = new PagingViewModel<CRM_Customer, CustomerViewModel>(CurrentListCustomer, PageSize1);
            IsBusy = false;
        }

        #endregion
        public CustomerPageViewModel() : base()
        {
            _eventAggregator = ApplicationService.Instance.GlobalEventAggregator;

            ItemListChanged<bool> _event = ApplicationService.Instance.GlobalEventAggregator.GetEvent<ItemListChanged<bool>>();
            _event.Subscribe(ItemsChanged);

            RefreshCustomers();
        }

        private void ItemsChanged(bool isChanged)
        {
            if (isChanged)
            {

                RefreshCustomers();
            }
        }
    }
}
