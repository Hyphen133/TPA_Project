using DataSerializer.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationTypeMapper
    {
        public static Dictionary<string, DTGTypeModel> DTGTypes = new Dictionary<string, DTGTypeModel>();
        public static Dictionary<string, XMLTypeModel> XMLTypes = new Dictionary<string, XMLTypeModel>();

        public static DTGTypeModel EmitXMLType(XMLTypeModel model)
        {
            return new SerializationTypeMapper().MapToLower(model);
        }

        public static XMLTypeModel EmitType(DTGTypeModel model)
        {
            return new SerializationTypeMapper().MapToUpper(model);
        }

        private void FillDTGType(XMLTypeModel xmlModel, DTGTypeModel dtgModel)
        {
            dtgModel.Name = xmlModel.Name;
            dtgModel.IsExternal = xmlModel.IsExternal;
            dtgModel.IsGeneric = xmlModel.IsGeneric;
            //typModel.Type = model.Type;
            dtgModel.AssemblyName = xmlModel.Name;
            //new Tuple4<AccessLevel, SealedEnum, AbstractEnum, StaticEnum>
            //typModel.Modifiers = model.Modifiers ?? new TypeModifiers();

            dtgModel.BaseType = EmitXMLType(xmlModel.BaseType);
            dtgModel.DeclaringType = EmitXMLType(xmlModel.DeclaringType);

            dtgModel.NestedTypes = xmlModel.NestedTypes?.Select(c => EmitXMLType(c)).ToList();
            dtgModel.GenericArguments = xmlModel.GenericArguments?.Select(c => EmitXMLType(c)).ToList();
            dtgModel.ImplementedInterfaces = xmlModel.ImplementedInterfaces?.Select(c => EmitXMLType(c)).ToList();

            dtgModel.Fields = xmlModel.Fields?.Select(c => new SerializationParameterMapper().MapToLower(c)).ToList();
            dtgModel.Methods = xmlModel.Methods?.Select(m => new SerializationMethodMapper().MapToLower(m)).ToList();
            dtgModel.Constructors = xmlModel.Constructors?.Select(c => new SerializationMethodMapper().MapToLower(c)).ToList();
            dtgModel.Properties = xmlModel.Properties?.Select(c => new SerializationPropertyMapper().MapToLower(c)).ToList();
        }

        private void FillXMLType(DTGTypeModel dtgModel, XMLTypeModel xmlModel)
        {
            if(dtgModel.Name == "ServiceB" || dtgModel.Name == "ServiceA" || dtgModel.Name == "ServiceC")
            {
                string g = null;
            }
            xmlModel.Name = dtgModel.Name;
            xmlModel.IsExternal = dtgModel.IsExternal;
            xmlModel.IsGeneric = dtgModel.IsGeneric;
            //typeModel.Type = model.Type;
            xmlModel.Name = dtgModel.AssemblyName;
            //typeModel.Modifiers = model.Modifiers ?? new TypeModifiers();

            xmlModel.BaseType = EmitType(dtgModel.BaseType);
            xmlModel.DeclaringType = EmitType(dtgModel.DeclaringType);

            xmlModel.NestedTypes = dtgModel.NestedTypes?.Select(n => EmitType(n)).ToList();
            xmlModel.GenericArguments = dtgModel.GenericArguments?.Select(g => EmitType(g)).ToList();
            xmlModel.ImplementedInterfaces = dtgModel.ImplementedInterfaces?.Select(i => EmitType(i)).ToList();

            xmlModel.Fields = dtgModel.Fields?.Select(g => new SerializationParameterMapper().MapToUpper(g)).ToList();
            xmlModel.Methods = dtgModel.Methods?.Select(c => new SerializationMethodMapper().MapToUpper(c)).ToList();
            xmlModel.Constructors = dtgModel.Constructors?.Select(c => new SerializationMethodMapper().MapToUpper(c)).ToList();
            xmlModel.Properties = dtgModel.Properties?.Select(g => new SerializationPropertyMapper().MapToUpper(g)).ToList();
        }

        public XMLTypeModel MapToUpper(DTGTypeModel model)
        {
            XMLTypeModel typeMetadata = new XMLTypeModel();
            if (model == null)
                return null;

            if (!XMLTypes.ContainsKey(model.Name))
            {
                XMLTypes.Add(model.Name, typeMetadata);
                FillXMLType(model, typeMetadata);
            }
            return XMLTypes[model.Name];
        }

        public DTGTypeModel MapToLower(XMLTypeModel model)
        {
            DTGTypeModel typeModel = new DTGTypeModel();
            if (model == null)
                return null;
            if (!DTGTypes.ContainsKey(model.Name))
            {
                DTGTypes.Add(model.Name, typeModel);
                FillDTGType(model, typeModel);
            }
            return DTGTypes[model.Name];
        }
    }
}
