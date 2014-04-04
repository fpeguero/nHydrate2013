#region Copyright (c) 2006-2013 nHydrate.org, All Rights Reserved
// -------------------------------------------------------------------------- *
//                           NHYDRATE.ORG                                     *
//              Copyright (c) 2006-2013 All Rights reserved                   *
//                                                                            *
//                                                                            *
// Permission is hereby granted, free of charge, to any person obtaining a    *
// copy of this software and associated documentation files (the "Software"), *
// to deal in the Software without restriction, including without limitation  *
// the rights to use, copy, modify, merge, publish, distribute, sublicense,   *
// and/or sell copies of the Software, and to permit persons to whom the      *
// Software is furnished to do so, subject to the following conditions:       *
//                                                                            *
// The above copyright notice and this permission notice shall be included    *
// in all copies or substantial portions of the Software.                     *
//                                                                            *
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,            *
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES            *
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  *
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY       *
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,       *
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE          *
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                     *
// -------------------------------------------------------------------------- *
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nHydrate.DataImport;
using nHydrate.Generator.Models;
using nHydrate.Dsl;
using Microsoft.VisualStudio.Modeling;
using Field = nHydrate.Dsl.Field;

namespace nHydrate.DslPackage.Forms
{
	public partial class ImportObjectDbFromSqlInline : Form
	{
		private IFieldContainer _entity = null;
		private Microsoft.VisualStudio.Modeling.Store _store = null;
	    private nHydrateModel _model;
	    private Microsoft.VisualStudio.Modeling.Shell.ModelingDocData _docData = null;
		public ImportObjectDbFromSqlInline()
		{
			InitializeComponent();

			lblText.Text = "Especifique el script en SQL con el cual se consultara el objeto de base de datos, ya sea tabla o Stored Procedure";
			lblHeader.Text = "Syntax:\r\nExample:";
			lblData.Text = "Proc_Nombre_Procedure @paramater1, @parameter2\r\n" +
				"Proc_Calcular 1,2\r\n" ;
		}

        public ImportObjectDbFromSqlInline(nHydrateModel model, Microsoft.VisualStudio.Modeling.Store store, Microsoft.VisualStudio.Modeling.Shell.ModelingDocData docData)
			: this()
        {
            _model = model;
			_store = store;
            _docData = docData;
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			var doClose = ProcessSqlInline();
			if (doClose)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

        public nHydrate.DataImport.Database NewDatabase { get; private set; }

		private bool ProcessSqlInline()
		{
			if (string.IsNullOrEmpty(txtText.Text.Trim()))
			{
				MessageBox.Show("No existen SQL Script", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

		    var databaseConnectionControl = new DatabaseConnectionControl();

            databaseConnectionControl.FileName = Path.Combine((new FileInfo(_docData.FileName)).DirectoryName, "importconnection.cache");
            databaseConnectionControl.LoadSettings();

            var connectionString = databaseConnectionControl.ImportOptions.GetConnectionString();

            IImportDomain importDomain = null;
            importDomain = new nHydrate.DataImport.SqlClient.ImportDomain();

		    var datos = this.txtText.Lines;

            NewDatabase =  importDomain.Import(connectionString, datos, SqlServerObject.StoredProcedure);

            foreach (var entity in this.NewDatabase.EntityList)
		    {
		        if (_model.Entities.FirstOrDefault(x => x.Name.ToLower() == entity.Name.ToLower()) != null)
		        {
                    entity.ImportState = ImportStateConstants.Modified;
		        }
		        else
		        {
                    entity.ImportState = ImportStateConstants.Added;
		        }
		    }

            foreach (var procedure in this.NewDatabase.StoredProcList)
            {
                if (_model.Entities.FirstOrDefault(x => x.Name.ToLower() == procedure.Name.ToLower()) != null)
                {
                    procedure.ImportState = ImportStateConstants.Modified;
                }
                else
                {
                    procedure.ImportState = ImportStateConstants.Added;
                }
            }
            
            
			return true;
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		

	}
}

