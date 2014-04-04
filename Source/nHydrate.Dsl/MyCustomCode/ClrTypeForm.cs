
using System.Linq;
using EnvDTE;
using global::CodeFluent.Runtime;
using global::CodeFluent.Runtime.Utilities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
namespace nHydrate.Dsl.Editor
{
	public class ClrTypeForm : Form
	{
		private class LioIILLUol : IWin32Window
		{
			[CompilerGenerated]
			private IntPtr LiiluLOII;
			public IntPtr Handle
			{
				get;
				private set;
			}
			public LioIILLUol(IntPtr oQlUUUQoil)
			{
				this.Handle = oQlUUUQoil;
			}
		}
		private class oloILLILQ : IComparer<Type>
		{
			int IComparer<Type>.Compare(Type x, Type y)
			{
				return x.Name.CompareTo(y.Name);
			}
		}
		public class Comparable : IComparable<ClrTypeForm.Comparable>, IComparable
		{
			public string iUoouliOUl;
			public readonly List<Type> OQULlUUQUl = new List<Type>();
			public void lluuvQiuv()
			{
				this.OQULlUUQUl.Sort(new ClrTypeForm.oloILLILQ());
			}
			int IComparable.CompareTo(object obj)
			{
				return this.CompareTo(obj as ClrTypeForm.Comparable);
			}
			public int CompareTo(ClrTypeForm.Comparable other)
			{
				if (other == null)
				{
					throw new ArgumentNullException("other");
				}
				return this.iUoouliOUl.CompareTo(other.iUoouliOUl);
			}
		}
		private class ouOLiuOQLl : MarshalByRefObject
		{
            public static DialogResult oOOvoOQvvl(IntPtr llloLoULIl, nHydrateModel model, string ivuvlLiQO, ref string UOOioloOi)
            {
				AppDomain appDomain = null;
				List<string> list = new List<string>();
				
                    //foreach (Reference current in project.References)
                    //{
                    //    if (current.ReferencedPath != null)
                    //    {
                    //        list.Add(current.ReferencedPath);
                    //    }
                    //}
				
				ClrTypeForm.ouOLiuOQLl ouOLiuOQLl;
				if (AppDomain.CurrentDomain.IsDefaultAppDomain())
				{
					appDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString("N"));
					ouOLiuOQLl = (ClrTypeForm.ouOLiuOQLl)appDomain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, typeof(ClrTypeForm.ouOLiuOQLl).FullName);
				}
				else
				{
					ouOLiuOQLl = new ClrTypeForm.ouOLiuOQLl();
				}
				DialogResult result;
				try
				{

                    string myNamespace;
                    if (string.IsNullOrEmpty(model.DefaultNamespace))
                        myNamespace = model.CompanyName + "." + model.ProjectName;
                    else
                        myNamespace = model.DefaultNamespace;

                    var projectName = myNamespace + ".Install";


                    result = ouOLiuOQLl.DialogResult(llloLoULIl, projectName, list, ivuvlLiQO, ref UOOioloOi);
				}
				finally
				{
					if (appDomain != null)
					{
						AppDomain.Unload(appDomain);
					}
				}
				return result;
			}
			private DialogResult DialogResult(IntPtr QluuIQIOu, string projectName, IEnumerable<string> OOvQOOoUul,  string UoOLIlLUl, ref string typeName)
			{
				AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(uOvlvIvLil);
				ClrTypeForm clrTypeForm = new ClrTypeForm(OOvQOOoUul,projectName,  typeName);
				if (!string.IsNullOrEmpty(UoOLIlLUl))
				{
					clrTypeForm.Text = UoOLIlLUl;
				}
				ClrTypeForm.LioIILLUol owner = new ClrTypeForm.LioIILLUol(QluuIQIOu);
				DialogResult dialogResult = clrTypeForm.ShowDialog(owner);
				if (dialogResult == System.Windows.Forms.DialogResult.OK)
				{
					typeName = clrTypeForm.SelectedTypeName;
				}
				return dialogResult;
			}


            private static Assembly OOLUoIuill(string QiolQoulQ, Type llOOvuuiOl)
            {
                if (llOOvuuiOl.Assembly.FullName == QiolQoulQ)
                {
                    return llOOvuuiOl.Assembly;
                }
                if (llOOvuuiOl.Namespace == QiolQoulQ)
                {
                    return llOOvuuiOl.Assembly;
                }
                return null;
            }

