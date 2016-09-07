using CodeReason.Reports;
using FirstFloor.ModernUI.Windows.Controls;
using HCRM.App.Behaviors;
using HCRM.App.Services;
using Prism.Events;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Xps.Packaging;

namespace HCRM.App.Views.CustomControls
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : Window
    {
        private bool _firstActivated = true;
        XpsDocument xpsDoc;
        IEventAggregator _reportEvent;

        public IEventAggregator ReportEvent
        {
            get
            {
                if (_reportEvent==null)
                {
                    _reportEvent = ApplicationService.Instance.GlobalEventAggregator;
                }
                return _reportEvent;
            }

            set
            {
                _reportEvent = value;
            }
        }

        public ReportViewer()
        {
            InitializeComponent();
            PrintReceiptEvent<XpsDocument> _event = ReportEvent.GetEvent<PrintReceiptEvent<XpsDocument>>();
            _event.Subscribe(GetReceiptDoc);

            PrintResultEvent _resultEvent = ReportEvent.GetEvent<PrintResultEvent>();
            _resultEvent.Subscribe(PrintResultHandler);

            documentViewer.EventHandler = ReportEvent;
        }

        public ReportViewer(IEventAggregator parentEvent)
        {
            InitializeComponent();
            ReportEvent = parentEvent;
            PrintReceiptEvent<XpsDocument> _event = ReportEvent.GetEvent<PrintReceiptEvent<XpsDocument>>();
            _event.Subscribe(GetReceiptDoc);

            PrintResultEvent _resultEvent = ReportEvent.GetEvent<PrintResultEvent>();
            _resultEvent.Subscribe(PrintResultHandler);

            documentViewer.EventHandler = ReportEvent;
        }

        private void PrintResultHandler(bool obj)
        {
            ReportEvent.GetEvent<ActionResultEvent>().Publish(obj);
            this.Close();            
        }

        private void GetReceiptDoc(XpsDocument obj)
        {
            xpsDoc = obj;//documentViewer.Print();
        }

        public ReportViewer(XpsDocument doc)
        {
            InitializeComponent();
            xpsDoc = doc;
        }

        private void ModernWindow_Activated(object sender, System.EventArgs e)
        {

            if (!_firstActivated) return;

            _firstActivated = false;

            
            documentViewer.Document = xpsDoc.GetFixedDocumentSequence();
            //try
            //{
            //    ReportDocument reportDocument = new ReportDocument();

            //    StreamReader reader = new StreamReader(new FileStream(@"ReportTemplates\BarcodeReport.xaml", FileMode.Open, FileAccess.Read));
            //    reportDocument.XamlData = reader.ReadToEnd();
            //    reportDocument.XamlImagePath = Path.Combine(Environment.CurrentDirectory, @"ReportTemplates\");
            //    reader.Close();

            //    ReportData data = new ReportData();

            //    // set constant document values
            //    data.ReportDocumentValues.Add("PrintDate", DateTime.Now); // print date is now

            //    // sample table "Ean"
            //    DataTable table = new DataTable("Ean");
            //    table.Columns.Add("Position", typeof(string));
            //    table.Columns.Add("Item", typeof(string));
            //    table.Columns.Add("EAN", typeof(string));
            //    table.Columns.Add("Count", typeof(int));
            //    Random rnd = new Random(1234);
            //    for (int i = 1; i <= 100; i++)
            //    {
            //        // randomly create some articles
            //        StringBuilder sb = new StringBuilder();
            //        for (int j = 1; j <= 13; j++) sb.Append(rnd.Next(10));
            //        table.Rows.Add(new object[] { i, "Item " + i.ToString("0000"), sb.ToString(), rnd.Next(9) + 1 });
            //    }
            //    data.DataTables.Add(table);

            //    DateTime dateTimeStart = DateTime.Now; // start time measure here

            //    XpsDocument xps = reportDocument.CreateXpsDocument(data);
            //    documentViewer.Document = xps.GetFixedDocumentSequence();

            //    // show the elapsed time in window title
            //    //Title += " - generated in " + (DateTime.Now - dateTimeStart).TotalMilliseconds + "ms";
            //}
            //catch (Exception ex)
            //{
            //    // show exception
            //    MessageBox.Show(ex.Message + "\r\n\r\n" + ex.GetType() + "\r\n" + ex.StackTrace, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
            //}
        }
    }
}
