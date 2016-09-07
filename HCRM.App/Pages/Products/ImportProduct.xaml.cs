using System.Windows.Controls;

namespace HCRM.App.Pages.Products
{
    /// <summary>
    /// Interaction logic for SaleProduct.xaml
    /// </summary>
    public partial class ImportProduct : UserControl
    {
        public ImportProduct()
        {
            InitializeComponent();
            DataContext = new ViewModels.ImportFormViewModel();
        }
    }
}
