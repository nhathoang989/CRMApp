using HCRM.App.Framework;
using HCRM.App.Helpers;
using System.IO;
using System.Windows.Input;

namespace HCRM.App.ViewModels
{
    public class FileDialogViewModel:ObjectBase
    {
        private string _fileName;
        public FileInfo _info;
        public FileDialogViewModel()
        {
            SaveCommand = new RelayCommand(
                    p => SaveFile());
            OpenCommand = new RelayCommand(
                    p => OpenFile());
        }
        #region Properties

        public FileInfo Info
        {
            get { return _info; }
            set {
                if (_info != value)
                {
                    _info = value;
                    if (value!=null)
                    {
                        FileName = value.Name;                        
                    }
                    OnPropertyChanged("Info");
                }
                
            }
        }

        public string Extension
        {
            get;
            set;
        }
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; OnPropertyChanged("FileName"); }
        }
        public string Filter
        {
            get;
            set;
        }
        public ICommand OpenCommand
        {
            get;
            set;
        }

        public ICommand SaveCommand
        {
            get;
            set;
        }

        #endregion

        private void OpenFile()
        {
            FileHelper fileServices = new FileHelper();
            Info = fileServices.OpenFile(Extension, Filter);
            if (Info!=null)
            {
                FileName = Info.Name;
            }
            
        }

        private void SaveFile()
        {
            FileHelper fileServices = new FileHelper();
            Info = fileServices.SaveFile(Extension, Filter);
        }
    }
}
