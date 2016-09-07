using HCRM.WarehouseApp.Framework;
using System.Windows;

namespace HCRM.WarehouseApp
{
    /// <summary>
    /// Interaction logic for ApplicationView.xaml
    /// </summary>
    public partial class ApplicationView : Window
    {
        public ApplicationView()
        {
            InitializeComponent();
            //ApplicationViewModel context = new ApplicationViewModel();
            //this.DataContext = context;
            //LoadMenuByRole("Admin");            

        }
        public void showLoading(bool isBusy)
        {            
            busyIndicator.IsBusy = isBusy;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
   
}
