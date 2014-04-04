using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using nHydrate.Dsl.MyCustomCode;

namespace nHydrate.Dsl.MyCustomCode
{
    [Serializable]
    [TypeConverter(typeof(Editor.CollectionTypeConverter))]
    public class MethodParameters
    {

        private string _name;

        [Category("Definition")]
        [Description("Nombre del parametro")]
        [DisplayName]
        [ElementName]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private string _internalName;

        [Category("Definition")]
        [Description("Segundo Nombre del parametro")]
        [DisplayName]
        [ElementName]
        public string InternalName
        {
            get { return string.IsNullOrEmpty(_internalName) ? _name : _internalName; }
            set { _internalName = value; }
        }


        private string _typeName;

        [Category("Definition")]
        [Description("Tipo de Dato")]
        [Editor(typeof(Editor.TypeNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        private string _defaultValue;

        [Category("Definition")]
        [Description("Valor predeterminado, si no se asigna ninguno")]
        [Editor(typeof(Editor.ParameterDefaultValueEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }


        private bool _isTypeModel;

        [Category("Definition")]
        [Description("Indica si el tipo de dato es un model")]
        public bool IsTypeModel
        {
            get { return _isTypeModel; }
            set { _isTypeModel = value; }
        }

        private bool _isNullable;

        [Category("Definition")]
        [Description("Indica si el parametro aceptar ser nulo.")]
        public bool IsNullable
        {
            get { return _isNullable; }
            set { _isNullable = value; }
        }

        [NonSerialized]
        public ModelElement Parent;


        //private string _parametertwin;

        //[Category("Definition")]
        //[Description("Propiedad Indica a cual parametro de entrada va a tomar los datos, solo se usa en lo parametros de salida")]
        //[Editor(typeof(Editor.ParametersTwinEditor), typeof(System.Drawing.Design.UITypeEditor))]
        //public string ParameterTwin
        //{
        //    get { return _parametertwin; }
        //    set { _parametertwin = value; }
        //}

        //private bool _isFromModel;

        //[Category("Definition")]
        //[Description("Indica si el tipo de dato es desde un model")]
        //public bool IsFromModel
        //{
        //    get { return _isFromModel; }
        //    set { _isFromModel = value; }
        //}


        //private bool _isInParameter;

        //[Category("Definition")]
        //[Description("Indica si el Parameter es de entrada en el metodo")]
        //public bool IsInParameter
        //{
        //    get { return _isInParameter; }
        //    set { _isInParameter = value; }
        //}


        //private string _fillComboxPropertyDepend;

        //[Category("FC_ComboxBox")]
        //[Description("Indica las propiedades de la cual depende para llenar el Combox")]
        //[System.ComponentModel.Editor(typeof(nHydrate.Dsl.Editor.FillComboxDependPropertyEditor), typeof(System.Drawing.Design.UITypeEditor))]
        //public string FillComboxPropertyDepend
        //{
        //    get { return _fillComboxPropertyDepend; }
        //    set { _fillComboxPropertyDepend = value; }
        //}

    }
}



namespace nHydrate.Dsl.Editor
{

    public class MethodParametersEditor : System.ComponentModel.Design.CollectionEditor
    {
        public MethodParametersEditor(Type t)
            : base(t)
        {
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider,
                                         object value)
        {
            if (value as List<MethodParameters> != null)
            {
                var list = value as List<MethodParameters>;


                var modelMethod = context.Instance as Methods;
                if (modelMethod != null)
                {
                    foreach (var parameter in list)
                    {
                        parameter.Parent = modelMethod;
                    }
                }

                //var modelField = context.Instance as ModelField;
                //if (modelField != null)
                //{
                //    foreach (var parameter in list)
                //    {
                //        parameter.Parent = modelField;
                //    }
                //}

                //var controllerMethod = context.Instance as ControllerMethod;
                //if (controllerMethod != null)
                //{
                //    foreach (var parameter in list)
                //    {
                //        parameter.Parent = controllerMethod;
                //    }
                //}

                //var methodParameters = context.Instance as MethodParameters;
                //if (methodParameters != null)
                //{
                //    foreach (var parameter in list)
                //    {
                //        parameter.Parent = methodParameters;
                //    }
                //}



            }

            return base.EditValue(context, provider, value);
        }




        protected override object CreateInstance(Type itemType)
        {

            var methodParamertes = new MethodParameters();

            var method1 = Context.Instance as Methods;
            if (method1 != null)
            {
                methodParamertes.Parent = method1;
            }

            //var controllerMethod = Context.Instance as ControllerMethod;
            //if (controllerMethod != null)
            //{
            //    methodParamertes.Parent = controllerMethod;
            //}

            return methodParamertes;
            //return base.CreateInstance(itemType);
        }
    }
}