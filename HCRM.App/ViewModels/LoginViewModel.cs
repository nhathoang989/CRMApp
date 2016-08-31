using HCRM.App.Framework;
using HCRM.App.ViewInterfaces;
using System;
using System.Windows.Input;
using System.Windows.Controls;
using HCRM.App.Helpers;
using HCRM.App.Ultilities;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace HCRM.App.ViewModels
{
    public class LoginViewModel: ObjectBase, IPageViewModel
    {

        public string lblUsername { get { return "Tên đăng nhập"; } }
        public string lblPassword { get { return "Mật khẩu"; } }
        public string lblLogin { get { return "Đăng nhập"; } }

        #region Properties

        private string username;

        private ICommand _loginCommand;

        public int ErrorCount
        {
            get
            {
                return ErrorCount;
            }

            set
            {
                ErrorCount = value;
            }
        }
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                RaisePropertyChanged("Username");
            }
        }
        
        public string PageTitle
        {
            get
            {
                return "Login Page";
            }
        }

        public string Key { get { return "Key"; } }
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(
                        p => LoginExecute((PasswordBox)p),
                        p=> CanLoginExecute());
                }

                return _loginCommand;
            }
        }

        #endregion

        private class LoginData{
            public string grant_type { get { return "password"; } }
            public string username;
            public string password;
        }

        Boolean CanLoginExecute()
        {
            return !string.IsNullOrEmpty(Username);
        }      
        private async void LoginExecute(PasswordBox passwordBox)
        {            
            if (!CanLoginExecute()) return;
            if (string.IsNullOrEmpty(passwordBox.Password))
            {

                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            common.showLoading(true);
            string apiName = "token";
            LoginData data = new LoginData()
            {
                username = this.username,
                password = passwordBox.Password
            };            
            var authResp = await ApiHelper.postApi<AuthenticatedViewModel>(Parameters.ApiContentType.XWWWForm, apiName, JObject.FromObject(data));
            if (!string.IsNullOrEmpty(authResp.ErrorMessage) || string.IsNullOrEmpty(authResp.Content))
            {
                common.showLoading(false);
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }
            else
            {
                App.currUser = authResp.Data;
               
                if (App.currUser!=null )
                {
                    common.changePageView(Parameters.PageView.Home);
                   
                }
                common.showLoading(false);
            }
           
        }

    }
}

