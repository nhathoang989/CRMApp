using HCRM.Data;
using HCRM.WarehouseApp.Repositories;
using System.Threading.Tasks;
using System;
using RestSharp;

namespace HCRM.WarehouseApp.ViewModels.ElementViewModels
{
    public class AddressViewModel : ViewModelBase<CRM_Address, AddressViewModel>
    {
        #region Properties

        private string _city;
        private string _street;
        private int _addressID;
        private int? _employeeID;
        private int? _customerID;
        private int? _providerID;

        public int AddressID
        {
            get
            {
                return _addressID;
            }

            set
            {
                _addressID = value;
                OnPropertyChanged("AddressID");
            }
        }

        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        public string Street
        {
            get
            {
                return _street;
            }

            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }

        public int? EmployeeID
        {
            get
            {
                return _employeeID;
            }

            set
            {
                _employeeID = value;
            }
        }

        public int? CustomerID
        {
            get
            {
                return _customerID;
            }

            set
            {
                _customerID = value;
            }
        }

        public int? ProviderID
        {
            get
            {
                return _providerID;
            }

            set
            {
                _providerID = value;
            }
        }


        #endregion

        #region Funcs
        public override bool CanSaveModel()
        {
            return !string.IsNullOrEmpty(Street) || !string.IsNullOrEmpty(City);
        }

        public override void ModelToView()
        {
            Street = Model.Street;
            City = Model.City;
            AddressID = Model.AddressID;
            EmployeeID = Model.EmployeeID;
            CustomerID = Model.CustomerID;
            ProviderID = Model.ProviderID;
        }

        public override async Task<IRestResponse> SaveModel()
        {
            var result = await AddressRepo.Instance.SaveModel(Model);   
            return result;
        }

        public override void ViewToModel()
        {
            Model.Street = Street;
            Model.City = City;
            Model.EmployeeID = EmployeeID;
            Model.CustomerID = CustomerID;
            Model.ProviderID = ProviderID;
        }

        public override void RemoveModel()
        {
            throw new NotImplementedException();
        }
        #endregion

        public AddressViewModel(CRM_Address model) : base("api/Address", "Address")
        {
            Model = model;
            ModelToView();
        }
        public AddressViewModel() : base("api/Address", "Address")
        {
            Model = new CRM_Address();
        }

    }
}
