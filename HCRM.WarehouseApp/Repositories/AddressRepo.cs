using HCRM.Data;
using HCRM.WarehouseApp.ViewModels.ElementViewModels;

namespace HCRM.WarehouseApp.Repositories
{
    public class AddressRepo:BaseRepo<CRM_Address,AddressViewModel>
    {
        private static AddressRepo _instance;
        public static AddressRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AddressRepo();
                }
                return _instance;
            }
        }
        public AddressRepo() : base("api/Address","Address")
        {
        }
        
    }
}
