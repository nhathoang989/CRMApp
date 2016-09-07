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
using System.Windows.Input;
using HCRM.App.Views.CustomControls;
using System.Windows.Xps.Packaging;
using CodeReason.Reports;
using System.IO;
using System.Data;
using Prism.Events;

namespace HCRM.App.ViewModels.ElementViewModels
{
    public class ReceiptDeliveryViewModel : ViewModelBase<CRM_Receipt_Delivery, ReceiptDeliveryViewModel>
    {
       
        private List<ReceiptDetailsViewModel> _lstDetails;
        private EmployeeViewModel _employee;
        private CustomerViewModel _customer;
        private long _receiptID;
        private string _strTotalAmount;
        private string _strTotalReduce;
        private string _strTotalPaid;
        private string _strTotalRemain;
        private string _receiveName;
        private string _receivePhone;
        private string _receiveAddress;

        private DateTime _createdDate;

        private double _totalAmount;
        private double _totalReduceAmount;
        private double _totalMustPay;
        private double _totalRemain;
        private double _totalPaid;

        private bool _isPaid;
        private bool _isDeliveried;
        private int? _customerID;
        private int? _employeeID;

        private ICommand _printPreviewCommand;
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
                TotalPaid = common.ReversePrice(value);
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

        public string ReceiveName
        {
            get
            {
                return _receiveName;
            }

            set
            {
                _receiveName = value; OnPropertyChanged("ReceiveName");
            }
        }

        public string ReceivePhone
        {
            get
            {
                return _receivePhone;
            }

            set
            {
                _receivePhone = value; OnPropertyChanged("ReceivePhone");
            }
        }

