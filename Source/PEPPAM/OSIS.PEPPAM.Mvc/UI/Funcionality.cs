using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Mvc.Core.UI;
using OSIS.PEPPAM.Mvc.Models;

namespace OSIS.PEPPAM.Mvc.UI
{
    public class Funcionality : IFuncionality
    {
        private IModule _module;
        private string _objectName;
        public Funcionality()
        {
            
        }
        public Funcionality(string code, string objectName)
        {
            _objectName = objectName;
        }

        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Help { get; set; }
        public string Url { get; set; }
        public List<IField> Fields { get; set; }
        public List<IAction> Actions { get; set; }

        public IModule Module
        {
            get
            {
                if (_module == null)
                {
                    _module = new Module();
                }
                return _module;
            }
            set { _module = value; }
        }

        public IFuncionality GetFuncionality(string codeFuncionality)
        {
            return GetFuncionality(codeFuncionality, true);
        }
        

        public IFuncionality GetFuncionality(string codeFuncionality, bool addIfNotExit = false)
        {
            _objectName = codeFuncionality;

            Code = codeFuncionality;

            var funcionalidad = Models.Sistemas_Funcionalidades_MasterModel.LoadByFuncionalidad_Codigo(codeFuncionality);

            if (funcionalidad == null)
            {
                if (addIfNotExit)
                {
                    var addNew = new Sistemas_Funcionalidades_MasterModel()
                    {
                        Modulo_Numero = Sistemas_Modulos_MasterModel.LoadAll().FirstOrDefault().Modulo_Numero,
                        Funcionalidad_Codigo = codeFuncionality,
                        Funcionalidad_Nombre = codeFuncionality.Replace("_", " "),
                        Funcionalidad_Descripcion = codeFuncionality.Replace("_", " "),
                        Funcionalidad_Explicacion = codeFuncionality.Replace("_", " "),
                        Funcionalidad_Url = "N/E",
                        Funcionalidad_Permiso_Descripcion = codeFuncionality,
                        Registro_Estado = "A",
                        Registro_Fecha = DateTime.Now,
                        Registro_Usuario = "Sistema",
                        
                    };
                    addNew.Save();

                    funcionalidad = Models.Sistemas_Funcionalidades_MasterModel.LoadByFuncionalidad_Codigo(codeFuncionality);
                }
            }

            var result =  new Funcionality()
            {
                Id = funcionalidad.Funcionalidad_Numero.ToString(CultureInfo.InvariantCulture),
                Name = funcionalidad.Funcionalidad_Nombre,
                Code = funcionalidad.Funcionalidad_Codigo,
                Description = funcionalidad.Funcionalidad_Descripcion,
                Help = funcionalidad.Funcionalidad_Explicacion,
                Icon = string.Empty,
                Module = Module.GetModule(funcionalidad.Modulo_Numero.ToString(CultureInfo.InvariantCulture)),
                Actions = GetgActions(funcionalidad.Funcionalidad_Numero.ToString(CultureInfo.InvariantCulture)),
                Fields = GetgFields(_objectName),
                Url = funcionalidad.Funcionalidad_Url
            };

            return result;
        }

        public IField GetField(string codeField)
        {
            return GetField(codeField, true);
        }

        public IField GetField(string codeField, bool addIsNew = false)
        {

            var field = this.Fields.FirstOrDefault(x => x.Code == codeField);

            if (field == null && addIsNew)
            {

                var addNew = new Sistemas_Descripciones_TransModel()
                {
                    Objeto_Codigo = Code,
                    Objeto_Sub_Codigo = codeField,
                    Objeto_Sub_Descripcion = codeField.Replace("_"," "),
                    Objeto_Sub_Explicacion = codeField.Replace("_", " "),
                    Objeto_Sub_Datagrid_Orden = 1,
                    Objeto_Sub_Datagrid_Mostrar = "S",
                    Objeto_Sub_Editar_Orden = 1,
                    Objeto_Sub_Editar_Mostrar = "S",
                    Objeto_Sub_Detalle_Orden = 1,
                    Objeto_Sub_Detalle_Mostrar = "S",
                    Registro_Estado = "A",
                    Registro_Fecha = DateTime.Now,
                    Registro_Usuario = "Automatico",
                };

                addNew.Save();

                Fields = GetgFields(Code);

                field = this.Fields.FirstOrDefault(x => x.Code == codeField);
            }

            return field;
        }

