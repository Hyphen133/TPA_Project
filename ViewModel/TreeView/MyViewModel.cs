﻿//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TP.GraphicalData.MVVMLight;
using TPA.Reflection.Model;
using TPAv2.Services;
using ViewWPF.TreeView;

namespace TP.GraphicalData.TreeView
{
  /// <summary>
  /// Class MyViewModel - ViewModel implementation 
  /// </summary>
  /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
  public class BaseViewModel : INotifyPropertyChanged
  {

    #region constructors
    public BaseViewModel()
    {
      HierarchicalAreas = new ObservableCollection<TreeViewItem>();
      Click_Button = new RelayCommand(LoadDLL);
      Click_Browse = new RelayCommand(Browse);
    }
    #endregion

    #region DataContext
    public ObservableCollection<TreeViewItem> HierarchicalAreas { get; set; }
    public string PathVariable { get; set; }
    
    public ICommand Click_Browse { get; }
    public ICommand Click_Button { get; }
    #endregion

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    public void RaisePropertyChanged(string propertyName_)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
    }
        #endregion

        #region private
        private void LoadDLL()
        {
            if (PathVariable.Substring(PathVariable.Length - 4) == ".dll")
            {
                DataService.LoadAssembly(PathVariable);
                AssemblyMetadata assemblyMetadata = DataService.LoadAssembly(PathVariable);
                //XmlSerializer.SerializeAssembly(assemblyMetadata, @"C:\Users\hyphe\Desktop\data.xml");
                //XmlSerializer.DeserializeAssembly(@"C:\Users\hyphe\Desktop\data.xml");
                TreeViewItem originalRootItem = ConversionServices.ConvertAssemblyMetadata(assemblyMetadata);
                TreeViewItem rootItem = new TreeViewItem();
                rootItem.Name = originalRootItem.Name;
                rootItem.OriginalItem = originalRootItem;


               

                HierarchicalAreas.Add(rootItem);
            }
        }

    public virtual void Browse()
    {
      //empty
    }
    #endregion

  }
}