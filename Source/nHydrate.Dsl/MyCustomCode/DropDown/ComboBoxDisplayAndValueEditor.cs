using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ListBox = System.Windows.Forms.ListBox;
using System.Web.UI.WebControls;

namespace nHydrate.Dsl.Editor
{
    //public class ComboBoxDisplayAndValueEditor : DropDownBase
    //{
    //    //public override void FillDropDown(ListBox dropdownlist, ITypeDescriptorContext context = null)
    //    //{
    //    //    if (context != null)
    //    //    {
    //    //        var fieldBase = context.Instance as ModelField;

    //    //        if (fieldBase != null && !string.IsNullOrEmpty(fieldBase.SourceName))
    //    //        {

    //    //            // Indentifica si el source proviene de un dll o del modelo
    //    //            if (fieldBase.SourceName.IndexOf(".", System.StringComparison.Ordinal) > -1)
    //    //            {
    //    //                // Load Reference Current Project
    //    //                var references = nHydrate.Generator.Common.Util.EnvDTEHelper.Instance.GetReferencesCurrentProject();
    //    //                foreach (var reference in references)
    //    //                {
    //    //                    var type = Assembly.LoadFile(reference.Value).GetExportedTypes().FirstOrDefault(x => x.FullName == fieldBase.SourceName);

    //    //                    if (type != null)
    //    //                    {
    //    //                        var properties = type.GetMembers().Where(x => x.MemberType == MemberTypes.Property);


    //    //                        foreach (var property in properties)
    //    //                        {
    //    //                            dropdownlist.Items.Add(new ListItem(property.Name,
    //    //                                               property.Name));    
    //    //                        }

                                
    //    //                        return;
    //    //                    }
    //    //                }
    //    //            }

    //    //            var callArray = fieldBase.SourceName.Split(Convert.ToChar("."));

    //    //            if (callArray.Length <= 1) return ;


    //    //            var modelName = callArray[0];
    //    //           // var methodName = callArray[1].Split(Convert.ToChar("(")).FirstOrDefault();


    //    //            var objModel = fieldBase.Model.nHydrateModel;

    //    //            foreach (var mvcConcept in objModel.MVCConcept)
    //    //            {
    //    //                var model = mvcConcept as Model;
    //    //                if (model != null && model.Name == modelName)
    //    //                {
    //    //                    foreach (var modelField in model.ModelFields)
    //    //                    {
    //    //                        dropdownlist.Items.Add(new ListItem(modelField.Name,
    //    //                                              modelField.Name));    
    //    //                    }
    //    //                    return;
    //    //                }
    //    //            }

    //    //            foreach (var entity in objModel.Entities)
    //    //            {

    //    //                var objEntity = entity as Entity;
    //    //                if (objEntity != null && objEntity.Name == modelName)
    //    //                {
    //    //                    foreach (var modelField in objEntity.Fields)
    //    //                    {
    //    //                        dropdownlist.Items.Add(new ListItem(modelField.Name,
    //    //                                              modelField.Name));
    //    //                    }
    //    //                    return;
    //    //                }

    //    //            }

    //    //            foreach (var procedure in objModel.StoredProcedures)
    //    //            {
    //    //                var objProcedure = procedure as StoredProcedure;
    //    //                if (objProcedure != null && objProcedure.Name == fieldBase.SourceName)
    //    //                {
    //    //                    foreach (var modelField in objProcedure.Fields)
    //    //                    {
    //    //                        dropdownlist.Items.Add(new ListItem(modelField.Name,
    //    //                                              modelField.Name));
    //    //                    }
    //    //                    return;
    //    //                }
    //    //            }

    //    //        }
    //    //    }
    //    //}
    //}
}
