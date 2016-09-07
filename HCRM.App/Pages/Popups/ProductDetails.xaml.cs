using FirstFloor.ModernUI.Windows.Controls;
using HCRM.App.Behaviors;
using HCRM.App.Services;
using HCRM.App.ViewModels.ElementViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCRM.App.Pages.Popups
{
    /// <summary>
    /// Interaction logic for ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : ModernDialog
    {
        IEventAggregator _eventHandler;
        public ProductDetails()
        {
            InitializeComponent();
            // define the dialog buttons            
            ItemSelected<ProductViewModel> _event = EventHandler.GetEvent<ItemSelected<ProductViewModel>>();
            _event.Subscribe(GetItemPreview);
        }

        private void GetItemPreview(ProductViewModel item)
        {
            DataContext = item;
            
            Button btnSave = new Button();
            btnSave.Content = "Lưu";
            btnSave.Command = item.SaveCommand;
            Button btnCancel = CancelButton;
            btnCancel.Content = "Đóng";

            Buttons = new Button[] { btnSave, btnCancel };
        }

        public ProductDetails(IEventAggregator parentEventHandler)
        {
            EventHandler = parentEventHandler;
            InitializeComponent();
            // define the dialog buttons
            //Buttons = new Button[] { OkButton, CancelButton };
            ItemSelected<ProductViewModel> _event = EventHandler.GetEvent<ItemSelected<ProductViewModel>>();
            _event.Subscribe(GetItemPreview);
        }

        public IEventAggregator EventHandler
        {
            get
            {
                if (_eventHandler == null)
                {
                    _eventHandler = ApplicationService.Instance.GlobalEventAggregator;
                }
                return _eventHandler;
            }

            set
            {
                _eventHandler = value;
            }
        }
    }
}
