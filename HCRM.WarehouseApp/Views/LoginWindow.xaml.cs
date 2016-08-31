using HCRM.WarehouseApp.Helpers;
using HCRM.Data;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HCRM.WarehouseApp.Views
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        public LoginWindow()
        {
                InitializeComponent();           
        }

        private async void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            var rsp = await ApiHelper.getApi<CRM_Product>(Helpers.Parameters.ApiContentType.XWWWForm, "api/Product/GetProduct/1", new List<Helpers.Parameters.ApiParameter>());
            CRM_Product p = rsp.Data;
            
            //var p = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_Product>(rsp.Content);
            //p.SEName = "test";

            //Parameters.ApiParameter param = new Parameters.ApiParameter();
            //param.Key = "id";
            //param.Value = Newtonsoft.Json.JsonConvert.SerializeObject(p);
            //var lstParam = new List<Parameters.ApiParameter>();
            //lstParam.Add(param);

            //var rsp1 = await ApiHelper.postApi(p, "api/Product/CreateProduct");
            //var rsp1 = await ApiHelper.postApi("test text", "api/Product/Test");
            //MessageBox.Show(rsp1.Content);
        }
    }
}
