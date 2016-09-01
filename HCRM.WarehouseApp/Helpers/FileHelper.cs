using Microsoft.Win32;
using System.IO;

namespace HCRM.WarehouseApp.Helpers
{
    class FileHelper
    {
        public FileInfo OpenFile(string defaultExtension, string filter)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.DefaultExt = defaultExtension;
            fd.Filter = filter;
            bool? result = fd.ShowDialog();

            if (result == true)
            {
                // Open document 
                string filename = fd.FileName;
                return new FileInfo(fd.FileName);
            }
            return null;
            //return result.Value ? fd.OpenFile() : null;
        }

        public FileInfo SaveFile(string defaultExtension, string filter)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.DefaultExt = defaultExtension;
            fd.Filter = filter;

            bool? result = fd.ShowDialog();
            if (result == true)
            {
                // Open document 
                string filename = fd.FileName;
                return new FileInfo(fd.FileName);
            }
            return null;

            //return result.Value ? fd.OpenFile() : null;
        }
    }
}