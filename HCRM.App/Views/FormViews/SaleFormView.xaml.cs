using HCRM.App.Framework;
using HCRM.App.Helpers;
using HCRM.App.Ultilities;
using HCRM.App.ViewModels;
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

namespace HCRM.App.Views
{
    /// <summary>
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class SaleFormView : UserControl
    {
        public SaleFormView()
        {
            InitializeComponent();
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            var context = (SaleFormViewModel)DataContext;
            if (e.Action == ValidationErrorEventAction.Added) context.ErrorCount+= 1;
            if (e.Action == ValidationErrorEventAction.Removed) context.ErrorCount -= 1;
        }
    }
}
