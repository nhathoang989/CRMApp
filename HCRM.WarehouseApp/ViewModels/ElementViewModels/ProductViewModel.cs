﻿using System;
using System.Collections.Generic;
using HCRM.WarehouseApp.Helpers;
using HCRM.Data;
using HCRM.WarehouseApp.Ultilities;
using HCRM.WarehouseApp.Repositories;
using RestSharp;
using System.Threading.Tasks;
using System.Windows;
using HCRM.WarehouseApp.Behaviors;

namespace HCRM.WarehouseApp.ViewModels.ElementViewModels
{
    public class ProductViewModel : ViewModelBase<CRM_Product, ProductViewModel>
    {
        
        #region Properties
        private double _discount;
        private string _title;
        private int _countRemain;
        private int _countSaled;
        private int _countImported;
        private long _productID;
        private string _image;
        private bool _isVisible;
        private bool _isDraft;
        private bool _isDeleted;
        private string _size;
        private string _description;
        private string _fullDetail;
        private string _source;
        private int? _displayOrder;
        private DateTime _createdDate;
        private string _createdBy;
        private string _infos;
        private string _material;
        private double? _dealPrice;
        private double _normalPrice;
        private string _code;
        private string _subImages;
        private FileDialogViewModel _fileDlg;
        public List<CRM_Product_Property> PropertyModels { get; private set; }      
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
                _fileDlg  = value;
            }
        }

       

        public double Discount
        {
            get
            {
                return _discount;
            }

            set
            {
                _discount  = value; OnPropertyChanged("Discount");
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title  = value; OnPropertyChanged("Title");
            }
        }

        public int TotalRemain
        {
            get
            {
                return _countRemain;
            }

            set
            {
                _countRemain  = value; OnPropertyChanged("TotalRemain");
            }
        }

        public int TotalSaled
        {
            get
            {
                return _countSaled;
            }

            set
            {
                _countSaled  = value; OnPropertyChanged("TotalSaled");
            }
        }

        public int TotalImported
        {
            get
            {
                return _countImported;
            }

            set
            {
                _countImported  = value; OnPropertyChanged("TotalImported");
            }
        }

        public long ProductID
        {
            get
            {
                return _productID;
            }

            set
            {
                _productID  = value; OnPropertyChanged("ProductID");
            }
        }

        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image  = value; OnPropertyChanged("Image");
            }
        }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }

            set
            {
                _isVisible  = value; OnPropertyChanged("IsVisible");
            }
        }

        public bool IsDraft
        {
            get
            {
                return _isDraft;
            }

            set
            {
                _isDraft  = value; OnPropertyChanged("IsDraft");
            }
        }

        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }

            set
            {
                _isDeleted  = value; OnPropertyChanged("IsDeleted");
            }
        }

        public string Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size  = value; OnPropertyChanged("Size");
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description  = value; OnPropertyChanged("Description");
            }
        }

        public string FullDetail
        {
            get
            {
                return _fullDetail;
            }

            set
            {
                _fullDetail  = value; OnPropertyChanged("FullDetail");
            }
        }

        public string Source
        {
            get
            {
                return _source;
            }

            set
            {
                _source  = value; OnPropertyChanged("Source");
            }
        }

        public int? DisplayOrder
        {
            get
            {
                return _displayOrder;
            }

            set
            {
                _displayOrder  = value; OnPropertyChanged("DisplayOrder");
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }

            set
            {
                _createdDate  = value; OnPropertyChanged("CreatedDate");
            }
        }

        public string CreatedBy
        {
            get
            {
                return _createdBy;
            }

            set
            {
                _createdBy  = value; OnPropertyChanged("CreatedBy");
            }
        }

        public string Infos
        {
            get
            {
                return _infos;
            }

            set
            {
                _infos  = value; OnPropertyChanged("Infos");
            }
        }

        public string Material
        {
            get
            {
                return _material;
            }

            set
            {
                _material = value;
                OnPropertyChanged("Material");
            }
        }

        public double? DealPrice
        {
            get
            {
                return _dealPrice;
            }

            set
            {
                _dealPrice = value;
                OnPropertyChanged("DealPrice");
            }
        }

        public double NormalPrice
        {
            get
            {
                return _normalPrice;
            }

            set
            {
                _normalPrice = value;
                OnPropertyChanged("NormalPrice");
            }
        }

        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        public string SubImages
        {
            get
            {
                return _subImages;
            }

            set
            {
                _subImages = value;
                OnPropertyChanged("SubImages");
            }
        }

        #endregion

        #region Functions
        public override bool CanSaveModel() {
           
            return Model != null && !string.IsNullOrEmpty(Code) && !string.IsNullOrEmpty(Title);
        }
        public override async Task<IRestResponse> SaveModel()
        {
            ViewToModel();
            if (Model.ProductID == 0)
            {
                Model.CreatedBy = App.currUser.username;
                Model.CreatedDate = DateTime.Now;
                Model.IsDeleted = false;
                Model.IsDraft = false;
                Model.IsVisible = true;
            }
            var result = await ProductRepo.Instance.SaveModel(Model, FileDlg.Info);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Image = common.getFullFilePath(Model.Image);
                ApiHelper.Alert("Lưu ý", "Lưu sản phẩm thành công");
            }
            else {
                ApiHelper.Alert("Lưu ý", "Không thể lưu sản phẩm");
            }
            return result;
        }
        public override void ViewToModel()
        {

            Model.Code = Code;
            Model.Size = Size;
            Model.Title = Title;
            Model.Source = Source;
            Model.Material = Material;
            Model.Description = Description;
            Model.DealPrice = DealPrice;
            Model.NormalPrice = NormalPrice;
            Model.Discount = Discount;

            Model.TotalRemain = TotalRemain;
            Model.TotalSaled = TotalSaled;
            Model.TotalImported = TotalImported;

            Model.SubImages = SubImages;
            Model.Infos = Infos;
            Model.DisplayOrder = DisplayOrder;

            Model.CreatedBy = CreatedBy;
            Model.CreatedDate = CreatedDate;

            Model.IsVisible = IsVisible;
            Model.IsDeleted = IsDeleted;


            Model.Infos = Infos;
            Model.IsDraft = IsDraft;
        }

        public override void ModelToView()
        {

            Code = Model.Code;
            DealPrice = Model.DealPrice;
            Title = Model.Title;
            Source = Model.Source;
            Material = Model.Material;
            Image = common.getFullFilePath(Model.Image);
            Description = Model.Description;
            DealPrice = Model.DealPrice;
            NormalPrice = Model.NormalPrice;
            Discount = Model.Discount;
            Size = Model.Size;
            TotalRemain = Model.TotalRemain;
            TotalSaled = Model.TotalSaled;
            TotalImported = Model.TotalImported;

            SubImages = Model.SubImages;
            Infos = Model.Infos = Infos;
            DisplayOrder = Model.DisplayOrder;

            CreatedBy = Model.CreatedBy;
            CreatedDate = Model.CreatedDate;

            IsVisible = Model.IsVisible;
            IsDeleted = Model.IsDeleted;


            IsDraft = Model.IsDraft;
        }

        public void ViewToModelWithKey()
        {
            ViewToModel();
            Model.ProductID = ProductID;
        }

        public override async void RemoveModel()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Bạn có muốn tiếp tục xóa?", "Lưu ý", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var result = await ProductRepo.Instance.RemoveModel(Model);
                _eventAggregator.GetEvent<ItemListChanged<bool>>().Publish(result.StatusCode == System.Net.HttpStatusCode.OK);
            }
        }


        #endregion

        #region Contructors

        public ProductViewModel(CRM_Product product) : base("api/Product", "Product")
        {
            Model = product;
            ModelToView();
        }        
        public ProductViewModel() : base("api/Product", "Product")
        {
            Model = new CRM_Product();
        }


        #endregion
       
    }
}

