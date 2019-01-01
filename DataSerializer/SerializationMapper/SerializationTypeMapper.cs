using DataSerializer.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationTypeMapper
    {
        public static Dictionary<string, DTGTypeModel> XMLTypes = new Dictionary<string, DTGTypeModel>();
        public static Dictionary<string, XMLTypeModel> Types = new Dictionary<string, XMLTypeModel>();

        public static DTGTypeModel EmitXMLType(XMLTypeModel model)
        {
            return new SerializationTypeMapper().MapToLower(model);
        }

        public static XMLTypeModel EmitType(DTGTypeModel model)
        {
            return new SerializationTypeMapper().MapToUpper(model);
        }

        private void FillXMLType(XMLTypeModel model, DTGTypeModel typModel)
        {
            typModel.Name = model.Name;
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
            typModel.Methods = model.Methods?.Select(m => new SerializationMethodMapper().MapToLower(m)).ToList();
            typModel.Constructors = model.Constructors?.Select(c => new SerializationMethodMapper().MapToLower(c)).ToList();
            typModel.Properties = model.Properties?.Select(c => new SerializationPropertyMapper().MapToLower(c)).ToList();
        }

        private void FillType(DTGTypeModel model, XMLTypeModel typeModel)
        {
            typeModel.Name = model.Name;
            //typeModel.IsExternal = model.IsExternal;
            //typeModel.IsGeneric = model.IsGeneric;
            //typeModel.Type = model.Type;
            //typeModel.Name = model.AssemblyName;
            //typeModel.Modifiers = model.Modifiers ?? new TypeModifiers();

            typeModel.BaseType = EmitType(model.BaseType);
            typeModel.DeclaringType = EmitType(model.DeclaringType);

            typeModel.NestedTypes = model.NestedTypes?.Select(n => EmitType(n)).ToList();
            typeModel.GenericArguments = model.GenericArguments?.Select(g => EmitType(g)).ToList();
            typeModel.ImplementedInterfaces = model.ImplementedInterfaces?.Select(i => EmitType(i)).ToList();

            //typeModel.Parameters = model.Fields?.Select(g => new ParameterMapper().MapToUpper((SerializableParameterModel)g)).ToList();
            typeModel.Methods = model.Methods?.Select(c => new SerializationMethodMapper().MapToUpper(c)).ToList();
            typeModel.Constructors = model.Constructors?.Select(c => new SerializationMethodMapper().MapToUpper(c)).ToList();
            typeModel.Properties = model.Properties?.Select(g => new SerializationPropertyMapper().MapToUpper(g)).ToList();
        }


        #region IModelMapper

        public XMLTypeModel MapToUpper(DTGTypeModel model)
        {
            XMLTypeModel typeMetadata = new XMLTypeModel();
            if (model == null)
                return null;

            if (!Types.ContainsKey(model.Name))
            {
                Types.Add(model.Name, typeMetadata);
                FillType(model, typeMetadata);
            }
            return Types[model.Name];

        }

        public DTGTypeModel MapToLower(XMLTypeModel model)
        {
            DTGTypeModel typeModel = new DTGTypeModel();
            if (model == null)
                return null;
            if (!XMLTypes.ContainsKey(model.Name))
            {
                XMLTypes.Add(model.Name, typeModel);
                FillXMLType(model, typeModel);
            }
            return XMLTypes[model.Name];
        }

        #endregion
    }
}
