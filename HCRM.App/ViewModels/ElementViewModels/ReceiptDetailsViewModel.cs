using HCRM.Data;
using HCRM.App.Framework;
using HCRM.App.Ultilities;
using System.Collections.Generic;
using RestSharp;
using System;
using System.Threading.Tasks;
using HCRM.App.Repositories;
using HCRM.App.Behaviors;
using System.Windows;

namespace HCRM.App.ViewModels.ElementViewModels
{
    public class ReceiptDetailsViewModel : ViewModelBase<CRM_Receipt_Details, ReceiptDetailsViewModel>
    {
        #region Properties

        private ProductViewModel _product;
        private string _strReducePrice;
        private string _strUnitPrice;
        private double _unitPrice;
        private double _reducePrice;
        private int _quantity;
        private long _receiptDetailsID;
      
        public ProductViewModel Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
                OnPropertyChanged("Product");
            }
        }

        public string StrReducePrice
        {
            get
            {
                return _strReducePrice;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "0";
                }
                OnPropertyChanged("StrReducePrice");
            }
        }

        public string StrUnitPrice
        {
            get
            {
                return _strUnitPrice;
            }

            set
            {
                _strUnitPrice = common.FormatPrice(value);
                UnitPrice = double.Parse(value.Replace(",", string.Empty));
                OnPropertyChanged("StrUnitPrice");
            }
        }

        public double UnitPrice
        {
            get
            {
                return _unitPrice;
            }

            set
            {
                _unitPrice = value;
                OnPropertyChanged("UnitPrice");
            }
        }

        public double ReducePrice
        {
            get
            {
                return _reducePrice;
            }

            set
            {
                _reducePrice = value;
                OnPropertyChanged("ReducePrice");
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity > 0 ? _quantity : 1;
            }

            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public long ReceiptDetailsID
        {
            get
            {
                return _receiptDetailsID;
            }

            set
            {
                _receiptDetailsID = value;
            }
        }


        #endregion

        #region Funcs
        public override bool CanSaveModel()
        {
            return Product != null;
        }
        public override async Task<IRestResponse> SaveModel()
        {
            ViewToModel();
            var result = await ReceiptDetailsRepo.Instance.SaveModel(Model);            
            return result;
        }
        public override void ModelToView()
        {
            ReceiptDetailsID = Model.ReceiptDetailsID;
            StrUnitPrice = common.FormatPrice(Model.UnitPrice.ToString());
            StrReducePrice = common.FormatPrice(Model.ReducePrice.ToString());
            Quantity = Model.Quantity;
            Product = new ProductViewModel(Model.CRM_Product);
        }
        public override void ViewToModel()
        {

            Model.ReducePrice = common.ReversePrice(StrReducePrice);
            Model.UnitPrice = common.ReversePrice(StrUnitPrice);
            Model.Quantity = Quantity;

            Product.ViewToModel();
            Model.CRM_Product = Product.Model;            
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

        public ReceiptDetailsViewModel(CRM_Receipt_Details model) : base("api/ReceiptDetails", "ReceiptDetails")
        {
            Model = model;
            ModelToView();
        }
        public ReceiptDetailsViewModel() : base("api/ReceiptDetails", "ReceiptDetails")
        {
            Model = new CRM_Receipt_Details();
        }

    }
}
