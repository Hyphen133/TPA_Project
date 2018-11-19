using Microsoft.Win32;
using ViewModel;

namespace ViewWPF
{
    class ViewBrowse : IBrowse
    {
        public string GetPath()
        {
            OpenFileDialog test = new OpenFileDialog()
            {
                Filter = "Dynamic Library File(*.dll)| *.dll"
            };
            test.ShowDialog();
            return test.FileName;
        }
    }
}
