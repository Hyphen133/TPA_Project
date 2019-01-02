using DataTransferGraph.Model;
using Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Logic.DTGMapper
{
    public class TypeMapper
    {
        public static Dictionary<string, DTGTypeModel> DTGTypes = new Dictionary<string, DTGTypeModel>();
        public static Dictionary<string, TypeMetadata> Types = new Dictionary<string, TypeMetadata>();

        public static DTGTypeModel EmitXMLType(TypeMetadata model)
        {
            return new TypeMapper().MapToDTGModel(model);
        }

        public static TypeMetadata EmitType(DTGTypeModel model)
        {
            return new TypeMapper().MapFromDTGModel(model);
        }

        private void FillDTGType(TypeMetadata model, DTGTypeModel typModel)
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
            typModel.Methods = model.Methods?.Select(m => new MethodMapper().MapToDTGModel(m)).ToList();
            typModel.Constructors = model.Constructors?.Select(c => new MethodMapper().MapToDTGModel(c)).ToList();
            typModel.Properties = model.Properties?.Select(c => new PropertyMapper().MapToDTGModel(c)).ToList();
        }

        private void FillType(DTGTypeModel model, TypeMetadata typeModel)
        {
            typeModel.TypeName = model.Name;
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

            //typeModel.Parameters = model.Fields?.Select(g => new ParameterMapper().MapFromDTGModel((DTGParameterModel)g)).ToList();
            typeModel.Methods = model.Methods?.Select(c => new MethodMapper().MapFromDTGModel(c)).ToList();
            typeModel.Constructors = model.Constructors?.Select(c => new MethodMapper().MapFromDTGModel(c)).ToList();
            typeModel.Properties = model.Properties?.Select(g => new PropertyMapper().MapFromDTGModel(g)).ToList();
        }


        #region IModelMapper

        public TypeMetadata MapFromDTGModel(DTGTypeModel model)
        {
            TypeMetadata typeMetadata = new TypeMetadata();
            //if (model == null)
                //return null;

            if (!Types.ContainsKey(model.Name))
            {
                Types.Add(model.Name, typeMetadata);
                FillType(model, typeMetadata);
            }
            return Types[model.Name];

        }

        public DTGTypeModel MapToDTGModel(TypeMetadata model)
        {
            DTGTypeModel typeModel = new DTGTypeModel();
            //if (model == null)
                //return null;
            if (!DTGTypes.ContainsKey(model.TypeName))
            {
                DTGTypes.Add(model.TypeName, typeModel);
                FillDTGType(model, typeModel);
            }
            return DTGTypes[model.TypeName];
        }

        #endregion
    }
}
