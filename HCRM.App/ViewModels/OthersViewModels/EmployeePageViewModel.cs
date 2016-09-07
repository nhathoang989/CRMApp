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
    public class EmployeePageViewModel : ObjectBase, IPageViewModel
    {
        #region Properties

        //public CreateEmployeeViewModel Model { get; private set; }
        private PagingViewModel<CRM_Employee, EmployeeViewModel> _pagingViewModel;
        private int PageSize = 5;
        private bool _isBusy;
        private EmployeeViewModel _currentEmployee;
        private List<EmployeeViewModel> _employees;
        private AddressViewModel _currentAddress;
        private List<EmployeeViewModel> _listAllEmployee;
        private List<EmployeeViewModel> currentListEmployee;
        private ICommand _exportCommand;
        private IEventAggregator _eventAggregator;
        private ICommand _newEmployeeCommand;
        public ICommand NewEmployeeCommand
        {
            get
            {
                if (_newEmployeeCommand == null)
                {
                    _newEmployeeCommand = new RelayCommand(p => NewEmployee());
                }
                return _newEmployeeCommand;
            }

            set
            {
                NewEmployeeCommand = value;
            }
        }

        private void NewEmployee()
        {
            CurrentEmployee = new EmployeeViewModel();
        }

        public EmployeeViewModel CurrentEmployee
        {
            get
            {
                if (_currentEmployee == null)
                {
                    _currentEmployee = new EmployeeViewModel();
                }
                return _currentEmployee;

            }
            set
            {
                if (value != _currentEmployee)
                {

                    _currentEmployee = value;
                    if (value != null)
                    {
                        if (_currentEmployee.ListAddress != null && CurrentEmployee.ListAddress.Count > 0)
                        {
                            CurrentAddress = CurrentEmployee.ListAddress.First();
                        }

                    }
                    else
                    {
                        CurrentAddress = null;

                    }
                    // Publish event.  
                   
                    OnPropertyChanged("CurrentEmployee");
                }
            }
        }
        
        public string Key
        {
            get
            {
                return Helpers.Parameters.PageView.EmployeePage;
            }
        }

        public string PageTitle
        {
            get
            {
                return "Employee Page";
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

        #endregion

        #region Commands

        public List<EmployeeViewModel> CurrentListEmployee
        {
            get
            {
                return currentListEmployee;
            }

            set
            {
                currentListEmployee = value;
                Employees = currentListEmployee;
            }
        }
        public AddressViewModel CurrentAddress
        {
            get
            {
                //return CurrentItem.ListAddress.FirstOrDefault();
                if (CurrentEmployee.ListAddress != null)
                {
                    _currentAddress = CurrentEmployee.ListAddress.FirstOrDefault();
                }
                return _currentAddress;
            }

            set
            {
                _currentAddress = value;
                OnPropertyChanged("CurrentAddress");
            }
        }
        public List<EmployeeViewModel> ListAllEmployee
        {
            get
            {
                return _listAllEmployee;
            }

            set
            {
                _listAllEmployee = value;
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
                StreamReader reader = new StreamReader(new FileStream(@"ReportTemplates\RPListEmployees.xaml", FileMode.Open, FileAccess.Read));
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
              
                foreach (var item in CurrentListEmployee)
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
                    table.Rows.Add(new object[] { CurrentListEmployee.IndexOf(item) + 1, item.Name, "Avatar", item.Position });
                }
                data.DataTables.Add(table);

                listData.Add(data);
                XpsDocument xps = reportDocument.CreateXpsDocument(listData);
                ReportViewer rp = new ReportViewer(xps);
                
                rp.ShowDialog();

                // show the elapsed time in window title
                //Title += " - generated in " + (DateTime.Now - dateTimeStart).TotalMilliseconds + "ms";
            }
            catch(Exception ex) {  }
        }

        private void reportDocument_ImageProcessing(object sender, ImageEventArgs e)
        {

            //throw new NotImplementedException();
        }

        public AutoCompleteFilterPredicate<object> EmployeeFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as EmployeeViewModel).Name.Contains(searchText)
                    || (obj as EmployeeViewModel).PhoneNumber.Contains(searchText)
                    || (obj as EmployeeViewModel).Email.Contains(searchText);
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

        async void RefreshEmployees()
        {
            IsBusy = true;   
            CurrentListEmployee = await EmployeeRepo.Instance.GetModelList();
            PagingViewModel = new PagingViewModel<CRM_Employee, EmployeeViewModel>(CurrentListEmployee, PageSize1);
            IsBusy = false;            
        }

        #endregion
        public EmployeePageViewModel() : base()
        {
            _eventAggregator = ApplicationService.Instance.GlobalEventAggregator;

            ItemListChanged<bool> _event = ApplicationService.Instance.GlobalEventAggregator.GetEvent<ItemListChanged<bool>>();
            _event.Subscribe(ItemsChanged);

            RefreshEmployees();
        }

        private void ItemsChanged(bool isChanged)
        {
            if (isChanged)
            {
                
                RefreshEmployees();
            }            
        }
    }
}
