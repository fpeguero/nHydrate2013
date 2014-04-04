using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml;
using ListBox = System.Windows.Forms.ListBox;
using TreeNode = System.Windows.Forms.TreeNode;

namespace nHydrate.Dsl.Editor
{
    public class ActionMethodCallEditor : DropDownBase
    {

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var valuereturn =  base.EditValue(context, provider, value);


            var controllerMethod = context.Instance as ControllerMethod;
            if (controllerMethod == null) return valuereturn;

            //Pensionados.Consulta( Ciudadano_NSS, PageIndex, PageSize, Pensionado_Documento_NO, Pensionado_Nombre, Pensionado_Numero, Pensionado_Telefono, Usuario_IP, UsuarioCuenta)
            if (!string.IsNullOrEmpty(valuereturn.ToString()))
            {
                var callArray = valuereturn.ToString().Split(Convert.ToChar("."));

                if (callArray.Length <= 1) return valuereturn;

                // new ConsultaAfiliadosPlanesAlternativosModel()
                var modelName = callArray[0].Replace(" new ","").Replace("()","");

                var methodName = callArray[1].Split(Convert.ToChar("(")).FirstOrDefault();


             


                var firstOrDefault = controllerMethod.Controller.nHydrateModel.MVCConcept.OfType<Model>().FirstOrDefault(x => x.Name == modelName);
                if (firstOrDefault != null)
                {
                    var modelMethod =
                        firstOrDefault.ModelMethods.FirstOrDefault(x => x.Name == methodName);

                    if (modelMethod != null)
                    {
                        foreach (var parameter in modelMethod.ParametersIn)
                        {
                            controllerMethod.Parameters.Add( new MethodParameters()
                                                                 {
                                                                     Name = parameter.Name,
                                                                     TypeName = parameter.TypeName
                                                                 });
                        }
                    }
                }
            }


            return valuereturn;
        }
        

        public override void FillDropDown(ListBox dropdownlist, ITypeDescriptorContext context = null)
        {
            if (context == null) return;

            var controllerMethod = context.Instance as ControllerMethod;
            if (controllerMethod == null) return;


          

           // var i = default(int);

            //var model = controllerMethod.Controller.nHydrateModel.MVCConcept.OfType<Model>().FirstOrDefault(x => x.Name == modelName);

            //foreach (var field in model.ModelFields)
            //{
            //    if (field.IsRequired)
            //    {
            //       Console.WriteLine(string.Format("RuleFor(x => x.{0}).NotNull().WithMessage({1})", field.Name, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //    //if (field.IsUrlValidator)
            //    //{
            //    //WriteLine(string.Format("RuleFor(x => x.{0}).NotNull().WithMessage({1})",field.Name, "ERROR_CAMPO_REQUERIDO"));
            //    //}
            //    if (field.IsRegularExpressionValidator)
            //    {
            //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).Matches({1}).WithMessage({2})", field.Name, field.IsRegularExpressionValidatorValue, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //    if (field.IsNotEqual)
            //    {
            //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).NotEqual({1}).WithMessage({2})", field.Name,field.IsNotEqualName, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //    if (field.IsLessThanOrEqual)
            //    {
            //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).LessThanOrEqual({1}).WithMessage({2})", field.Name,field.IsLessThanOrEqualValue, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //    if (field.IsLessThan)
            //    {
            //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).LessThan({1}).WithMessage({2})", field.Name,field.IsLessThanValueField, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //    if (field.IsLength)
            //    {
            //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).Length(1,{1} ).WithMessage({2})", field.Name,field.IsLengthValue, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //    if (field.IsGreaterThanOrEqual)
            //    {
            //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).GreaterThanOrEqual({1}).WithMessage({2})", field.Name,field.IsGreaterThanOrEqualValue, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //    if (field.IsGreaterThan)
            //    {
            //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).GreaterThan({1}).WithMessage({2})", field.Name,field.IsGreaterThanValue, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //    if (field.IsEqual)
            //    {
            //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).Equal({1}).WithMessage({2})", field.Name,field.IsEqualName, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //    if (field.IsEmailValidator)
            //    {
            //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).EmailAddress().WithMessage({1})", field.Name, "ERROR_CAMPO_REQUERIDO"));
            //    }
            //}

           

           // Model model;
           // model.ModelFields.FirstOrDefault(x => x.Name == )

           // var objView = controllerMethod as MVCView;
            
           // objView.CountColumnH
           //// var MvcView = controllerMethod.Controller.nHydrateModel.MVCConcept.FirstOrDefault(x => x.Name).OfType<MVCView>().FirstOrDefault(x => x.Name == "");
           /// 
            //Model model2 = controllerMethod.Controller.nHydrateModel.MVCConcept.OfType<Model>().FirstOrDefault();

            //model2.ModelFields.FirstOrDefault(x => x.IsComboBox);

            //foreach (var field in model2.ModelFields.Where(x => x.IsComboBox))
            //{
            //    field.SourceName
            //}

            //GetMethodCallDbParameterVariable(controllerMethod);
            
            foreach (var model in controllerMethod.Controller.nHydrateModel.MVCConcept.OfType<Model>())
            {
                foreach (var modelMethod in model.ModelMethods)
                {
                    var modelName = " new " + model.Name;
                    modelName += "()." + modelMethod.Name;

                    var modelNameJson = " new " + model.Name + "()." + modelMethod.Name + "Json";

                    var parameters = string.Empty;
                    foreach (var parameter in modelMethod.ParametersIn)
                    {
                        if (!string.IsNullOrEmpty(parameters))
                        {
                            parameters += ",";
                        }
                        //parameters += parameter.TypeName + " " + parameter.Name;
                        parameters += " " + parameter.Name;
                    }

                    modelName += string.Format("({0})", parameters);

                    dropdownlist.Items.Add(new ListItem(modelName,
                                                                        modelName));

                    modelNameJson += string.Format("({0})", parameters);

                    dropdownlist.Items.Add(new ListItem(modelNameJson,
                                                                        modelNameJson));
                }
               
            }
        }


