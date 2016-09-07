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

namespace HCRM.App.ViewModels.ElementViewModels
{
    public class ReceiptImportViewModel : ViewModelBase<CRM_Receipt_Import, ReceiptImportViewModel>
    {
       
        private List<ReceiptDetailsViewModel> _lstDetails;
        private EmployeeViewModel _employee;
        private ProviderViewModel _provider;
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
        private int? _providerID;
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

        public int? ProviderID
        {
            get
            {
                return _providerID;
            }

            set
            {
                _providerID = value; OnPropertyChanged("ProviderID");
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
                    _printPreviewCommand = new RelayCommand(m => PrintPreview());
                }
                return _printPreviewCommand;
            }

            set
            {
                _printPreviewCommand = value;
            }
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

        public ProviderViewModel Provider
        {
            get
            {
                return _provider;
            }

            set
            {
                _provider = value;
                OnPropertyChanged("Provider");
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
            ReportViewer rp = new ReportViewer();
            ApplicationService.Instance.GlobalEventAggregator.GetEvent<PrintReceiptEvent<XpsDocument>>().Publish(GetPrintReceiptDoc()); ApplicationService.Instance.GlobalEventAggregator.GetEvent<PrintReceiptEvent<XpsDocument>>().Publish(GetPrintReceiptDoc());
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

        #region Functions


        private async void PrintResultHandler(bool result)
        {
            if (result)
            {
                var resp = await SaveModel();
                result = resp.StatusCode == System.Net.HttpStatusCode.OK;
            }
            ApplicationService.Instance.GlobalEventAggregator.GetEvent<SaveReceiptResultEvent<bool>>().Publish(result);
        }

        public override void RemoveModel()
        {
            throw new NotImplementedException();
        }

        public override async Task<IRestResponse> SaveModel()
        {
            ViewToModel();

            var result = await ReceiptImportRepo.Instance.SaveModel(Model);

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

            StrTotalAmount = common.FormatPrice(Model.TotalAmount.ToString());
            StrTotalReduce = common.FormatPrice(Model.TotalReduceAmount.ToString());
            StrTotalPaid = common.FormatPrice(Model.TotalPaid.ToString());
            StrTotalRemain = common.FormatPrice(Model.TotalRemain.ToString());
            IsPaid = Model.IsPaid;
            ProviderID = Model.ProviderID;
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
            Model.TotalAmount = common.ReversePrice(StrTotalAmount);
            Model.TotalReduceAmount = common.ReversePrice(StrTotalReduce);
            Model.TotalPaid = common.ReversePrice(StrTotalPaid);
            Model.TotalRemain = common.ReversePrice(StrTotalRemain);
            Model.CreatedDate = CreatedDate;
            Model.IsPaid = IsPaid;
            Model.ProviderID = ProviderID;
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

        #endregion

        public ReceiptImportViewModel() : base("api/ReceiptImport", "ReceiptImport")
        {
            Model = new CRM_Receipt_Import();
            ListDetails = new List<ReceiptDetailsViewModel>();
            ActionResultEvent _resultEvent = ApplicationService.Instance.GlobalEventAggregator.GetEvent<ActionResultEvent>();
            _resultEvent.Subscribe(PrintResultHandler);
        }
        public ReceiptImportViewModel(CRM_Receipt_Import model) : base("api/ReceiptImport", "ReceiptImport")
        {
            Model = model;
            ModelToView();
        }
    }
}

