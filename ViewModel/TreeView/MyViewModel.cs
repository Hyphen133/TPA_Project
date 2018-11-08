//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.Collections.ObjectModel;
using System.ComponentModel;

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
    }
    #endregion

    #region DataContext
    public ObservableCollection<TreeViewItem> HierarchicalAreas { get; set; }
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
        public virtual void LoadDLL()
        {
            //empty
        }

        public virtual void Browse()
    {
      //empty
    }
    #endregion
  }
}
