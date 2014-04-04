using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml;
using ListBox = System.Windows.Forms.ListBox;
using TreeNode = System.Windows.Forms.TreeNode;

namespace nHydrate.Dsl.Editor
{
    public class ParametersTwinEditor : DropDownBase
    {
        /*
         
         var parameters = context.Instance as MethodParameters;
            if (parameters != null)
            {
                var method1 = parameters.Parent as ModelMethod;
                if (method1 != null)
                {
                    return method1.Model.nHydrateModel;
                }

                var controllerMethod = parameters.Parent as ControllerMethod;
                if (controllerMethod != null)
                {
                    return controllerMethod.Controller.nHydrateModel;
                }
            }
         
         */

        //public override void FillDropDown(ListBox dropdownlist, ITypeDescriptorContext context = null)
        //{
        //    if (context == null) return;

        //    var methodParameters = context.Instance as MethodParameters;
        //    if (methodParameters == null) return;

        //    var modelMethod = methodParameters.Parent as ModelMethod;
        //    if (modelMethod == null) return;

           

        //    foreach (var parameter in modelMethod.ParametersIn)
        //    {

        //        var model =
        //            modelMethod.Model.nHydrateModel.MVCConcept.OfType<Model>().FirstOrDefault(
        //                x => x.Name == parameter.Name);
        //        if (model != null)
        //        {
        //            foreach (var modelField in model.ModelFields)
        //            {
        //                dropdownlist.Items.Add(new ListItem(parameter.Name + "." + modelField.Name,
        //                                                             parameter.Name + "." + modelField.Name));
        //            }
        //        }
        //        else
        //        {
        //            dropdownlist.Items.Add(new ListItem(parameter.Name,
        //                                                                  parameter.Name));
        //        }
                
        //    }


            

        //    // var i = default(int);

        //    //var model = controllerMethod.Controller.nHydrateModel.MVCConcept.OfType<Model>().FirstOrDefault(x => x.Name == modelName);

        //    //foreach (var field in model.ModelFields)
        //    //{
        //    //    if (field.IsRequired)
        //    //    {
        //    //       Console.WriteLine(string.Format("RuleFor(x => x.{0}).NotNull().WithMessage({1})", field.Name, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //    //if (field.IsUrlValidator)
        //    //    //{
        //    //    //WriteLine(string.Format("RuleFor(x => x.{0}).NotNull().WithMessage({1})",field.Name, "ERROR_CAMPO_REQUERIDO"));
        //    //    //}
        //    //    if (field.IsRegularExpressionValidator)
        //    //    {
        //    //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).Matches({1}).WithMessage({2})", field.Name, field.IsRegularExpressionValidatorValue, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //    if (field.IsNotEqual)
        //    //    {
        //    //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).NotEqual({1}).WithMessage({2})", field.Name,field.IsNotEqualName, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //    if (field.IsLessThanOrEqual)
        //    //    {
        //    //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).LessThanOrEqual({1}).WithMessage({2})", field.Name,field.IsLessThanOrEqualValue, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //    if (field.IsLessThan)
        //    //    {
        //    //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).LessThan({1}).WithMessage({2})", field.Name,field.IsLessThanValueField, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //    if (field.IsLength)
        //    //    {
        //    //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).Length(1,{1} ).WithMessage({2})", field.Name,field.IsLengthValue, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //    if (field.IsGreaterThanOrEqual)
        //    //    {
        //    //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).GreaterThanOrEqual({1}).WithMessage({2})", field.Name,field.IsGreaterThanOrEqualValue, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //    if (field.IsGreaterThan)
        //    //    {
        //    //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).GreaterThan({1}).WithMessage({2})", field.Name,field.IsGreaterThanValue, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //    if (field.IsEqual)
        //    //    {
        //    //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).Equal({1}).WithMessage({2})", field.Name,field.IsEqualName, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //    if (field.IsEmailValidator)
        //    //    {
        //    //        Console.WriteLine(string.Format("RuleFor(x => x.{0}).EmailAddress().WithMessage({1})", field.Name, "ERROR_CAMPO_REQUERIDO"));
        //    //    }
        //    //}

           

        //   // Model model;
        //   // model.ModelFields.FirstOrDefault(x => x.Name == )

        //   // var objView = controllerMethod as MVCView;
            
        //   // objView.CountColumnH
        //   //// var MvcView = controllerMethod.Controller.nHydrateModel.MVCConcept.FirstOrDefault(x => x.Name).OfType<MVCView>().FirstOrDefault(x => x.Name == "");
            
            
        //    //foreach (var model in methodParameters.Controller.nHydrateModel.MVCConcept.OfType<Model>())
        //    //{
        //    //    foreach (var modelMethod in model.ModelMethods)
        //    //    {
        //    //        var modelName = model.Name;
        //    //        modelName += "." + modelMethod.Name;

        //    //        var modelNameJson = modelName + "." + modelMethod.Name + "Json";

        //    //        var parameters = string.Empty;
        //    //        foreach (var parameter in modelMethod.ParametersIn)
        //    //        {
        //    //            if (!string.IsNullOrEmpty(parameters))
        //    //            {
        //    //                parameters += ",";
        //    //            }
        //    //            //parameters += parameter.TypeName + " " + parameter.Name;
        //    //            parameters += " " + parameter.Name;
        //    //        }

        //    //        modelName += string.Format("({0})", parameters);

        //    //        dropdownlist.Items.Add(new ListItem(modelName,
        //    //                                                            modelName));

        //    //        modelNameJson += string.Format("({0})", parameters);

        //    //        dropdownlist.Items.Add(new ListItem(modelNameJson,
        //    //                                                            modelNameJson));
        //    //    }
               
        //    //}
        //}
    }
}
