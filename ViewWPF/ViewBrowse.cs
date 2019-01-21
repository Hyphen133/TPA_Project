using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using ViewModel;

namespace ViewWPF
{
    class ViewBrowse : IBrowse
    {
        public string GetFilePath()
        {
            OpenFileDialog test = new OpenFileDialog();
            test.ShowDialog();
            return test.FileName;
        }

        public string GetFolderPath()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return dialog.FileName + "\\test.xml";
            }
            else
            {
                return GetFolderPath();
            }
        }
    }
}
