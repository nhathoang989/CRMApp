using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.App.ViewModels
{
    public class AuthenticatedViewModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string client_id { get; set; }
        public int expires_in { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }

        public string username { get; set; }
        public string roles { get; set; }

        public JArray arrRoles { get { return JArray.Parse(roles); } }
        public AuthenticatedViewModel(string name)
        {
            username = name;
        }
        public AuthenticatedViewModel()
        {

        }
    }
}
