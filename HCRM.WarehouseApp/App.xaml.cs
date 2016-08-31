using HCRM.WarehouseApp.Framework;
using HCRM.WarehouseApp.ViewModels;
using Microsoft.Owin.Hosting;
using System.Windows;

namespace HCRM.WarehouseApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static AuthenticatedViewModel currUser = new AuthenticatedViewModel("test");
        public static string baseWebAPIAddress = "http://localhost:7000/";

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            WebApp.Start(url: baseWebAPIAddress);
            //CommonViewModel.GetInstance();
            ApplicationView app = new ApplicationView();
            ApplicationViewModel context = new ApplicationViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
