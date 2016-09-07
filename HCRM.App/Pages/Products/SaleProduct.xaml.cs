using System.Windows.Controls;

namespace HCRM.App.Pages.Products
{
    /// <summary>
    /// Interaction logic for SaleProduct.xaml
    /// </summary>
    public partial class SaleProduct : UserControl
    {
        public SaleProduct()
        {
            InitializeComponent();
            DataContext = new ViewModels.SaleFormViewModel();
        }
    }
}
