﻿//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ViewModel.DataManagement;
using ViewModel.MVVMLight;
using ViewModel.TreeView;

namespace ViewModel
{
    /// <summary>
    /// Class MyViewModel - ViewModel implementation 
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class MyViewModel : INotifyPropertyChanged
    {

        public ICommand Click_Browse { get; }
        public ICommand Click_Button { get; }

        #region constructors
        public MyViewModel(IBrowse browse)
        {
            this.browse = browse;
            HierarchicalAreas = new ObservableCollection<BaseTreeViewItem>();
            Click_Button = new RelayCommand(LoadDLL);
            Click_Browse = new RelayCommand(Browse);
        }
        #endregion

        #region DataContext
        public ObservableCollection<BaseTreeViewItem> HierarchicalAreas { get; set; }
        public string PathVariable { get; set; }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
        #endregion

        #region private
        private IBrowse browse;
        private void LoadDLL()
        {
            DllLoader.LoadDLL(PathVariable, HierarchicalAreas);
        }

        private void Browse()
        {
            PathVariable = browse.GetPath();
        }
        #endregion
    }
}