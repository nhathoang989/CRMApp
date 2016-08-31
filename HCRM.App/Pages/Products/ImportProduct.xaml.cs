using System.Windows.Controls;
using System.Windows.Input;

namespace HCRM.App.Pages.Products
{
    /// <summary>
    /// Interaction logic for ImportProduct.xaml
    /// </summary>
    public partial class ImportProduct : UserControl
    {
        public ImportProduct()
        {
            InitializeComponent();
            DataContext = new ViewModels.ProductViewModels.ProductPageViewModel();
        }
    }
}
