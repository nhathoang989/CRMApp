using HCRM.App.ViewModels;
using HCRM.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HCRM.App.Ultilities;
using System.IO;
using HCRM.App.Helpers;
using HCRM.App.ViewModels.ElementViewModels;

namespace HCRM.App.Repositories
{
    public class ProviderRepo : BaseRepo<CRM_Provider, ProviderViewModel>
    {
        private static ProviderRepo _instance;
        public static ProviderRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProviderRepo();
                }
                return _instance;
            }
        }

        public ProviderRepo() : base("api/Provider", "Provider")
        {
        }

       

    }
}
