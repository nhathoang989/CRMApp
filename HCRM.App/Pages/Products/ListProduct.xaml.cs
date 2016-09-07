using System.Windows.Controls;
using System.Windows.Input;

namespace HCRM.App.Pages.Products
{
    /// <summary>
    /// Interaction logic for ImportProduct.xaml
    /// </summary>
    public partial class ListProduct : UserControl
    {
        public ListProduct()
        {
            InitializeComponent();
            DataContext = new ViewModels.ProductViewModels.ProductPageViewModel();
        }
    }
}