        public string ReceiveAddress
        {
            get
            {
                return _receiveAddress;
            }

            set
            {
                _receiveAddress = value; OnPropertyChanged("ReceiveAddress");
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

        public ICommand PrintPreviewCommand
        {
            get
            {
                if (_printPreviewCommand == null)
                {
                    _printPreviewCommand = new RelayCommand(m => PrintPreview(), m=>CanPrintPreview());
                }
                return _printPreviewCommand;
            }

            set
            {
                _printPreviewCommand = value;
            }
        }

        private bool CanPrintPreview()
        {
            return ListDetails.Count > 0;
        }

        public EmployeeViewModel Employee
        {
            get
            {
                return _employee;
            }

            set
            {
                _employee = value;
                OnPropertyChanged("Employee");
            }
        }
        public CustomerViewModel Customer
        {
            get
            {
                return _customer;
            }

            set
            {
                _customer = value;
                OnPropertyChanged("Customer");
            }
        }

        public bool IsDeliveried
        {
            get
            {
                return _isDeliveried;
            }

            set
            {
                _isDeliveried = value;
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
                _createdDate = value;
            }
        }

        private void PrintPreview()
        {
            ReportViewer rp = new ReportViewer(EventHandler);
            EventHandler.GetEvent<PrintReceiptEvent<XpsDocument>>().Publish(GetPrintReceiptDoc());            
            rp.ShowDialog();
        }

        XpsDocument GetPrintReceiptDoc()
        {
            ReportDocument reportDocument = new ReportDocument();
            StreamReader reader = new StreamReader(new FileStream(@"ReportTemplates\RPReceipt.xaml", FileMode.Open, FileAccess.Read));
            reportDocument.XamlData = reader.ReadToEnd();
            reportDocument.XamlImagePath = Path.Combine(Environment.CurrentDirectory, @"ReportTemplates\");
            reader.Close();

            DateTime dateTimeStart = DateTime.Now; // start time measure here

            List<ReportData> listData = new List<ReportData>();

            ReportData data = new ReportData();
            data.ReportDocumentValues.Add("ReportTitle", "Hóa đơn bán hàng");
            data.ReportDocumentValues.Add("PrintDate", dateTimeStart);
            data.ReportDocumentValues.Add("StrTotalAmount", StrTotalAmount);
            data.ReportDocumentValues.Add("StrTotalReduce", StrTotalReduce);
            data.ReportDocumentValues.Add("StrTotalRemain", StrTotalRemain);
            data.ReportDocumentValues.Add("StrTotalPaid", StrTotalPaid);

            data.ReportDocumentValues.Add("ReceiveName", ReceiveName);
            data.ReportDocumentValues.Add("ReceivePhone", ReceivePhone);
            data.ReportDocumentValues.Add("ReceiveAddress", ReceiveAddress);
            data.ReportDocumentValues.Add("EmployeeName", Employee != null ? Employee.Name : "");

            data.ReportDocumentValues.Add("IsDeliveried", IsDeliveried ? "Đã giao hàng" : "Chưa giao hàng");

            DataTable table = new DataTable("Data");
            table.Columns.Add("Order", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Quantity", typeof(string));
            table.Columns.Add("ReducePrice", typeof(string));
            table.Columns.Add("UnitPrice", typeof(string));

            foreach (var item in ListDetails)
            {
                var product = item.Product;
                table.Rows.Add(new object[] { ListDetails.IndexOf(item) + 1,  product.Title, item.Quantity, item.StrReducePrice, item.StrUnitPrice });
            }
            data.DataTables.Add(table);

            listData.Add(data);
            XpsDocument xps = reportDocument.CreateXpsDocument(listData);
            return xps;
        }

        #endregion

        public ReceiptDeliveryViewModel() : base("api/ReceiptDelivery", "ReceiptDelivery")
        {
            Model = new CRM_Receipt_Delivery();
            ListDetails = new List<ReceiptDetailsViewModel>();
            ActionResultEvent _resultEvent = EventHandler.GetEvent<ActionResultEvent>();// ApplicationService.Instance.ActiveEventAggregator.GetEvent<ActionResultEvent>();
            _resultEvent.Subscribe(PrintResultHandler);
        }
        public ReceiptDeliveryViewModel(IEventAggregator _parentEvent ) : base("api/ReceiptDelivery", "ReceiptDelivery")
        {
            EventHandler = _parentEvent;
            Model = new CRM_Receipt_Delivery();
            ListDetails = new List<ReceiptDetailsViewModel>();
            ActionResultEvent _resultEvent = EventHandler.GetEvent<ActionResultEvent>();
            _resultEvent.Subscribe(PrintResultHandler);
        }

        public ReceiptDeliveryViewModel(CRM_Receipt_Delivery model) : base("api/ReceiptDelivery", "ReceiptDelivery")
        {
            Model = model;
            ModelToView();
        }
        private async void PrintResultHandler(bool result)
        {
            if (result)
            {
                 var resp =  await SaveModel();
                result = resp.StatusCode == System.Net.HttpStatusCode.OK;
            }
            EventHandler.GetEvent<SaveReceiptResultEvent<bool>>().Publish(result);
        }

        public override void RemoveModel()
        {
            throw new NotImplementedException();
        }

        public override async Task<IRestResponse> SaveModel()
        {
            ViewToModel();

            var result = await ReceiptDeliveryRepo.Instance.SaveModel(Model);
            
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
            Customer = new CustomerViewModel(Model.CRM_Customer);
            Employee = new EmployeeViewModel(Model.CRM_Employee);
            
            ReceivePhone = Model.ReceivePhone;
            ReceiveName = Model.ReceiveName;
            ReceiveAddress = Model.ReceiveAddress;
            StrTotalAmount = common.FormatPrice(Model.TotalAmount.ToString());
            StrTotalReduce = common.FormatPrice(Model.TotalReduceAmount.ToString());
            StrTotalPaid = common.FormatPrice(Model.TotalPaid.ToString());
            StrTotalRemain = common.FormatPrice(Model.TotalRemain.ToString());
            IsDeliveried = Model.IsDeliveried;
            IsPaid = Model.IsPaid;
            CustomerID = Model.CustomerID;
            EmployeeID = Model.EmployeeID;
            CreatedDate = Model.CreatedDate;
        }

        public override void ViewToModel()
        {
            Model.ReceiptID = ReceiptID;
            foreach (var details in ListDetails)
            {
                details.ViewToModel();
                Model.CRM_Receipt_Details.Add(details.Model);
            }
            if (Employee != null) {
                Employee.ViewToModel();
                Model.CRM_Employee = Employee.Model;
            }
            if (Customer != null)
            {
                Customer.ViewToModel();
                Model.CRM_Customer = Customer.Model;
            }
            else {
                if (!string.IsNullOrEmpty(ReceiveName))
                {
                    Customer = new CustomerViewModel()
                    {
                        Name = ReceiveName,
                        PhoneNumber = ReceivePhone
                    };
                    if (!string.IsNullOrEmpty(ReceiveAddress))
                    {
                        Customer.ListAddress = new List<AddressViewModel>();
                        Customer.ListAddress.Add(new AddressViewModel()
                        {
                            Street = ReceiveAddress
                        });
                    }
                    
                    Customer.ViewToModel();
                    Model.CRM_Customer = Customer.Model;
                }
            }
            Model.ReceiveAddress = ReceiveAddress;
            Model.ReceiveName = ReceiveName;
            Model.ReceivePhone = ReceivePhone;
            Model.TotalAmount = common.ReversePrice(StrTotalAmount);
            Model.TotalReduceAmount = common.ReversePrice(StrTotalReduce);
            Model.TotalPaid = common.ReversePrice(StrTotalPaid);
            Model.TotalRemain = common.ReversePrice(StrTotalRemain);
            Model.CreatedDate = CreatedDate;
            Model.IsDeliveried = IsDeliveried;
            Model.IsPaid = IsPaid;
            Model.CustomerID = CustomerID;
            Model.EmployeeID = EmployeeID;
            if (ReceiptID == 0)
            {
                Model.CreatedDate = DateTime.Now;
            }
        }

        public override void Preview()
        {
            throw new NotImplementedException();
        }
    }
}