        //public string GetMethodCallDbParameterVariable(ControllerMethod method)
        //{
        //    var strParameter = string.Empty;

        //    if (method.AddPageIndex)
        //    {
        //        strParameter += "int PageIndex = default(int);" + "\n";
        //    }

        //    if (method.AddPageSize)
        //    {
        //        strParameter += "int PageSize = default(int);" + "\n";
        //    }

        //    foreach (var parameter in method.Parameters)
        //    {
        //        if (parameter.IsTypeModel)
        //        { continue; }


        //        if (!string.IsNullOrEmpty(strParameter))
        //        {
        //            strParameter += "\n";
        //        }

        //        if (parameter.IsFromModel)
        //        {
        //            strParameter += "var " + " " + parameter.Name + string.Format(" = {0}.{1}/*{1}*/;", parameter.ParameterTwin, parameter.Name);
        //        }
        //        else
        //        {
        //            //var declareVar = 
        //            //strParameter += "var " + " "  +parameter.Name + string.Format(" = default({0}/*{1}*/);",parameter.TypeName,parameter.Name );
        //            strParameter += " " + parameter.Name + (string.IsNullOrEmpty(parameter.DefaultValue) ?
        //                                            (parameter.IsNullable ? string.Format(" = {0}.HasValue ? {0}.Value : {1}     /*{2}*/;",
        //                                                                                        parameter.TypeName,
        //                                                                                                (string.IsNullOrEmpty(parameter.DefaultValue) ?
        //                                                                                                            string.Format(" = default({0});", parameter.TypeName) :
        //                                                                                                            parameter.DefaultValue), parameter.Name)
        //                                                                    : string.Format(" = default({0}/*{1}*/);", parameter.TypeName, parameter.Name)) :
        //                                                string.Format(" = {0};     /*{1}*/", parameter.DefaultValue, parameter.Name)).ToString(CultureInfo.InvariantCulture);
        //        }


        //    }
        //    return strParameter;
        //}




    }
}
