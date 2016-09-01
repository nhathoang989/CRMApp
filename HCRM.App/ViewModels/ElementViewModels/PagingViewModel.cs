using HCRM.App.Framework;
using HCRM.App.Repositories;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using System.Linq;

namespace HCRM.App.ViewModels.ElementViewModels
{
    public class PagingViewModel<TModel, TView> : ObjectBase where TModel : new() where TView : new()
    {
        private BaseRepo<TModel, TView> _repo;
        private ICommand previousCommand;
        private ICommand nextCommand;
        private ICommand firstCommand;
        private ICommand lastCommand;
        private List<TView> lstDisplay;
        private List<TView> lstAll;
        private int _pageSize = 10;
        private int _itemCount;
        private int _currentPageIndex;
        private int _totalPage;
        #region Properties

        public ICommand PreviousCommand
        {
            get
            {

                if (previousCommand == null)
                {
                    previousCommand = new RelayCommand(p => ChangeListView(CurrentPageIndex-1),p=>CanPrevPage());
                }
                return previousCommand;
            }

            set
            {
                previousCommand = value;
            }
        }

       

        public ICommand NextCommand
        {
            get
            {
                if (nextCommand == null)
                {
                    nextCommand = new RelayCommand(p => ChangeListView(CurrentPageIndex), p => CanNextPage());
                }
                return nextCommand;
            }

            set
            {
                nextCommand = value;
            }
        }

        public ICommand FirstCommand
        {
            get
            {
                if (firstCommand == null)
                {
                    firstCommand = new RelayCommand(p => ChangeListView(0), p => CanFirstPage());
                }
                return firstCommand;
            }

            set
            {
                firstCommand = value;
            }
        }

        public ICommand LastCommand
        {
            get
            {
                if (lastCommand == null)
                {
                    lastCommand = new RelayCommand(p => ChangeListView(TotalPages - 1), p => CanLastPage());
                }
                return lastCommand;
            }
            
            set
            {
                lastCommand = value;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = value;
            }
        }

        public int ItemCount
        {
            get
            {
                return _itemCount;
            }

            set
            {
                _itemCount = value;
                _totalPage = (ItemCount / PageSize) + ((ItemCount % PageSize > 0) ? 1 : 0);
                OnPropertyChanged("ItemCount");
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return _currentPageIndex;
            }

            set
            {
                _currentPageIndex = value;
                OnPropertyChanged("CurrentPageIndex");
            }
        }

        public List<TView> LstDisplay
        {
            get
            {
                return lstDisplay;
            }

            set
            {
                lstDisplay = value;
                OnPropertyChanged("LstDisplay");
            }
        }

        public BaseRepo<TModel, TView> Repo
        {
            get
            {
                return _repo;
            }

            set
            {
                _repo = value;
            }
        }

        public int TotalPages
        {
            get
            {                
                return _totalPage;
            }

            set
            {
                _totalPage = value;
                OnPropertyChanged("TotalPages");
            }
        }

        public List<TView> LstAll
        {
            get
            {
                return lstAll;
            }

            set
            {
                lstAll = value;
            }
        }

        #endregion
        #region Funcitons
        bool CanFirstPage()
        {
            return CurrentPageIndex > 1 ;
        }
        bool CanLastPage()
        {
            return CurrentPageIndex < TotalPages;
        }
        bool CanPrevPage() {
            return CurrentPageIndex > 1;
        }
        bool CanNextPage() {
            return CurrentPageIndex < TotalPages;
        }

        void ChangeListView(int? pageIndex) {
            if (lstAll != null)
            {

                pageIndex = pageIndex.HasValue ? pageIndex : 0;
                CurrentPageIndex = pageIndex.Value +1;
                LstDisplay = LstAll.Skip(pageIndex.Value * PageSize).Take(PageSize).ToList();

            }
        }
        #endregion

        public PagingViewModel(List<TView> lstView)
        {
            LstAll = lstView;
            ItemCount = lstView.Count;
            ChangeListView(0);
        }

        public PagingViewModel(List<TView> lstView, int pageSize)
        {
            LstAll = lstView;
            ItemCount = lstView.Count;
            PageSize = pageSize;
            ChangeListView(0);
        }

    }
}
