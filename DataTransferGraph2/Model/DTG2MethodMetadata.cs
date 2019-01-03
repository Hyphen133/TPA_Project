using Logic.Model;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DataTransferGraph2.Model
{
    public class DTG2MethodMetadata
    {
        public DTG2MethodMetadata() { }

        internal static IEnumerable<DTG2MethodMetadata> EmitMethods(IEnumerable<MethodMetadata> methods)
        {
            return from MethodMetadata _currentMethod in methods
                   select new DTG2MethodMetadata(_currentMethod);
        }

        #region private
        //vars
        private string m_Name;
        private IEnumerable<DTG2TypeMetadata> m_GenericArguments;
        private DTG2TypeMetadata m_ReturnType;
        private bool m_Extension;
        private IEnumerable<DTG2ParameterMetadata> m_Parameters;

        public string Name { get => m_Name; set => m_Name = value; }
        public IEnumerable<DTG2TypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public DTG2TypeMetadata ReturnType { get => m_ReturnType; set => m_ReturnType = value; }
        //public bool Extension { get => m_Extension; set => m_Extension = value; }
        public IEnumerable<DTG2ParameterMetadata> Parameters { get => m_Parameters; set => m_Parameters = value; }

        //constructor

        private DTG2MethodMetadata(MethodMetadata method)
        {
            m_Name = method.Name;
            m_GenericArguments = DTG2TypeMetadata.EmitGenericArguments(method.GenericArguments);
            m_ReturnType = EmitReturnType(method);
            m_Parameters = EmitParameters(method.Parameters);
            //m_Extension = EmitExtension(method);
        }
        //methods
        private static IEnumerable<DTG2ParameterMetadata> EmitParameters(IEnumerable<ParameterMetadata> parms)
        {
            return from parm in parms
                   select new DTG2ParameterMetadata(parm.Name, DTG2TypeMetadata.EmitReference(parm.TypeMetadata));
        }
        private static DTG2TypeMetadata EmitReturnType(MethodMetadata method)
        {
            MethodMetadata methodInfo = method as MethodMetadata;
            if (methodInfo == null)
                return null;
            return DTG2TypeMetadata.EmitReference(methodInfo.ReturnType);
        }
        /*private static bool EmitExtension(MethodMetadata method)
        {
            return method.IsDefined(typeof(ExtensionAttribute), true);
        }*/
        #endregion
    }
}