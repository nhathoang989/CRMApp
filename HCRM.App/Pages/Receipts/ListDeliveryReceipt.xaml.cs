using HCRM.App.ViewModels.FormViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCRM.App.Pages.Receipts
{
    /// <summary>
    /// Interaction logic for ListDeliveryReceipt.xaml
    /// </summary>
    public partial class ListDeliveryReceipt : UserControl
    {
        public ListDeliveryReceipt()
        {
            InitializeComponent();
            DataContext = new ListDeliveryReceiptViewModel();
        }
    }
}
