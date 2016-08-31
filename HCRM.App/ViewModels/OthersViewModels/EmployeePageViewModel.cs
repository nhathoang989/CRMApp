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

namespace HCRM.App.ViewModels.OthersViewModels
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
            CurrentItem = new EmployeeViewModel();
        }

        public EmployeeViewModel CurrentItem
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
                        if (_currentEmployee.ListAddress != null && CurrentItem.ListAddress.Count > 0)
                        {
                            CurrentAddress = CurrentItem.ListAddress.First();
                        }

                    }
                    else
                    {
                        CurrentAddress = null;

                    }
                    // Publish event.  
                   
                    OnPropertyChanged("CurrentItem");
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
                if (CurrentItem.ListAddress != null)
                {
                    _currentAddress = CurrentItem.ListAddress.FirstOrDefault();
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
