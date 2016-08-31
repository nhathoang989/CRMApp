using HCRM.App.ViewModels;
using Microsoft.Owin.Hosting;
using System.Windows;

namespace HCRM.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AuthenticatedViewModel currUser = new AuthenticatedViewModel("test");
        public static string baseWebAPIAddress = "http://localhost:7700/";

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            WebApp.Start(url: baseWebAPIAddress);

        }
    }

    
}