        public List<IField> GetgFields(string objectoCodigo)
        {
            var fields = Models.Sistemas_Descripciones_TransModel.Objectocodigo(objectoCodigo).Where(x => x.Objeto_Codigo != x.Objeto_Sub_Codigo);

            var result = fields.Select(_field => new Field()
            {
                Code = _field.Objeto_Sub_Codigo,
                Description = _field.Objeto_Sub_Descripcion,
                Help = _field.Objeto_Sub_Explicacion,
                Funcionality = this,
                Icon = string.Empty,
                Name = _field.Objeto_Sub_Descripcion,
                MostrarDetails = _field.Objeto_Sub_Detalle_Mostrar == "S",
                MostrarEdit = _field.Objeto_Sub_Editar_Mostrar == "S",
                MostrarGrid = _field.Objeto_Sub_Datagrid_Mostrar == "S",
                OrdenDetails = _field.Objeto_Sub_Detalle_Orden,
                OrdenEdit = _field.Objeto_Sub_Editar_Orden,
                OrdenGrid = _field.Objeto_Sub_Datagrid_Orden
            }).ToList();



            return new List<IField>(result);
        }

        public IAction GetAction(string codeAction)
        {
            return GetAction(codeAction, true);
        }

        public IAction GetAction(string codeAction, bool addIfNotExit = false)
        {
           // return this.Actions.FirstOrDefault(x => x.Code == codeAction);
            var action = Models.Sistemas_Funcionalidades_Acciones_CataModel.LoadByFuncionalidad_Accion_Codigo(codeAction);

            
            if (action == null)
            {
                if (addIfNotExit)
                {
                    var addnew = new Sistemas_Funcionalidades_Acciones_CataModel()
                    {
                        Funcionalidad_Accion_Tipo_Secuencia = 1,
                        Funcionalidad_Accion_Codigo = codeAction,
                        Funcionalidad_Accion_Descripcion = codeAction,
                        Funcionalidad_Accion_Explicacion = codeAction,
                        Funcionalidad_Accion_Icono_Small = "N/E",
                        Funcionalidad_Accion_Icono_Large = "N/E",
                        Funcionalidad_Accion_Css = "N/E",
                        Funcionalidad_Accion_Toolbar = "S",
                        Funcionalidad_Accion_Menu = "S",
                        Funcionalidad_Accion_Permiso_Descripcion = codeAction,
                        Funcionalidad_Accion_Permiso_Necesita = "N",
                        Registro_Estado = "A",
                        Registro_Fecha = DateTime.Now,
                        Registro_Usuario = "Automatico",
                        
                    };

                    addnew.Save();

                    action = Models.Sistemas_Funcionalidades_Acciones_CataModel.LoadByFuncionalidad_Accion_Codigo(codeAction);
                }
                else
                {
                    return null;
                }
            }

            return new Action()
            {
                Id = action.Funcionalidad_Accion_Numero.ToString(),
                Code = action.Funcionalidad_Accion_Codigo,
                CssClass = action.Funcionalidad_Accion_Css,
                Description = action.Funcionalidad_Accion_Descripcion,
                Help = action.Funcionalidad_Accion_Explicacion,
                Icon = action.Funcionalidad_Accion_Icono_Small,
                Name = action.Funcionalidad_Accion_Descripcion,
                Funcionality = this
            };

        }

        public List<IAction> GetgActions(string codeFuncionality)
        {
            var actions =
                Models.Sistemas_Funcionalidades_Acciones_CataModel.Loadfuncionalidad(
                    Convert.ToInt32(codeFuncionality));


            var result = actions.Select(_actions => new Action()
            {
                Id = _actions.Funcionalidad_Accion_Numero.ToString(),
                Code = _actions.Funcionalidad_Accion_Codigo,
                CssClass = _actions.Funcionalidad_Accion_Css,
                Description = _actions.Funcionalidad_Accion_Descripcion,
                Help = _actions.Funcionalidad_Accion_Explicacion,
                Icon = _actions.Funcionalidad_Accion_Icono_Small,
                Name = _actions.Funcionalidad_Accion_Descripcion,
                Funcionality = this
            }).ToList();


            return new List<IAction>(result);
        }

        public IMessages GetMessages(string code)
        {
            var messagesDb = Models.Sistemas_Mensaje_TransModel.Load(code);

            if (messagesDb == null)
            {
                var message = new Models.Sistemas_Mensaje_TransModel()
                {
                    Mensaje_Codigo = code,
                    Mensaje_Descripcion = code,
                    Registro_Estado = "A",
                    Registro_Fecha = DateTime.Now,
                    Registro_Usuario = "Automatico"
                };

                message.Save();
            }

            messagesDb = Models.Sistemas_Mensaje_TransModel.Load(code);

            return new Messages()
            {
                Code = messagesDb.Mensaje_Codigo,
                Description = messagesDb.Mensaje_Descripcion
            };
        }

