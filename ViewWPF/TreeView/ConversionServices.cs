using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.GraphicalData.TreeView;
using TPA.Reflection.Model;

namespace ViewWPF.TreeView
{
    public class ConversionServices
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
            else
            {
                typeDictonary[typeMetadata.TypeName] = typeItem;
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

            //Adding methods
            if(typeMetadata.Methods != null)
            {
                foreach (var method in typeMetadata.Methods)
                {
                    typeItem.Children.Add(ConvertMethodMetadata(method));
                }
            }

            //Adding constructors
            if(typeMetadata.Constructors != null)
            {
                foreach (var constructor in typeMetadata.Constructors)
                {
                    typeItem.Children.Add(ConvertMethodMetadata(constructor));
                }
            }

            //Converting modifiers
            Tuple<AccessLevel, SealedEnum, AbstractEnum> tuple = typeMetadata.Modifiers;
            if(tuple!= null)
            {
                if (tuple.Item1 != null)
                {
                    TreeViewItem accessLevelItem = new TreeViewItem();
                    accessLevelItem.Name = "[access] " + tuple.Item1.ToString();
                    typeItem.Children.Add(accessLevelItem);
                }
                if (tuple.Item2 != null)
                {
                    TreeViewItem sealedItem = new TreeViewItem();
                    sealedItem.Name = "[sealed] " + tuple.Item2.ToString();
                    typeItem.Children.Add(sealedItem);
                }
                if (tuple.Item3 != null)
                {
                    TreeViewItem abstractItem = new TreeViewItem();
                    abstractItem.Name = "[abstract] " + tuple.Item3.ToString();
                    typeItem.Children.Add(abstractItem);
                }
            }




            return typeItem;
            
        }

        private static TreeViewItem ConvertMethodMetadata(MethodMetadata method)
        {
            TreeViewItem methodItem = new TreeViewItem();
            methodItem.Name = "[method]" + method.Name;
            methodItem.Children.Clear();

            //Return type
            if(method.ReturnType != null) //For constructors
            {
                if (typeDictonary.ContainsKey(method.ReturnType.TypeName))
                {
                    methodItem.Children.Add(typeDictonary[method.ReturnType.TypeName]);
                }
                else
                {
                    methodItem.Children.Add(ConvertTypeMetadata(method.ReturnType));
                }
            }


            //Parameters
            foreach (var parameter in method.Parameters)
            {
                methodItem.Children.Add(ConvertParameterMetadata(parameter));
            }


            return methodItem;

        }

        private static TreeViewItem ConvertParameterMetadata(ParameterMetadata parameterMetadata)
        {
            TreeViewItem parameterItem = new TreeViewItem();
            parameterItem.Name = "[parameter] " + parameterMetadata.Name;
            parameterItem.Children.Clear();

            if (typeDictonary.ContainsKey(parameterMetadata.TypeMetadata.TypeName))
            {
                parameterItem.Children.Add(typeDictonary[parameterMetadata.TypeMetadata.TypeName]);
            }
            else
            {
                parameterItem.Children.Add(ConvertTypeMetadata(parameterMetadata.TypeMetadata));
            }

            return parameterItem;
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
