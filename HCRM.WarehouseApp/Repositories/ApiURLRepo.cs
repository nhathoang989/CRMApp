using HCRM.WarehouseApp.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.WarehouseApp.Repositories
{
    public class ApiURLRepo
    {
        #region Properties

        private string _baseURL;
        private string _saveURL;
        private string _removeURL;
        private string _getSingleURL;
        private string _searchURL;
        private string _getListURL;
        private string _modelName;

        public string BaseURL
        {
            get
            {
                return _baseURL;
            }

            set
            {
                _baseURL = value;
            }
        }

        public string SaveURL
        {
            get
            {
                return _saveURL;
            }

            set
            {
                _saveURL = value;
            }
        }

        public string RemoveURL
        {
            get
            {
                return _removeURL;
            }

            set
            {
                _removeURL = value;
            }
        }

        public string GetSingleURL
        {
            get
            {
                return _getSingleURL;
            }

            set
            {
                _getSingleURL = value;
            }
        }

        public string SearchListURL
        {
            get
            {
                return _searchURL;
            }

            set
            {
                _searchURL = value;
            }
        }

        public string GetListURL
        {
            get
            {
                return _getListURL;
            }

            set
            {
                _getListURL = value;
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

        #endregion
        public ApiURLRepo(string baseURL, string modelName)
        {
            BaseURL = baseURL;
            ModelName = modelName;
            SaveURL = common.CombinePath(new string[] { baseURL, "SaveModel" });
            RemoveURL = common.CombinePath(new string[] { baseURL, "RemoveModel" });
            GetSingleURL = common.CombinePath(new string[] { baseURL, "GetSingleModel" });
            GetListURL = common.CombinePath(new string[] { baseURL, "GetModelList" });
            SearchListURL = common.CombinePath(new string[] { baseURL, "SearchModelList" });
        }
    }
}
