using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Logic.Model
{
    public class MethodMetadata
    {
        public MethodMetadata() { }

        internal static IEnumerable<MethodMetadata> EmitMethods(IEnumerable<MethodBase> methods)
        {
            return from MethodBase _currentMethod in methods
                   where _currentMethod.IsPublic // was isVisible()
                   select new MethodMetadata(_currentMethod);
        }

        #region private
        //vars
        private string m_Name;
        private IEnumerable<TypeMetadata> m_GenericArguments;
        private Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> m_Modifiers;
        private TypeMetadata m_ReturnType;
        private bool m_Extension;
        private IEnumerable<ParameterMetadata> m_Parameters;

        public string Name { get => m_Name; set => m_Name = value; }
        public IEnumerable<TypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        public TypeMetadata ReturnType { get => m_ReturnType; set => m_ReturnType = value; }
        public bool Extension { get => m_Extension; set => m_Extension = value; }
        public IEnumerable<ParameterMetadata> Parameters { get => m_Parameters; set => m_Parameters = value; }

        //constructor

        private MethodMetadata(MethodBase method)
        {
            m_Name = method.Name;
            m_GenericArguments = !method.IsGenericMethodDefinition ? null : TypeMetadata.EmitGenericArguments(method.GetGenericArguments());
            m_ReturnType = EmitReturnType(method);
            m_Parameters = EmitParameters(method.GetParameters());
            m_Modifiers = EmitModifiers(method);
            m_Extension = EmitExtension(method);
        }
        //methods
        private static IEnumerable<ParameterMetadata> EmitParameters(IEnumerable<ParameterInfo> parms)
        {
            return from parm in parms
                   select new ParameterMetadata(parm.Name, TypeMetadata.EmitReference(parm.ParameterType));
        }
        private static TypeMetadata EmitReturnType(MethodBase method)
        {
            MethodInfo methodInfo = method as MethodInfo;
            if (methodInfo == null)
                return null;
            return TypeMetadata.EmitReference(methodInfo.ReturnType);
        }
        private static bool EmitExtension(MethodBase method)
        {
            return method.IsDefined(typeof(ExtensionAttribute), true);
        }
        private static Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> EmitModifiers(MethodBase method)
        {
            AccessLevel _access = AccessLevel.IsPrivate;
            if (method.IsPublic)
                _access = AccessLevel.IsPublic;
            else if (method.IsFamily)
                _access = AccessLevel.IsProtected;
            else if (method.IsFamilyAndAssembly)
                _access = AccessLevel.IsProtectedInternal;
            AbstractEnum _abstract = AbstractEnum.NotAbstract;
            if (method.IsAbstract)
                _abstract = AbstractEnum.Abstract;
            StaticEnum _static = StaticEnum.NotStatic;
            if (method.IsStatic)
                _static = StaticEnum.Static;
            VirtualEnum _virtual = VirtualEnum.NotVirtual;
            if (method.IsVirtual)
                _virtual = VirtualEnum.Virtual;
            return new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(_access, _abstract, _static, _virtual);
        }
        #endregion
    }
}