using HCRM.App.Framework;
using HCRM.App.Repositories;
using HCRM.App.Services;
using HCRM.App.ViewInterfaces;
using HCRM.App.ViewModels.ElementViewModels;
using HCRM.Data;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCRM.App.ViewModels.FormViewModels
{
    class ListDeliveryReceiptViewModel : ObjectBase, IPageViewModel
    {
        private bool _isBusy;
        private int PageSize = 5;
        private IEventAggregator _eventAggregator;

        private ReceiptDeliveryViewModel _currentReceipt;
        private List<ReceiptDeliveryViewModel> _listAllReceipt;
        private List<ReceiptDeliveryViewModel> _listDisplayReceipt;

        private PagingViewModel<CRM_Receipt_Delivery, ReceiptDeliveryViewModel> _pagingDataGrid;

        private DateTime _fromDate;
        private DateTime _toDate;

        private ICommand _filterCommand;

        #region Properties

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public string Key
        {
            get
            {
                return "ListDeliveryReceipt"; 
            }
        }

        public string PageTitle
        {
            get
            {
                return "Danh sách hóa đơn bán hàng";
            }
        }

        public List<ReceiptDeliveryViewModel> ListAllReceipt
        {
            get
            {
                return _listAllReceipt;
            }

            set
            {
                _listAllReceipt = value;
                OnPropertyChanged("ListAllReceipt");
            }
        }

        public PagingViewModel<CRM_Receipt_Delivery, ReceiptDeliveryViewModel> PagingDataGrid
        {
            get
            {
                return _pagingDataGrid;
            }

            set
            {
                _pagingDataGrid = value;
                OnPropertyChanged("PagingDataGrid");
            }
        }

        public ReceiptDeliveryViewModel CurrentReceipt
        {
            get
            {
                return _currentReceipt;
            }

            set
            {
                _currentReceipt = value;
                OnPropertyChanged("CurrentReceipt");
            }
        }

        public ICommand FilterCommand
        {
            get
            {
                if (_filterCommand==null)
                {
                    _filterCommand = new RelayCommand(m => FilterReceipt());
                }
                return _filterCommand;
            }

            set
            {
                _filterCommand = value;
            }
        }

        public List<ReceiptDeliveryViewModel> ListDisplayReceipt
        {
            get
            {
                return _listDisplayReceipt;
            }

            set
            {
                _listDisplayReceipt = value;
                OnPropertyChanged("ListDisplayReceipt");
            }
        }

        public DateTime FromDate
        {
            get
            {
                if (_fromDate.Year <= 1900)
                {
                    _fromDate = DateTime.Now.Date;
                }
                return _fromDate;
            }

            set
            {
                _fromDate = value;
                OnPropertyChanged("FromDate");
            }
        }

        public DateTime ToDate
        {
            get
            {
                if (_toDate.Year <= 1900)
                {
                    _toDate = DateTime.Now.Date.AddDays(1);
                }
                return _toDate;
            }

            set
            {
                _toDate = value;
                OnPropertyChanged("ToDate");
            }
        }

        private void FilterReceipt()
        {
            ListDisplayReceipt = ListAllReceipt.Where(m => m.CreatedDate.Date <= ToDate && m.CreatedDate.Date >= FromDate).ToList();
            PagingDataGrid = new PagingViewModel<CRM_Receipt_Delivery, ReceiptDeliveryViewModel>(ListDisplayReceipt, PageSize);
        }

        #endregion
        public ListDeliveryReceiptViewModel()
        {            
            _eventAggregator = ApplicationService.Instance.GlobalEventAggregator;
            RefreshPage();
        }
        async void RefreshPage() {
            IsBusy = true;
            ListAllReceipt = await ReceiptDeliveryRepo.Instance.GetModelList();
            ListDisplayReceipt = ListAllReceipt;
            PagingDataGrid = new PagingViewModel<CRM_Receipt_Delivery,ReceiptDeliveryViewModel>(ListDisplayReceipt, PageSize);
            IsBusy = false;
        }
    }
}