            internal static Assembly uOvlvIvLil(object IluLlIiOU, ResolveEventArgs QiQQlLoUQ)
            {
                Assembly assembly = OOLUoIuill(QiQQlLoUQ.Name, typeof(Entity));
                if (assembly == null)
                {
                    assembly = OOLUoIuill(QiQQlLoUQ.Name, typeof(Entity));
                    if (assembly == null)
                    {
                        assembly = OOLUoIuill(QiQQlLoUQ.Name, typeof(CodeFluentContext));
                        if (assembly == null)
                        {
                            assembly = OOLUoIuill(QiQQlLoUQ.Name, typeof(nHydrateModel));
                        }
                    }
                }
                if (assembly == null)
                {
                    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    for (int i = 0; i < assemblies.Length; i++)
                    {
                        Assembly assembly2 = assemblies[i];
                        if (assembly2.FullName == QiQQlLoUQ.Name)
                        {
                            assembly = assembly2;
                            break;
                        }
                    }
                }
                if (assembly == null && QiQQlLoUQ.Name.StartsWith("CodeFluent"))
                {
                    string text = QiQQlLoUQ.Name;
                    int num = text.IndexOf((char)44);
                    if (num >= 0)
                    {
                        text = text.Substring(0, num).Trim();
                    }
                    string text2 = Path.Combine(Path.GetDirectoryName(typeof(Entity).Assembly.Location), text + ".dll");
                    if (IOUtilities.FileExists(text2))
                    {
                        assembly = Assembly.Load(AssemblyName.GetAssemblyName(text2));
                    }
                }
                return assembly;
            }


		}
		private Size uvuoQOQiQ;
		private Size ooUiOQUvil;
		private Point ILovioIIUl;
		private Point LovulUuQu;
		private Label vOvuvOIoLl = new Label();
		private IContainer QOuQiliOv;
		private TableLayoutPanel QuviIvIvu;
		private Button UlOiuUvvi;
		private TreeView treeViewDll;
		private Button btnOK;
		
		
		public string SelectedTypeName
		{
			get;
			set;
		}
		public ClrTypeForm() : this(null, null,null)
		{
		}
		private ClrTypeForm(IEnumerable<string> iUuQuilLu, string projectName, string typeName)
		{
		    this.ProjectName = projectName;

			this.OIuivUvLQl();
			this.treeViewDll.ImageList = ImagesList.OvilILoOv;
			this.treeViewDll.ShowNodeToolTips = true;
			
			this.SelectedTypeName = typeName;
			
				this.IIIoLUu();
			
			if (iUuQuilLu != null)
			{
				foreach (string current in iUuQuilLu)
				{
					if (!string.IsNullOrEmpty(current))
					{
						Assembly assembly = null;
						try
						{
                            string assemblyPath = AssemblyUtilities.GetAssemblyPath(current, true, false);
							//assembly = Reference.iuiIviIULI(null, current, false);
                            assembly = Assembly.Load(AssemblyName.GetAssemblyName(assemblyPath));
						}
						catch
						{
							this.AddNotLoadedAssembly(current);
							continue;
						}
						if (assembly != null)
						{
							this.AddAssembly(assembly);
						}
					}
				}
			}
			//base.Icon = ImageLibrary.CodeFluentIcon;
			this.vOvuvOIoLl.AutoSize = true;
            this.vOvuvOIoLl.Text = "Host CLR: " + Environment.Version;
			this.vOvuvOIoLl.Location = new Point(3, base.ClientRectangle.Height - 24);
			base.Controls.Add(this.vOvuvOIoLl);
			this.vOvuvOIoLl.BringToFront();
		}
		public static DialogResult ChooseTypeName(IWin32Window owner,nHydrateModel model , ref string selectedTypeName)
		{
			return ClrTypeForm.ChooseTypeName(owner, model, null, ref selectedTypeName);
		}
		public static DialogResult ChooseTypeName(IWin32Window owner, nHydrateModel model ,  string title, ref string selectedTypeName)
		{
			return ClrTypeForm.ouOLiuOQLl.oOOvoOQvvl((owner != null) ? owner.Handle : IntPtr.Zero, model , title, ref selectedTypeName);
		}

        public nHydrate.Dsl.nHydrateModel nHydateModel { get; set; }

        public string ProjectName { get; set; }


		private void IIIoLUu()
		{
            //this.AddAssembly(typeof(string).Assembly);
            //this.AddAssembly(typeof(Uri).Assembly);
            //this.AddAssembly(typeof(System.Configuration.ConfigurationManager).Assembly);
            //this.AddAssembly("System.ComponentModel.DataAnnotations");
            //this.AddAssembly(typeof(DbType).Assembly);
            //this.AddAssembly("System.ServiceModel");
            //this.AddAssembly(typeof(System.Web.HttpContext).Assembly);
            //this.AddAssembly(typeof(XmlDocument).Assembly);
            //this.AddAssembly(typeof(CodeFluentContext).Assembly);
            

            // Load Reference Current Project
            var references = nHydrate.Generator.Common.Util.EnvDTEHelper.Instance.GetReferencesCurrentProject();
            foreach (var reference in references)
            {
                this.AddAssembly(Assembly.LoadFile(reference.Value));
            }

		}


        public static Assembly LoadAssembly(string name, bool algo)
        {
            string assemblyPath = AssemblyUtilities.GetAssemblyPath(name, true, false);
            //assembly = Reference.iuiIviIULI(null, current, false);
            return Assembly.Load(AssemblyName.GetAssemblyName(assemblyPath));
        }


	    public void AddNotLoadedAssembly(string path)
		{
			TreeNode treeNode = this.treeViewDll.Nodes.Add(Path.GetFileName(path));
			treeNode.ToolTipText = path;
			treeNode.ImageIndex = 5;
			treeNode.SelectedImageIndex = treeNode.ImageIndex;
		}
		public void AddAssembly(string name)
		{
			Assembly assembly;
			try
			{
                assembly = LoadAssembly( name, false);
			}
			catch
			{
				return;
			}
			if (assembly != null)
			{
				this.AddAssembly(assembly);
			}
		}
		public void AddAssembly(Assembly assembly)
		{
			if (assembly == null)
			{
                throw new ArgumentNullException("assembly");
			}
		    

			this.treeViewDll.BeginUpdate();
			try
			{
				Dictionary<string, ClrTypeForm.Comparable> dictionary = new Dictionary<string, ClrTypeForm.Comparable>();
			System.Reflection.Module[] modules = assembly.GetModules(false);
				for (int i = 0; i < modules.Length; i++)
				{
                    System.Reflection.Module module = modules[i];
					Type[] types;
					try
					{
						types = module.GetTypes();
					}
					catch (ReflectionTypeLoadException ex)
					{
						types = ex.Types;
					}
					Type[] array = types;
					for (int j = 0; j < array.Length; j++)
					{
						Type type = array[j];
						if (type != null && type.IsPublic )
						{
							
                                //if (!typeof(System.Attribute).IsAssignableFrom(type))
                                //{
                                //    goto IL_436;
                                //}
                                //AttributeUsageAttribute attribute = AssemblyUtilities.GetAttribute<AttributeUsageAttribute>(type);
                                //if (attribute != null && attribute.ValidOn != (AttributeTargets)32767 )
                                //{
                                //    goto IL_436;
                                //}
							
							if ((!type.IsInterface ) && !type.IsSubclassOf(typeof(Delegate)) && type.Namespace != null)
							{
								ClrTypeForm.Comparable oQULLLLlol;
								if (!dictionary.TryGetValue(type.Namespace, out oQULLLLlol))
								{
									oQULLLLlol = new ClrTypeForm.Comparable();
									oQULLLLlol.iUoouliOUl = type.Namespace;
									dictionary.Add(oQULLLLlol.iUoouliOUl, oQULLLLlol);
								}
								oQULLLLlol.OQULlUUQUl.Add(type);
							}
						}
						IL_436:;
					}
				}
				TreeNode treeNode = this.treeViewDll.Nodes.Add(assembly.GetName().Name);
				treeNode.ToolTipText = assembly.FullName;
				treeNode.Tag = assembly;
				treeNode.ImageIndex = 4;
				treeNode.SelectedImageIndex = treeNode.ImageIndex;
				List<ClrTypeForm.Comparable> list = new List<ClrTypeForm.Comparable>(dictionary.Values);
				list.Sort();
				foreach (ClrTypeForm.Comparable current in list)
				{
					if (current.OQULlUUQUl.Count != 0)
					{
						current.lluuvQiuv();
						TreeNode treeNode2 = treeNode.Nodes.Add(current.iUoouliOUl);
						treeNode2.Tag = current;
						treeNode2.ImageIndex = 64;
						treeNode2.SelectedImageIndex = treeNode2.ImageIndex;
						foreach (Type current2 in current.OQULlUUQUl)
						{
							TreeNode treeNode3 = treeNode2.Nodes.Add(ClrTypeForm.lOiOiUvQo(current2));
							treeNode3.Tag = current2;
							if (current2.IsEnum)
							{
                                //if (ConvertUtilities.IsFlagsEnum(current2))
                                //{
                                //    treeNode3.ImageIndex = 108;
                                //}
                                //else
								{
									treeNode3.ImageIndex = 63;
								}
							}
							else
							{
								if (current2.IsValueType)
								{
									treeNode3.ImageIndex = 91;
								}
								else
								{
									treeNode3.ImageIndex = 62;
								}
							}

						    AddMember(current2, treeNode3);

							treeNode3.SelectedImageIndex = treeNode3.ImageIndex;
							if (this.SelectedTypeName != null && this.SelectedTypeName == current2.FullName)
							{
								this.treeViewDll.SelectedNode = treeNode3;
							}
						}
					}
				}
			}
			finally
			{
				this.treeViewDll.EndUpdate();
			}
			if (this.treeViewDll.SelectedNode != null)
			{
				this.treeViewDll.Select();
				this.treeViewDll.SelectedNode.EnsureVisible();
			}
		}


        public void AddMember(Type type, TreeNode treeNodeParent)
        {
            // For each type, show its members & their custom attributes.
            foreach (MemberInfo mi in type.GetMembers())
            {
                if (mi.MemberType == MemberTypes.Method || mi.MemberType == MemberTypes.Property)
                {
                    var treeNode = new TreeNode(mi.Name) {Text = mi.Name, Name = mi.Name, Tag =  type.FullName};
                    
                    if (mi.MemberType == MemberTypes.Method)
                    {

                        System.Reflection.MemberInfo[] members =
                            mi.GetType().GetMembers(System.Reflection.BindingFlags.Static);


                        
                        string parameters;
                        AddMemberParameters(mi, out parameters);

                        treeNode.Text += parameters;


                        var firstOrDefault = members.FirstOrDefault();
                        if (firstOrDefault != null && firstOrDefault.Equals(System.Reflection.BindingFlags.Static))
                        {
                            treeNode.Tag = treeNode.Tag + "()." + treeNode.Text;     
                        }
                        else
                        {
                            treeNode.Tag = " new " + treeNode.Tag + "()." + treeNode.Text;                            
                        }



                        treeNode.ImageIndex = (int) ImageLibraryIndex.CodeFluentMethod;
                        treeNode.SelectedImageIndex = treeNode.ImageIndex;
                    }

                    if (mi.MemberType == MemberTypes.Property)
                    {
                        treeNode.Tag += "." + treeNode.Text;

                        treeNode.ImageIndex = (int) ImageLibraryIndex.CodeFluentProperty;
                        treeNode.SelectedImageIndex = treeNode.ImageIndex;
                    }

                    treeNodeParent.Nodes.Add(treeNode);
                }
            }
        }

        public void AddMemberParameters(MemberInfo memberInfo, out string parameters)
        {
            parameters = ((MethodInfo) memberInfo)
                            .GetParameters()
                                .Aggregate("(",
                                            (current, pi) =>
                                            current +
                                            string.Format("{0} {1},", pi.ParameterType,
                                                        pi.Name));

            //Remover la ultima coma (,)
            if (parameters.Length > 2)
            {
                parameters = parameters.Remove(parameters.Length - 1, 1);
            }

            parameters += ")";
        }

	    private static string SelectedTypeToString(Type UlQiUiOUl)
		{
			if (!UlQiUiOUl.IsGenericType)
			{
				return UlQiUiOUl.FullName;
			}
			if (UlQiUiOUl.FullName == null)
			{
				return null;
			}
			int num = UlQiUiOUl.FullName.IndexOf((char)96);
			if (num < 0)
			{
				return UlQiUiOUl.FullName;
			}
			StringBuilder stringBuilder = new StringBuilder(UlQiUiOUl.FullName.Substring(0, num));
			stringBuilder.Append((char)60);
			Type[] genericArguments = UlQiUiOUl.GetGenericArguments();
			for (int i = 0; i < genericArguments.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append((char)44);
				}
				stringBuilder.Append(genericArguments[i].FullName);
			}
			stringBuilder.Append((char)62);
			return stringBuilder.ToString();
		}
       
		public static string lOiOiUvQo(Type ILovUvLvI)
		{
			if (!ILovUvLvI.IsGenericType)
			{
				return ILovUvLvI.Name;
			}
			if (ILovUvLvI.Name == null)
			{
				return null;
			}
			int num = ILovUvLvI.Name.IndexOf((char)96);
			if (num < 0)
			{
				return ILovUvLvI.Name;
			}
			StringBuilder stringBuilder = new StringBuilder(ILovUvLvI.Name.Substring(0, num));
			stringBuilder.Append((char)60);
			Type[] genericArguments = ILovUvLvI.GetGenericArguments();
			for (int i = 0; i < genericArguments.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append((char)44);
				}
				if (genericArguments[i].FullName != null)
				{
					stringBuilder.Append(genericArguments[i].FullName);
				}
			}
			stringBuilder.Append((char)62);
			return stringBuilder.ToString();
		}
		private void QLuLQQLQ(object ollvUILvU, EventArgs QivvoovLLI)
		{
			this.uvuoQOQiQ = base.Size;
			this.MinimumSize = this.uvuoQOQiQ;
			this.ooUiOQUvil = this.treeViewDll.Size;
			this.ILovioIIUl = this.btnOK.Location;
			this.LovulUuQu = this.UlOiuUvvi.Location;
			//LayoutOptions.Current.LoadForm(this, null);

            this.StartPosition = FormStartPosition.Manual;
                
            
            this.Width = 50;
            this.Height = 50;
            this.Left = 50;
            this.Top = 50;
		}
		private void ovivlOoiol(object LQlillIli, EventArgs IulQUOQvil)
		{
			if (this.ILovioIIUl.IsEmpty)
			{
				return;
			}
			Size sz = new Size((base.Size.Width - this.uvuoQOQiQ.Width) / 2, (base.Size.Height - this.uvuoQOQiQ.Height) / 2);
			this.treeViewDll.Size = this.ooUiOQUvil + base.Size - this.uvuoQOQiQ;
			this.btnOK.Location = this.ILovioIIUl + sz;
			this.UlOiuUvvi.Location = this.LovulUuQu + sz;
			this.vOvuvOIoLl.Location = new Point(this.vOvuvOIoLl.Location.X, base.ClientRectangle.Height - 24);
			this.vOvuvOIoLl.BringToFront();
		}
		private void OnAfterSelect(object QovLOLiQol, TreeViewEventArgs LlIUovliul)
		{
			TreeNode selectedNode = this.treeViewDll.SelectedNode;
            this.btnOK.Enabled = (selectedNode != null && (selectedNode.Tag is Type || selectedNode.Tag is string));
		}
		private void OnNodeMouseDoubleClick(object LLolQviLv, TreeNodeMouseClickEventArgs vlUulOQuQ)
		{
			if (vlUulOQuQ.Node != null)
			{
				Type type = vlUulOQuQ.Node.Tag as Type;
				if (type != null)
				{
					this.SelectedTypeName = ClrTypeForm.SelectedTypeToString(type);
					base.DialogResult = DialogResult.OK;
					base.Close();
				}

                string fullName = vlUulOQuQ.Node.Tag as string;
                if (fullName != null)
                {
                    this.SelectedTypeName = fullName;//ClrTypeForm.SelectedMethodToString(vlUulOQuQ.Node);
                    base.DialogResult = DialogResult.OK;
                    base.Close();
                }

			}
		}
		private void UlIOiuouO(object oOiLioOULl, FormClosingEventArgs ouOvOOovLI)
		{
			if ((ouOvOOovLI.CloseReason == CloseReason.UserClosing || ouOvOOovLI.CloseReason == CloseReason.None) && base.DialogResult == DialogResult.OK)
			{
				TreeNode selectedNode = this.treeViewDll.SelectedNode;
				if (selectedNode != null)
				{
					Type type = selectedNode.Tag as Type;
					if (type != null)
					{
                        this.SelectedTypeName = ClrTypeForm.SelectedTypeToString(type);	
                        return;
					}

                    string fullName = selectedNode.Tag as string;
                    if (fullName != null)
                    {
                        this.SelectedTypeName = fullName; //ClrTypeForm.SelectedTypeToString(selectedNode);
                        return;
                    }


                    ouOvOOovLI.Cancel = true;
                    return;
				}
			}
			//LayoutOptions.Current.SaveForm(this, null);
		}
		private void vIlLoOiILI(object iLuLvQUoQl, EventArgs IQoLIviQl)
		{
			base.Close();
		}
		private void OnButtonClick(object vUovioIuU, EventArgs uIoLQQliQl)
		{
			base.Close();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.QOuQiliOv != null)
			{
				this.QOuQiliOv.Dispose();
			}
			base.Dispose(disposing);
		}
		private void OIuivUvLQl()
		{
			this.QuviIvIvu = new TableLayoutPanel();
			this.treeViewDll = new TreeView();
			this.btnOK = new Button();
			this.UlOiuUvvi = new Button();
			this.QuviIvIvu.SuspendLayout();
			base.SuspendLayout();
			this.QuviIvIvu.ColumnCount = 2;
			this.QuviIvIvu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50));
			this.QuviIvIvu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50));
			this.QuviIvIvu.Controls.Add(this.treeViewDll, 0, 0);
			this.QuviIvIvu.Controls.Add(this.btnOK, 0, 1);
			this.QuviIvIvu.Controls.Add(this.UlOiuUvvi, 1, 1);
			this.QuviIvIvu.Dock = DockStyle.Fill;
			this.QuviIvIvu.Location = new Point(0, 0);
            this.QuviIvIvu.Name = "tableLayoutPanel1";
			this.QuviIvIvu.RowCount = 2;
			this.QuviIvIvu.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
			this.QuviIvIvu.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
			this.QuviIvIvu.Size = new Size(643, 451);
			this.QuviIvIvu.TabIndex = 4;
            this.treeViewDll.AccessibleName = "Types";
			this.QuviIvIvu.SetColumnSpan(this.treeViewDll, 2);
			this.treeViewDll.Dock = DockStyle.Fill;
			this.treeViewDll.Location = new Point(3, 3);
            this.treeViewDll.Name = "treeViewTypes";
            this.treeViewDll.Size = new Size(637, 415);
			this.treeViewDll.TabIndex = 0;
			this.treeViewDll.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.OnNodeMouseDoubleClick);
			this.treeViewDll.AfterSelect += new TreeViewEventHandler(this.OnAfterSelect);
            this.btnOK.AccessibleName = "OK";
			this.btnOK.Anchor = (AnchorStyles)9;
			this.btnOK.DialogResult = DialogResult.OK;
			this.btnOK.Enabled = false;
            this.btnOK.Location = new Point(244, 424);
            this.btnOK.Name = "buttonOK";
			this.btnOK.Size = new Size(74,23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new EventHandler(this.OnButtonClick);
            this.UlOiuUvvi.AccessibleName = "Cancel";
			this.UlOiuUvvi.DialogResult = DialogResult.Cancel;
            this.UlOiuUvvi.Location = new Point(324, 424);
            this.UlOiuUvvi.Name = "buttonCancel";
			this.UlOiuUvvi.Size = new Size(75, 23);
			this.UlOiuUvvi.TabIndex = 2;
            this.UlOiuUvvi.Text = "&amp;Cancel";
			this.UlOiuUvvi.UseVisualStyleBackColor = true;
			this.UlOiuUvvi.Click += new EventHandler(this.vIlLoOiILI);
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new SizeF(6, 13);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.UlOiuUvvi;
			base.ClientSize = new Size(643, 451);
			base.Controls.Add(this.QuviIvIvu);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
            base.Name = "ClrTypeForm";
			base.StartPosition = FormStartPosition.CenterParent;
            this.Text = ".NET Type Chooser";
			base.Load += new EventHandler(this.QLuLQQLQ);
			base.FormClosing += new FormClosingEventHandler(this.UlIOiuouO);
			base.Resize += new EventHandler(this.ovivlOoiol);
			this.QuviIvIvu.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
