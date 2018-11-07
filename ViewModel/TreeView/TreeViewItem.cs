//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections.ObjectModel;

namespace TP.GraphicalData.TreeView
{
  public class TreeViewItem
  {
    public TreeViewItem()
    {
      Children = new ObservableCollection<TreeViewItem>() { null };
      this.m_WasBuilt = false;
    }
    public string Name { get; set; }
    public ObservableCollection<TreeViewItem> Children { get; set; }
    public bool IsExpanded
    {
      get { return m_IsExpanded; }
      set
      {
        m_IsExpanded = value;
        if (m_WasBuilt)
          return;
        //Children.Clear();
        BuildMyself();
        m_WasBuilt = true;
      }
    }

        private void BuildMyself()
        {
            //TODO -> check if originalitem children are not {null}

            this.Children.Clear();
            if(OriginalItem.Children != null)
            {

            }
            for (int i = 0; i < OriginalItem.Children.Count; i++)
            {
                if(OriginalItem.Children[i] != null)
                {
                    this.Children.Add(new TreeViewItem());
                    this.Children[i].Name = OriginalItem.Children[i].Name;
                    this.Children[i].OriginalItem = OriginalItem.Children[i];
                }
                
            }
        }

        public TreeViewItem OriginalItem { get; set; }

        private bool m_WasBuilt;
    private bool m_IsExpanded;
    

  }
}

