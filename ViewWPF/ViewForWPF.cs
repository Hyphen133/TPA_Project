using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TP.GraphicalData.MVVMLight;
using TP.GraphicalData.TreeView;
using ViewModel.TreeView;

namespace ViewWPF
{
    public class ViewForWPF : BaseViewModel
    {
        public ICommand Click_Browse { get; }
        public ICommand Click_Button { get; }

        public ViewForWPF() : base()
        {
            Click_Button = new RelayCommand(LoadDLL);
            Click_Browse = new RelayCommand(Browse);
        }

        public Visibility ChangeControlVisibility { get; set; } = Visibility.Hidden;

        public override void Browse()
        {
            OpenFileDialog test = new OpenFileDialog()
            {
                Filter = "Dynamic Library File(*.dll)| *.dll"
            };
            test.ShowDialog();
            if (test.FileName.Length == 0)
                MessageBox.Show("No files selected");
            else
            {
                PathVariable = test.FileName;
                ChangeControlVisibility = Visibility.Visible;
                RaisePropertyChanged("ChangeControlVisibility");
                RaisePropertyChanged("PathVariable");
            }
        }

        public override void LoadDLL() => DllLoader.LoadDLL(PathVariable, HierarchicalAreas);
    }
}
