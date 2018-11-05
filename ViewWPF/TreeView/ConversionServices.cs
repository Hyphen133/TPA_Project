using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.GraphicalData.TreeView;
using TPA.Reflection.Model;

namespace ViewWPF.TreeView
{
    class ConversionServices
    {
        private static Dictionary<string, TreeViewItem> typeDictonary = new Dictionary<string, TreeViewItem>();

        public static TreeViewItem ConvertAssemblyMetadata(AssemblyMetadata assembyMetadata)
        {
            //Reset 
            typeDictonary.Clear();

            TreeViewItem root = new TreeViewItem();
            root.Name = "[assembly] " + assembyMetadata.Name;
            root.Children.Clear();

            foreach (var ns in assembyMetadata.Namespaces)
            {
                root.Children.Add(ConvertNamespaceMetadata(ns));
            }

            return root;
        }

        public static TreeViewItem ConvertNamespaceMetadata(NamespaceMetadata namespaceMetadata)
        {
            TreeViewItem namespaceItem = new TreeViewItem();
            namespaceItem.Name = "[namespace] " + namespaceMetadata.NamespaceName;
            namespaceItem.Children.Clear();

            foreach (var type in namespaceMetadata.Types)
            {
                typeDictonary[type.TypeName] = new TreeViewItem();
            }

            foreach (var type in namespaceMetadata.Types)
            {
                namespaceItem.Children.Add(ConvertTypeMetadata(type));
            }

            return namespaceItem;
        }

        public static TreeViewItem ConvertTypeMetadata(TypeMetadata typeMetadata)
        {

            TreeViewItem typeItem = new TreeViewItem();

            if (typeDictonary.ContainsKey(typeMetadata.TypeName))
            {
                typeItem = typeDictonary[typeMetadata.TypeName];
            }
            
            //Adding properties
            typeItem.Name = "[type] " + typeMetadata.TypeName;
            typeItem.Children.Clear();    //removing null

            if (typeMetadata.Properties != null) //Alternativly initalize in constructor
            {
                foreach (var property in typeMetadata.Properties)
                {
                    
                        typeItem.Children.Add(ConvertPropertyMetadata(property));
                    
                    
                }
            }


            //TODO -> Add more properties

            return typeItem;

            

        }

        public static TreeViewItem ConvertPropertyMetadata(PropertyMetadata propertyMetadata)
        {
            TreeViewItem propertyItem = new TreeViewItem();
            propertyItem.Name = "[property] " + propertyMetadata.Name;
            propertyItem.Children.Clear();


            if (typeDictonary.ContainsKey(propertyMetadata.TypeMetadata.TypeName))
            {
                propertyItem.Children.Add(typeDictonary[propertyMetadata.TypeMetadata.TypeName]);
            }
            else
            {
                propertyItem.Children.Add(ConvertTypeMetadata(propertyMetadata.TypeMetadata));
            }
            
            
            


            return propertyItem;
        }

    }
}
