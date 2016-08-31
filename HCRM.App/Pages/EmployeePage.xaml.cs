using System.Windows.Controls;

namespace HCRM.App.Pages
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : UserControl
    {
        public EmployeePage()
        {
            InitializeComponent();
            DataContext = new ViewModels.OthersViewModels.EmployeePageViewModel();
        }
    }
}
