using System;
using System.Collections.Generic;
using HCRM.App.Helpers;
using HCRM.Data;
using HCRM.App.Ultilities;
using System.Threading.Tasks;
using HCRM.App.Repositories;
using RestSharp;
using System.IO;
using System.Windows;
using Prism.Events;
using HCRM.App.Behaviors;
using HCRM.App.Services;

namespace HCRM.App.ViewModels.ElementViewModels
{
    public class EmployeeViewModel : ViewModelBase<CRM_Employee, EmployeeViewModel>
    {
        #region Properties

        private string _name;
        private string _phoneNumber;
        private string _position;
        private string _email;
        private string _avatar;
        private int _employeeID;
        private int? _age;
        FileDialogViewModel _fileDlg;

        private AddressViewModel _currentAddress;
        List<AddressViewModel> _listAddress;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public string Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Avatar
        {
            get
            {
                return _avatar;
            }

            set
            {
                _avatar = value;
                OnPropertyChanged("Avatar");
            }
        }

        public int EmployeeID
        {
            get
            {
                return _employeeID;
            }

            set
            {
                _employeeID = value;
                OnPropertyChanged("EmployeeID");
            }
        }

        public int? Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
                OnPropertyChanged("Age");
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

        public List<AddressViewModel> ListAddress
        {
            get
            {
                return _listAddress;
            }

            set
            {
                _listAddress = value;
                OnPropertyChanged("ListAddress");
            }
        }

        public AddressViewModel CurrentAddress
        {
            get
            {
                return _currentAddress;
            }

            set
            {
                _currentAddress = value;
            }
        }
        
        #endregion

        #region Funcs
        public override bool CanSaveModel()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Position);
        }
        public override async Task<IRestResponse> SaveModel()
        {
            ViewToModel();
            if (FileDlg.Info != null)
            {
                Model.Avatar = ProductRepo.Instance.UploadFile(FileDlg.Info);
            }
            var result = await EmployeeRepo.Instance.SaveModel(Model);
            if (result.StatusCode== System.Net.HttpStatusCode.OK)
            {
                _eventAggregator.GetEvent<ItemListChanged<bool>>().Publish(result.StatusCode == System.Net.HttpStatusCode.OK);

                Avatar = common.getFullFilePath(Model.Avatar);
                ApiHelper.Alert("Lưu ý", "Lưu nhân viên thành công");
            }
            else
            {
                ApiHelper.Alert("Lưu ý", "Không thể lưu nhân viên");
            }
            return result;
        }
        public override void ModelToView()
        {
            EmployeeID = Model.EmployeeID;
            Name = Model.Name;
            Avatar = common.getFullFilePath(Model.Avatar);
            Email = Model.Email;
            Age = Model.Age;
            PhoneNumber = Model.PhoneNumber;
            Position = Model.Position;
            if (Model.CRM_Address != null)
            {
                ListAddress = new List<AddressViewModel>();
                foreach (var address in Model.CRM_Address)
                {
                    var vmAddr = new AddressViewModel(address);
                    ListAddress.Add(vmAddr);
                }
            }
        }
        public override void ViewToModel()
        {

            if (EmployeeID == 0)
            {
                Model.CreatedDate = DateTime.Now;
                Model.CreatedBy = App.currUser.username;
                Model.IsDeleted = false;
            }
            Model.PhoneNumber = PhoneNumber;
            Model.Name = Name;
            Model.Position = Position;
            Model.Email = Email;
            Model.Age = Age;
            Model.CRM_Address = new List<CRM_Address>();
            foreach (var address in ListAddress)
            {
                address.ViewToModel();
                Model.CRM_Address.Add(address.Model);
            }         
        }
        public async override void RemoveModel()
        {

            if (common.ConfirmDialog("Bạn có muốn tiếp tục xóa?", "Lưu ý"))
            {
                IRestResponse result = await BaseRepo.RemoveModel(Model);
                _eventAggregator.GetEvent<ItemListChanged<bool>>().Publish(result.StatusCode == System.Net.HttpStatusCode.OK);                
            }
        }

        #endregion

        public EmployeeViewModel(CRM_Employee model) : base("api/Employee", "Employee")
        {
            Model = model;
            ModelToView();
        }
        public EmployeeViewModel() : base("api/Employee", "Employee")
        {
            Model = new CRM_Employee();
        }
        
        public EmployeeViewModel(IEventAggregator eventAggregator) : base("api/Employee", "Employee")
        {
            
        }

    }
}
