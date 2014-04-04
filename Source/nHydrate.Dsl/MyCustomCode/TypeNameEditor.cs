using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using CodeFluent.Runtime.Diagnostics;
using nHydrate.Dsl.MyCustomCode;


namespace nHydrate.Dsl.Editor
{
    public class TypeNameEditor : UITypeEditor
    {
        private IWindowsFormsEditorService edService;
        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public static T GetObject<T>(ITypeDescriptorContext context)
        {
           
            if (context == null || context.Instance == null)
            {
                return default(T);
            }
           
            if (typeof(T).IsAssignableFrom(context.Instance.GetType()))
            {
                return (T)((object)context.Instance);
            }
            return default(T);
        }
        protected virtual TypeNameControl CreateControl(nHydrateModel project, ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
           
            return new TypeNameControl(project, (context != null) ? context.Instance : null);
        }


        public static nHydrateModel GetProject(ITypeDescriptorContext context)
        {
            if (context == null)
            {
                return null;
            }

            var method = context.Instance as Methods;
            if (method != null)
            {
                return method.Entity.nHydrateModel;
            }

            //var field = context.Instance as ModelField;
            //if (field != null)
            //{
            //    return field.Model.nHydrateModel;
            //}

            var parameters = context.Instance as MethodParameters;
            if (parameters != null)
            {
                var method1 = parameters.Parent as Methods;
                if (method1 != null)
                {
                    return method1.Entity.nHydrateModel;
                }

                //var controllerMethod = parameters.Parent as ControllerMethod;
                //if (controllerMethod != null)
                //{
                //    return controllerMethod.Controller.nHydrateModel;
                //}
            }


            //var viewShape = context.Instance as UIViewShape;
            //if (viewShape != null)
            //{
            //    var view = viewShape.ModelElement as MVCView;
            //    if (view != null) return view.nHydrateModel;
            //}

            ////

            //var controllerMethod1 = context.Instance as ControllerMethod;
            //if (controllerMethod1 != null)
            //{
            //    return controllerMethod1.Controller.nHydrateModel;
            //}


            return null;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {

           

            this.edService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (this.edService == null)
            {
                return base.EditValue(context, provider, value);
            }

            object result;
            try
            {
                nHydrateModel project = GetProject(context);
               
                TypeNameControl typeNameControl = this.CreateControl(project,  context, provider, value);
                
                    if (value != null)
                    {
                        typeNameControl.TypeName = value.ToString();
                    }

                typeNameControl.SelectTypeName();
                typeNameControl.TypeChanged += new EventHandler<EventArgs>(this.OnDropDownClosed);
                this.edService.DropDownControl(typeNameControl);

         
                {
                    //if (context.PropertyDescriptor.PropertyType == typeof(Entity) && project != null)
                    //{
                    //    if (typeNameControl.TypeName == null)
                    //    {
                    //        result = null;
                    //    }
                    //    else
                    //    {
                    //        result = project.Entities[typeNameControl.TypeName];
                    //    }
                    //}
                    //else
                    {
                        //Property @object = TypeNameEditor.GetObject<Property>(context);
                        //if (@object != null && project != null && typeNameControl.TypeName != null)
                        //{
                        //    Entity entity2 = project.Types[typeNameControl.TypeName] as Entity;
                        //    if (entity2 == null)
                        //    {
                        //        Set set = project.Types[typeNameControl.TypeName] as Set;
                        //        if (set != null)
                        //        {
                        //            entity2 = set.ItemEntity;
                        //        }
                        //    }
                        //    if (entity2 != null && !entity2.IsLightWeight && !@object.Entity.IsLightWeight)
                        //    {
                        //        NewRelation dialog = new NewRelation(entity2, @object, null, true);
                        //        if (this.uovloUOii.ShowDialog(dialog) == DialogResult.Cancel)
                        //        {
                        //            result = base.EditValue(context, provider, value);
                        //            return result;
                        //        }
                        //    }
                        //}
                        result = typeNameControl.TypeName;

                        //Agregar Los parametros cuando se selecciona un Metodo.
                        //Methods method = context.Instance as Methods;
                        //if (result != null && method != null)
                        //{
                        //    if (result.ToString().IndexOf("(", System.StringComparison.Ordinal) > -1)
                        //    {
                        //        var methodName = result.ToString().Replace("()", "  ");

                        //        var indexStart = methodName.IndexOf("(", System.StringComparison.Ordinal) + 1;
                        //        var indexEnd = methodName.IndexOf(")", System.StringComparison.Ordinal);
                        //        var length = indexEnd - indexStart;

                        //        try
                        //        {
                        //            if (result.ToString().Substring(indexStart, length).Length > 1)
                        //            {
                        //                var store = method.Entity.nHydrateModel.Store;
                        //                using (var transaction = store.TransactionManager.BeginTransaction(Guid.NewGuid().ToString()))
                        //                {

                        //                    method.Parametros = new List<MethodParameters>();

                        //                    var parameters =
                        //                        result.ToString().Substring(indexStart, length).Split(
                        //                            Convert.ToChar(","));

                        //                    foreach (var parameter in parameters)
                        //                    {
                        //                        var param = parameter.Split(Convert.ToChar(" "));

                        //                        var methodParameters = new MethodParameters
                        //                                                   {
                        //                                                       Name = param[1],
                        //                                                       TypeName =
                        //                                                           ConvertFromSystemTypeToCShalp(
                        //                                                               param[0])
                        //                                                   };

                        //                        method.Parametros.Add(methodParameters);

                        //                    }
                        //                    transaction.Commit();
                        //                }
                        //            }
                        //        }
                        //        catch (Exception)
                        //        {

                        //            //throw;
                        //        }
                        //    }
                        //    //return method.Model.nHydrateModel;
                        //}




                        //ControllerMethod controllerMethod = context.Instance as ControllerMethod;
                        //if (result != null && controllerMethod != null)
                        //{
                        //    if (result.ToString().IndexOf("(", System.StringComparison.Ordinal) > -1)
                        //    {
                        //        var methodName = result.ToString().Replace("()", "  ");

                        //        var indexStart = methodName.IndexOf("(", System.StringComparison.Ordinal) + 1;
                        //        var indexEnd = methodName.IndexOf(")", System.StringComparison.Ordinal);
                        //        var length = indexEnd - indexStart;

                        //        try
                        //        {
                        //            if (result.ToString().Substring(indexStart, length).Length > 1)
                        //            {
                        //                var store = controllerMethod.Controller.nHydrateModel.Store;
                        //                using (var transaction = store.TransactionManager.BeginTransaction(Guid.NewGuid().ToString()))
                        //                {

                        //                    controllerMethod.Parameters = new List<MethodParameters>();

                        //                    var parameters =
                        //                        result.ToString().Substring(indexStart, length).Split(
                        //                            Convert.ToChar(","));

                        //                    foreach (var parameter in parameters)
                        //                    {
                        //                        var param = parameter.Split(Convert.ToChar(" "));

                        //                        var methodParameters = new MethodParameters
                        //                        {
                        //                            Name = param[1],
                        //                            TypeName =
                        //                                ConvertFromSystemTypeToCShalp(
                        //                                    param[0])
                        //                        };

                        //                        controllerMethod.Parameters.Add(methodParameters);

                        //                    }
                        //                    transaction.Commit();
                        //                }
                        //            }
                        //        }
                        //        catch (Exception)
                        //        {

                        //            //throw;
                        //        }
                        //    }
                        //    //return method.Model.nHydrateModel;
                        //}




                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandler.Current.Report(exception);
                result = base.EditValue(context, provider, value);
            }
            return result;
        }


        XmlDocument xml = new XmlDocument();
        private string ConvertFromSystemTypeToCShalp(string typeName)
        {
            // var xml = new XmlDocument();

            xml.Load(ImagesList.XmlFilePath);

            var langNode = xml.SelectSingleNode(@"//Tables/Table[@TablaNombre='From C# System Types To C#']");

            if (langNode != null)
                foreach (XmlNode mappingpNode in langNode.ChildNodes)
                {
                    if (mappingpNode.Attributes["From"].Value.Trim().ToLower() == typeName.Trim().ToLower())
                    {
                        return mappingpNode.Attributes["To"].Value;
                    }
                }

            return string.Empty;
        }

        private void OnDropDownClosed(object voIoLUUvvl, EventArgs uIiLvouUQl)
        {
            this.edService.CloseDropDown();
        }


    }
}
