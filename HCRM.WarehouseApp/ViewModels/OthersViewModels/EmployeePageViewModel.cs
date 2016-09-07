using HCRM.WarehouseApp.Framework;
using HCRM.WarehouseApp.ViewInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using HCRM.WarehouseApp.ViewModels.ElementViewModels;
using HCRM.WarehouseApp.Repositories;
using Prism.Events;
using HCRM.WarehouseApp.Services;
using HCRM.WarehouseApp.Behaviors;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace HCRM.WarehouseApp.ViewModels.OthersViewModels
{
    public class EmployeePageViewModel : ObjectBase, IPageViewModel
    {
        #region Properties

        //public CreateEmployeeViewModel Model { get; private set; }
        private EmployeeViewModel _currentEmployee;
        private List<EmployeeViewModel> _employees;
        private AddressViewModel _currentAddress;
        private List<EmployeeViewModel> _listAllEmployee;
        private List<EmployeeViewModel> currentListEmployee;

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
                //return CurrentEmployee.ListAddress.FirstOrDefault();
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

        async void RefreshEmployees()
        {
            CurrentListEmployee = await EmployeeRepo.Instance.GetModelList();
        }

        #endregion
        public EmployeePageViewModel() : base()
        {
            _eventAggregator = ApplicationService.Instance.EventAggregator;

            ItemListChanged<bool> _event = ApplicationService.Instance.EventAggregator.GetEvent<ItemListChanged<bool>>();
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
