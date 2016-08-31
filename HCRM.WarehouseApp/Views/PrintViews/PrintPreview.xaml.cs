using HCRM.WarehouseApp.Behaviors;
using HCRM.WarehouseApp.Services;
using HCRM.WarehouseApp.ViewModels.ElementViewModels;
using System.Windows;
using System.Windows.Controls;

namespace HCRM.WarehouseApp.Views.PrintViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PrintPreview : Window
    {
        ReceiptDeliveryViewModel _receipt;

        public ReceiptDeliveryViewModel Receipt
        {
            get
            {
                return _receipt;
            }

            set
            {
                _receipt = value;
            }
        }

        public PrintPreview()
        {
            InitializeComponent();
            this.DataContext = _receipt;
        }
        public PrintPreview(ReceiptDeliveryViewModel receipt)
        {
            InitializeComponent();
            _receipt = receipt;
            this.DataContext = _receipt;
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (Receipt!=null)
            {

                
                PrintDialog dialog = new PrintDialog();
                
                if (dialog.ShowDialog() != true) return;

                var result = false;// await ReceiptRepo

                dialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
                dialog.PrintTicket.PageMediaSize = new System.Printing.PageMediaSize(System.Printing.PageMediaSizeName.ISOA5);
                //printGrid.Measure(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));
                printGrid.Arrange(new Rect(new Point(5, 5), printGrid.DesiredSize));
                
                dialog.PrintVisual(printGrid, "A WPF printing");

                ApplicationService.Instance.EventAggregator.GetEvent<SaveReceiptDeliveryResultEvent>().Publish(result);
            }
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var win = new Window3();
            //win.Show();
            //this.Close();
        }

    }
}
