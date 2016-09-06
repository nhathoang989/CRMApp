using HCRM.Data;
using HCRM.App.Framework;
using HCRM.App.Ultilities;
using System.Collections.Generic;
using RestSharp;
using System;
using System.Threading.Tasks;
using HCRM.App.Repositories;
using HCRM.App.Services;
using HCRM.App.Behaviors;

namespace HCRM.App.ViewModels.ElementViewModels
{
    public class ReceiptDeliveryViewModel : ViewModelBase<CRM_Receipt_Delivery, ReceiptDeliveryViewModel>
    {
       
        private List<ReceiptDetailsViewModel> _lstDetails;
        private long _receiptID;
        private string _strTotalAmount;
        private string _strTotalReduce;
        private string _strTotalPaid;
        private string _strTotalRemain;
        private string _orderName;
        private string _orderPhone;
        private string _orderAddress;

        private double _totalAmount;
        private double _totalReduceAmount;
        private double _totalMustPay;
        private double _totalRemain;
        private double _totalPaid;

        private bool _isPaid;
        private int? _customerID;
        private int? _employeeID;

        #region Properties
        public List<ReceiptDetailsViewModel> ListDetails
        {
            get
            {
                return _lstDetails;
            }

            set
            {
                _lstDetails = value; OnPropertyChanged("ListDetails");
            }
        }

        public string StrTotalAmount
        {
            get
            {
                return _strTotalAmount;
            }

            set
            {
                _strTotalAmount = value;                
                OnPropertyChanged("StrTotalAmount");
            }
        }

        public string StrTotalReduce
        {
            get
            {
                return _strTotalReduce;
            }

            set
            {
                _strTotalReduce = value;
                OnPropertyChanged("StrTotalReduce");
            }
        }

        public string StrTotalPaid
        {
            get
            {
                return _strTotalPaid;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "0";
                }
                _strTotalPaid = common.FormatPrice(value);
                TotalPaid= double.Parse(value.Replace(",", string.Empty));
                OnPropertyChanged("StrTotalPaid");
            }
        }

        public string StrTotalRemain
        {
            get
            {
                return _strTotalRemain;
            }

            set
            {
                _strTotalRemain = value;
                OnPropertyChanged("StrTotalRemain");
            }
        }

        public string OrderName
        {
            get
            {
                return _orderName;
            }

            set
            {
                _orderName = value; OnPropertyChanged("OrderName");
            }
        }

        public string OrderPhone
        {
            get
            {
                return _orderPhone;
            }

            set
            {
                _orderPhone = value; OnPropertyChanged("OrderPhone");
            }
        }

        public string OrderAddress
        {
            get
            {
                return _orderAddress;
            }

            set
            {
                _orderAddress = value; OnPropertyChanged("OrderAddress");
            }
        }

        public double TotalAmount
        {
            get
            {
                return _totalAmount;
            }

            set
            {
                StrTotalAmount = common.FormatPrice(value.ToString());
                _totalAmount = value; OnPropertyChanged("TotalAmount");
            }
        }

        public double TotalReduceAmount
        {
            get
            {
                return _totalReduceAmount;
            }

            set
            {
                StrTotalReduce = common.FormatPrice(value.ToString());
                _totalReduceAmount = value; OnPropertyChanged("TotalReduceAmount");
            }
        }

        public double TotalMustPay
        {
            get
            {
                return _totalMustPay;
            }

            set
            {
                _totalMustPay = value; OnPropertyChanged("TotalMustPay");
            }
        }

        public double TotalRemain
        {
            get
            {
                return _totalRemain;
            }

            set
            {
                StrTotalRemain = common.FormatPrice(value.ToString());
                _totalRemain = value; OnPropertyChanged("TotalRemain");
            }
        }

        public double TotalPaid
        {
            get
            {
                return _totalPaid;
            }

            set
            {
                TotalRemain = TotalAmount - TotalReduceAmount - value;
                _totalPaid = value; OnPropertyChanged("TotalPaid");
            }
        }

        public bool IsPaid
        {
            get
            {
                return _isPaid;
            }

            set
            {
                _isPaid = value; OnPropertyChanged("IsPaid");
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
                _customerID = value; OnPropertyChanged("CustomerID");
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
                _employeeID = value; OnPropertyChanged("EmployeeID");
            }
        }

        public long ReceiptID
        {
            get
            {
                return _receiptID;
            }

            set
            {
                _receiptID = value;
            }
        }


        #endregion

        public ReceiptDeliveryViewModel() : base("api/ReceiptDelivery", "ReceiptDelivery")
        {
            Model = new CRM_Receipt_Delivery();
            ListDetails = new List<ReceiptDetailsViewModel>();
        }

        public override void RemoveModel()
        {
            throw new NotImplementedException();
        }

        public override async Task<IRestResponse> SaveModel()
        {
            ViewToModel();
            var result = await ReceiptDeliveryRepo.Instance.SaveModel(Model);
            ApplicationService.Instance.EventAggregator.GetEvent<SaveReceiptDeliveryResultEvent>().Publish(result.StatusCode==System.Net.HttpStatusCode.OK);            
            return result;
        }

        public override bool CanSaveModel()
        {
            return ErrorCount == 0 && ListDetails.Count > 0;
        }

        public override void ModelToView()
        {
            ReceiptID = Model.ReceiptID;
            ListDetails = new List<ReceiptDetailsViewModel>();
            foreach (var details in Model.CRM_Receipt_Details)
            {
                ListDetails.Add(new ReceiptDetailsViewModel(details));
            }
            OrderPhone = Model.OrderPhone;
            OrderName = Model.OrderName;
            OrderAddress = Model.OrderAddress;
            StrTotalAmount = common.FormatPrice(Model.TotalAmount.ToString());
            StrTotalReduce = common.FormatPrice(Model.TotalReduceAmount.ToString());
            StrTotalPaid = common.FormatPrice(Model.TotalPaid.ToString());
            StrTotalRemain = common.FormatPrice(Model.TotalRemain.ToString());
            IsPaid = Model.IsPaid;
            CustomerID = Model.CustomerID;
            EmployeeID = Model.EmployeeID;
        }

        public override void ViewToModel()
        {
            Model.ReceiptID = ReceiptID;
            foreach (var details in ListDetails)
            {
                details.ViewToModel();
                Model.CRM_Receipt_Details.Add(details.Model);
            }
            Model.OrderAddress = OrderAddress;
            Model.OrderName = OrderName;
            Model.OrderPhone = OrderPhone;
            Model.TotalAmount = common.ReversePrice(StrTotalAmount);
            Model.TotalReduceAmount = common.ReversePrice(StrTotalReduce);
            Model.TotalPaid = common.ReversePrice(StrTotalPaid);
            Model.TotalRemain = common.ReversePrice(StrTotalRemain);
            Model.IsPaid = IsPaid;
            Model.CustomerID = CustomerID;
            Model.EmployeeID = EmployeeID;
            if (ReceiptID == 0)
            {
                Model.CreatedDate = DateTime.Now;
            }
        }
    }
}

