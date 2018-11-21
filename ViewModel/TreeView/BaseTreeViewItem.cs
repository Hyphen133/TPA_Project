using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.TreeView
{
    public abstract class BaseTreeViewItem
    {
        public BaseTreeViewItem()
        {
            Children = new ObservableCollection<BaseTreeViewItem>() { null };
            this.m_WasBuilt = false;
        }

        public string Name { get; set; }
        public ObservableCollection<BaseTreeViewItem> Children { get; set; }

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

        public virtual void BuildMyself()
        {

        }

        public BaseTreeViewItem OriginalItem { get; set; }

        private bool m_WasBuilt;
        private bool m_IsExpanded;
    }
}
