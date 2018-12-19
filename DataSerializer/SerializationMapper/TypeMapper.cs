using Data.SerializationModel;
using Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class TypeMapper
    {
        public static Dictionary<string, SerializableTypeModel> XMLTypes = new Dictionary<string, SerializableTypeModel>();
        public static Dictionary<string, TypeMetadata> Types = new Dictionary<string, TypeMetadata>();

        public static SerializableTypeModel EmitXMLType(TypeMetadata model)
        {
            return new TypeMapper().MapToLower(model);
        }

        public static TypeMetadata EmitType(SerializableTypeModel model)
        {
            return new TypeMapper().MapToUpper(model);
        }

        private void FillXMLType(TypeMetadata model, SerializableTypeModel typModel)
        {
            typModel.Name = model.TypeName;
            //typModel.IsExternal = model.IsExternal;
            //typModel.IsGeneric = model.IsGeneric;
            //typModel.Type = model.Type;
            //typModel.AssemblyName = model.Name;
            //new Tuple4<AccessLevel, SealedEnum, AbstractEnum, StaticEnum>
            //typModel.Modifiers = model.Modifiers ?? new TypeModifiers();

            typModel.BaseType = EmitXMLType(model.BaseType);
            typModel.DeclaringType = EmitXMLType(model.DeclaringType);

            typModel.NestedTypes = model.NestedTypes?.Select(c => EmitXMLType(c)).ToList();
            typModel.GenericArguments = model.GenericArguments?.Select(c => EmitXMLType(c)).ToList();
            typModel.ImplementedInterfaces = model.ImplementedInterfaces?.Select(c => EmitXMLType(c)).ToList();

            //typModel.Fields = model.Fields?.Select(c => new ParameterMapper().MapToLower(c)).ToList();
            typModel.Methods = model.Methods?.Select(m => new MethodMapper().MapToLower(m)).ToList();
            typModel.Constructors = model.Constructors?.Select(c => new MethodMapper().MapToLower(c)).ToList();
            typModel.Properties = model.Properties?.Select(c => new PropertyMapper().MapToLower(c)).ToList();
        }

        private void FillType(SerializableTypeModel model, TypeMetadata typeModel)
        {
            typeModel.TypeName = model.Name;
            //typeModel.IsExternal = model.IsExternal;
            //typeModel.IsGeneric = model.IsGeneric;
            //typeModel.Type = model.Type;
            //typeModel.Name = model.AssemblyName;
            //typeModel.Modifiers = model.Modifiers ?? new TypeModifiers();

            typeModel.BaseType = EmitType((SerializableTypeModel)model.BaseType);
            typeModel.DeclaringType = EmitType((SerializableTypeModel)model.DeclaringType);

            typeModel.NestedTypes = model.NestedTypes?.Select(n => EmitType((SerializableTypeModel)n)).ToList();
            typeModel.GenericArguments = model.GenericArguments?.Select(g => EmitType((SerializableTypeModel)g)).ToList();
            typeModel.ImplementedInterfaces = model.ImplementedInterfaces?.Select(i => EmitType((SerializableTypeModel)i)).ToList();

            //typeModel.Parameters = model.Fields?.Select(g => new ParameterMapper().MapToUpper((SerializableParameterModel)g)).ToList();
            typeModel.Methods = model.Methods?.Select(c => new MethodMapper().MapToUpper((SerializableMethodModel)c)).ToList();
            typeModel.Constructors = model.Constructors?.Select(c => new MethodMapper().MapToUpper((SerializableMethodModel)c)).ToList();
            typeModel.Properties = model.Properties?.Select(g => new PropertyMapper().MapToUpper((SerializablePropertyModel)g)).ToList();
        }


        #region IModelMapper

        public TypeMetadata MapToUpper(SerializableTypeModel model)
        {
            TypeMetadata typeMetadata = new TypeMetadata();
            if (model == null)
                return null;

            if (!Types.ContainsKey(model.Name))
            {
                Types.Add(model.Name, typeMetadata);
                FillType(model, typeMetadata);
            }
            return Types[model.Name];

        }

        public SerializableTypeModel MapToLower(TypeMetadata model)
        {
            SerializableTypeModel typeModel = new SerializableTypeModel();
            if (model == null)
                return null;
            if (!XMLTypes.ContainsKey(model.TypeName))
            {
                XMLTypes.Add(model.TypeName, typeModel);
                FillXMLType(model, typeModel);
            }
            return XMLTypes[model.TypeName];
        }

        #endregion
    }
}
