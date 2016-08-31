using HCRM.App.Repositories;
using HCRM.App.ViewInterfaces;
using HCRM.App.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace HCRM.App.Framework
{
    public class ApplicationViewModel : ObjectBase
    {
        #region Fields

        private ICommand _changePageCommand;


        private IPageViewModel _currentPageViewModel;
        private List<MenuViewModel> _pageViewModels;
        private bool isBusy;
        public static ApplicationViewModel _model;
        #endregion

        public ApplicationViewModel()
        {
            // Add available pages
            //PageViewModels.Add(new MenuViewModel("Login", new LoginViewModel()));
            //PageViewModels.Add(new MenuViewModel("Home", new HomeViewModel()));

            //// Set starting page
            //if (App.currUser==null)
            //{
            //    CurrentPageViewModel = PageViewModels[0].Model;
            //}
            //else {
            //    CurrentPageViewModel = PageViewModels[1].Model;
            //}

            CurrentPageViewModel = new ViewModels.SaleFormViewModel();
            //CurrentPageViewModel = new ViewModels.ProductViewModels.ProductPageViewModel();
            //CurrentPageViewModel = new ViewModels.OthersViewModels.EmployeePageViewModel();
            //CurrentPageViewModel = new ViewModels.OthersViewModels.CustomerPageViewModel();

        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((string)p),
                        p => p is string);
                }

                return _changePageCommand;
            }
        }

        public List<MenuViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<MenuViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        
        #endregion

        #region Methods
        public static ApplicationViewModel GetInstance() {
            if (_model == null)
            {
                var mainWindow = System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
                if (mainWindow!=null)
                {
                    ApplicationViewModel context = (ApplicationViewModel)mainWindow.DataContext;
                    _model = context;
                }
                
            }
            return _model;            
        }
        private void ChangeViewModel(MenuViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel).Model;
        }

        private void ChangeViewModel(string pageArg)
        {
            var viewModel = MenuRepo.GetPageView(pageArg);

            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = viewModel.Model;
        }

        #endregion
    }
}
