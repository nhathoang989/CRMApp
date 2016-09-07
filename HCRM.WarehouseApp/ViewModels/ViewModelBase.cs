using HCRM.WarehouseApp.Framework;
using HCRM.WarehouseApp.Repositories;
using HCRM.WarehouseApp.Services;
using HCRM.WarehouseApp.Ultilities;
using Prism.Events;
using RestSharp;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCRM.WarehouseApp.ViewModels
{
    public abstract class ViewModelBase<TModel, TView> : ObjectBase where TModel:new() where TView: new()
    {
        protected static IEventAggregator _eventAggregator = ApplicationService.Instance.EventAggregator;

        private BaseRepo<TModel, TView> _baseRepo;
        private TModel _model;
        private string _modelName;
        private int _errorCount;
        //private ApiURLRepo _urlRepo;

        private ICommand _saveCommand;
        private ICommand _removeCommand;
        
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand==null)
                {
                    _saveCommand = new RelayCommand(p => SaveModel(), p => CanSaveModel());
                }
                return _saveCommand;
            }

            set
            {
                _saveCommand = value;
            }
        }

        
        public int ErrorCount
        {
            get
            {
                return _errorCount;
            }

            set
            {
                _errorCount = value;
                OnPropertyChanged("ErrorCount");
            }
        }

        public TModel Model
        {
            get
            {
                return _model;
            }

            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }     
      

        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand(p => RemoveModel());
                }
                return _removeCommand;
            }

            set
            {
                _removeCommand = value;
            }
        }

        public BaseRepo<TModel, TView> BaseRepo
        {
            get
            {
                return _baseRepo;
            }

            set
            {
                _baseRepo = value;
            }
        }
        public string ModelName
        {
            get
            {
                return _modelName;
            }

            set
            {
                _modelName = value;
            }
        }

        //public ApiURLRepo URLRepo
        //{
        //    get
        //    {
        //        return _urlRepo;
        //    }

        //    set
        //    {
        //        _urlRepo = value;
        //    }
        //}

        public abstract void RemoveModel();
        public abstract Task<IRestResponse> SaveModel();
        public abstract bool CanSaveModel();
        public abstract void ModelToView();
        public abstract void ViewToModel();

        public ViewModelBase(string baseApiURL, string modelName)
        {
            ModelName = modelName;
            //URLRepo = new ApiURLRepo(baseApiURL, modelName);
            BaseRepo = new BaseRepo<TModel, TView>(baseApiURL,modelName);
        }
        public ViewModelBase()
        {
        }     
    }
}