        public static IMessages GetOrSetMessages(string code)
        {
            var funcionality = new Funcionality();
            return funcionality.GetMessages(code);
        }


        public string GetGridColumns(string objectoCodigo)
        {
            var fields =
                Models.Sistemas_Descripciones_TransModel.Objectocodigo(objectoCodigo)
                    .Where(x => x.Objeto_Sub_Datagrid_Mostrar == "S")
                    .OrderBy(x => x.Objeto_Sub_Datagrid_Orden);

            var sb = new StringBuilder();
            foreach (var field in Fields)
            {
                sb.AppendLine(string.Format("<th>{0}</th>", field.Name));
            }

            return sb.ToString();
        }


        //sTitle
        public string GetGridColumnsArray(string code)
        {
            var fields =
                Models.Sistemas_Descripciones_TransModel.Objectocodigo(code)
                    .Where(x => x.Objeto_Sub_Datagrid_Mostrar == "S" && x.Objeto_Codigo != x.Objeto_Sub_Codigo)
                    .OrderBy(x => x.Objeto_Sub_Datagrid_Orden);

            var sb = new StringBuilder();
            //sb.AppendLine("[");
            var count = 0;
            foreach (var field in fields)
            {
                count++;
                sb.AppendLine("{ \"sName\":  \"" + field.Objeto_Sub_Codigo + "\" , \"mData\":  \"" + field.Objeto_Sub_Codigo + "\", \"sTitle\":  \"" + field.Objeto_Sub_Descripcion + "\"}");
                if (count < fields.Count())
                {
                    sb.Append(",");
                }
            }
            //sb.AppendLine("]");
            return sb.ToString();
        }
        public string GetGridColumnsHeadersArray(string code)
        {
            var fields =
                Models.Sistemas_Descripciones_TransModel.Objectocodigo(code)
                    .Where(x => x.Objeto_Sub_Datagrid_Mostrar == "S" && x.Objeto_Codigo != x.Objeto_Sub_Codigo)
                    .OrderBy(x => x.Objeto_Sub_Datagrid_Orden);

            var sb = new StringBuilder();
            //sb.AppendLine("[");
           // var count = 0;
            sb.AppendLine("<thead>");
            foreach (var field in fields)
            {
                //count++;
                sb.AppendLine(string.Format("<th>{0}</th>", field.Objeto_Sub_Descripcion));
                //if (count < fields.Count())
                //{
                //    sb.Append(",");
                //}
            }
            //sb.AppendLine("]");
            sb.AppendLine("</thead>");
            return sb.ToString();
        }

        string IFuncionality.GetDescription(string codeParent, string codeChild)
        {
            return GetDescription(codeParent, codeChild);
        }


        public static string GetDescription(string codeParent, string codeChild)
        {
            return GetDescription(codeParent, codeChild, false);
        }

        public static string GetDescription(string codeParent, string codeChild, bool registreIsNoExist)
        {
            var description =
                Models.Sistemas_Descripciones_TransModel.Load(codeParent, codeChild);

            if (description == null)
            {
                if (registreIsNoExist)
                {
                    var desc = new Sistemas_Descripciones_TransModel()
                    {

                        Objeto_Codigo = codeParent,
                        Objeto_Sub_Codigo = codeChild,
                        Objeto_Sub_Descripcion = codeChild.Replace("_", " "),
                        Objeto_Sub_Explicacion = codeChild.Replace("_", " "),
                        Objeto_Sub_Datagrid_Orden = 1,
                        Objeto_Sub_Datagrid_Mostrar = "S",
                        Objeto_Sub_Editar_Orden = 1,
                        Objeto_Sub_Editar_Mostrar = "S",
                        Objeto_Sub_Detalle_Orden = 1,
                        Objeto_Sub_Detalle_Mostrar = "S",
                        Registro_Estado = "A",
                        Registro_Fecha = DateTime.Now,
                        Registro_Usuario = "Automatico",
                    };
                    desc.Save();

                    description = Models.Sistemas_Descripciones_TransModel.Load(codeParent, codeChild);
                }
            }

            return description.Objeto_Sub_Descripcion;
        }
    }
}