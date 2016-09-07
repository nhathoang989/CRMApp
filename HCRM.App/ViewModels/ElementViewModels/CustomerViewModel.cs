using System;
using System.Collections.Generic;
using HCRM.Data;
using HCRM.App.Ultilities;
using System.Threading.Tasks;
using HCRM.App.Repositories;
using RestSharp;
using Prism.Events;
using HCRM.App.Behaviors;

namespace HCRM.App.ViewModels.ElementViewModels
{
    public class CustomerViewModel : ViewModelBase<CRM_Customer, CustomerViewModel>
    {
        #region Properties

        private string _name;
        private string _phoneNumber;
        private string _position;
        private string _jobDescription;
        private string _idCardNumber;
        private string _profileFilePath;
        private string _email;
        private string _avatar;
        private int _providerID;
        private int? _age;
        FileDialogViewModel _avatarFileDlg;

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

        public int CustomerID
        {
            get
            {
                return _providerID;
            }

            set
            {
                _providerID = value;
                OnPropertyChanged("CustomerID");
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

        public FileDialogViewModel AvatarFileDlg
        {
            get
            {
                if (_avatarFileDlg == null)
                {
                    _avatarFileDlg = new FileDialogViewModel();
                }
                return _avatarFileDlg;
            }

            set
            {
                _avatarFileDlg = value;
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

        public string JobDescription
        {
            get
            {
                return _jobDescription;
            }

            set
            {
                _jobDescription = value;
                OnPropertyChanged("JobDescription");
            }
        }

        public string IdCardNumber
        {
            get
            {
                return _idCardNumber;
            }

            set
            {
                _idCardNumber = value;
                OnPropertyChanged("IdCardNumber");
            }
        }

        public string ProfileFilePath
        {
            get
            {
                return _profileFilePath;
            }

            set
            {
                _profileFilePath = value;
                OnPropertyChanged("ProfileFilePath");
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
            if (AvatarFileDlg.Info != null)
            {
                Model.Avatar = ProductRepo.Instance.UploadFile(AvatarFileDlg.Info);
            }
           
            var result = await CustomerRepo.Instance.SaveModel(Model);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _eventAggregator.GetEvent<ItemListChanged<bool>>().Publish(result.StatusCode == System.Net.HttpStatusCode.OK);

                Avatar = common.getFullFilePath(Model.Avatar);
            }
            return result;
        }
        public override void ModelToView()
        {
            CustomerID = Model.CustomerID;
            Email = Model.Email;
            Name = Model.Name;
            PhoneNumber = Model.PhoneNumber;
            Avatar = common.getFullFilePath(Model.Avatar);

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

            if (CustomerID == 0)
            {
                Model.CreatedDate = DateTime.Now;
                Model.CreatedBy = App.currUser.username;
                Model.IsDeleted = false;
            }
            Model.Email = Email;
            Model.Name = Name;
            Model.PhoneNumber = PhoneNumber;

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

        public override void Preview()
        {
            throw new NotImplementedException();
        }

        #endregion

        public CustomerViewModel(CRM_Customer model) : base("api/Customer", "Customer")
        {
            if (model == null)
            {
                model = new CRM_Customer();
            }
            Model = model;
            ModelToView();
        }
        public CustomerViewModel() : base("api/Customer", "Customer")
        {
            Model = new CRM_Customer();
        }

        public CustomerViewModel(IEventAggregator eventAggregator) : base("api/Customer", "Customer")
        {

        }

    }
}
