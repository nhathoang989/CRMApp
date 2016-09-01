using HCRM.WarehouseApp.Framework;
using System;
using System.Collections.Generic;
using HCRM.WarehouseApp.ViewInterfaces;
using System.Windows.Input;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HCRM.WarehouseApp.Helpers;
using HCRM.Data;
using System.IO;

namespace HCRM.WarehouseApp.ViewModels
{
    public class ProductViewModel : ObjectBase
    {
        #region Properties

        public ProductViewModel Model { get; private set; }
        private CRM_Product _currentProduct;
        public CRM_Product CurrentProduct
        {
            get { return _currentProduct; }
            set
            {
                if (value != _currentProduct)
                {
                    _currentProduct = value;
                    OnPropertyChanged("CurrentProduct");
                }
            }
        }

        public List<CRM_Product_Property> PropertyModels { get; private set; }

        private ICommand browseCommand;

        public List<FileInfo> files = new List<FileInfo>();

        private double discount;
        private string title;
        private int countRemain;
        private int countSaled;
        private int countImported;
        private long productID;
        private string image;
        private bool isVisible;
        private bool isDraft;
        private bool isDeleted;
        private string size;
        private string description;
        private string fullDetail;
        private string source;
        private int? displayOrder;
        private DateTime createdDate;
        private string createdBy;
        private string infos;


        public string Title
        {
            get { return title; }

            set
            {
                if (value != title)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }


        public int? Level { get; set; }

        public double? DealPrice { get; set; }

        public double NormalPrice { get; set; }

        public string SubImages { get; set; }

        public int Booked { get; set; }

        public string Code { get; set; }

        public string Material { get; set; }

        public ICommand BrowseCommand
        {
            get
            {
                if (browseCommand == null)
                {
                    browseCommand = new RelayCommand(
                        p => BrowseFile());
                }
                return browseCommand;
            }
        }

        public string Key
        {
            get
            {
                return Helpers.Parameters.PageView.ProductPage;
            }
        }

        public string PageTitle
        {
            get
            {
                return "Product Page";
            }
        }

        public double Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }

        public long ProductID
        {
            get
            {
                return productID;
            }

            set
            {
                productID = value;
            }
        }

        public int CountImported
        {
            get
            {
                return countImported;
            }

            set
            {
                countImported = value;
                OnPropertyChanged("CountImported");
            }
        }

        public int CountSaled
        {
            get
            {
                return countSaled;
            }

            set
            {
                countSaled = value;
                OnPropertyChanged("CountSaled");
            }
        }

        public int CountRemain
        {
            get
            {
                return countRemain;
            }

            set
            {
                countRemain = value;
                OnPropertyChanged("CountRemain");
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }

            set
            {
                isVisible = value;
            }
        }

        public bool IsDraft
        {
            get
            {
                return isDraft;
            }

            set
            {
                isDraft = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string FullDetail
        {
            get
            {
                return fullDetail;
            }

            set
            {
                fullDetail = value;
            }
        }

        public string Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
            }
        }

        public int? DisplayOrder
        {
            get
            {
                return displayOrder;
            }

            set
            {
                displayOrder = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return createdDate;
            }

            set
            {
                createdDate = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return createdBy;
            }

            set
            {
                createdBy = value;
            }
        }

        public string Infos
        {
            get
            {
                return infos;
            }

            set
            {
                infos = value;
            }
        }

     
        #endregion

        #region Functions
        void BrowseFile()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                Image = filename;
                files.Add(new FileInfo(dlg.FileName));
            }
        }
        public void ViewToModel(CRM_Product a)
        {

            a.Code = Code; a.DealPrice = DealPrice;
            a.Title = Title;
            a.Source = Source;
            a.Material = Material;
            a.Image = Image;
            a.Description = Description;
            a.DealPrice = DealPrice;
            a.NormalPrice = NormalPrice;
            a.Discount = Discount;

            a.CountRemain = CountRemain;
            a.CountRemain = CountSaled;
            a.CountRemain = CountImported;

            a.SubImages = SubImages;
            a.Infos = Infos;
            a.DisplayOrder = DisplayOrder;

            a.CreatedBy = CreatedBy;
            a.CreatedDate = CreatedDate;

            a.IsVisible = IsVisible;
            a.IsDeleted = IsDeleted;


            a.Infos = Infos;
            a.IsDraft = IsDraft;
        }

        public void ViewToModelWithKey(CRM_Product a)
        {
            ViewToModel(a);
            a.ProductID = ProductID;
        }

        #endregion
        public ProductViewModel(CRM_Product product)
        {
            //Model = copy;
        }
        public ProductViewModel(long productID) : base()
        {
            GetProduct(productID);
        }
        public ProductViewModel() : base()
        {

        }

        private async void GetProduct(long productID)
        {
            CurrentProduct = await ProductHelper.GetProduct(productID);
        }

    }
}

