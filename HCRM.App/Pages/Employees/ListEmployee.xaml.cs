using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HCRM.App.Pages.Employees
{
    /// <summary>
    /// Interaction logic for ListEmployee.xaml
    /// </summary>
    public partial class ListEmployee : UserControl
    {
        public ListEmployee()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                e.Handled = true;
            }
            catch {
                e.Handled = false;
            }
        }
    }
}
