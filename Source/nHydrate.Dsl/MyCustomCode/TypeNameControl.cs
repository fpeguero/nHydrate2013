using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CodeFluent.Runtime.Utilities;
using System.Linq;

namespace nHydrate.Dsl.Editor
{
    public partial class TypeNameControl : UserControl
    {
        public TypeNameControl()
        {
            InitializeComponent();
        }

        private EventHandler<EventArgs> _eventHandler;
        protected TreeView _treeViewMain;
        private readonly TreeNode _treeNodeClrTypes1;
        private string _typeName;
        private IContainer iContainer;
        private readonly TreeNode _treeNodeKeyTypes1;
        private readonly TreeNode _treeNodeFavoriteTypes1;
        private readonly TreeNode _treeNodeProjectTypes1;
        private readonly TreeNode _treeNodeReferencedTypes1;
        private readonly TreeNode _treeNodeUserTypes1;
        private static DistinctDictionary<string> dictionaryTypes;
        private Form TreeViewForm;

        private XmlDocument xml = new XmlDocument();
        private XmlNode langNode = null;

        public event EventHandler<EventArgs> TypeChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this._eventHandler = (EventHandler<EventArgs>)Delegate.Combine(this._eventHandler, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this._eventHandler = (EventHandler<EventArgs>)Delegate.Remove(this._eventHandler, value);
            }
        }

        public object Target
        {
            get;
            private set;
        }

        public string TypeName
        {
            get
            {
                return this._typeName;
            }
            set
            {
                if (this._typeName != value)
                {
                    this._typeName = value;
                    this.OnTypeChanged(this, EventArgs.Empty);
                }
            }
        }

        public nHydrate.Dsl.nHydrateModel nHydateModel { get; set; }


        public bool SelectOnSingleClick
        {
            get;
            set;
        }
        static TypeNameControl()
        {
            TypeNameControl.dictionaryTypes = new DistinctDictionary<string>();
            TypeNameControl.dictionaryTypes.Add(typeof(OrderedDictionary).FullName);
            TypeNameControl.dictionaryTypes.Add(typeof(PersistentList<string>).FullName);
            TypeNameControl.dictionaryTypes.Add(typeof(PersistentList<int>).FullName);
        }
        public virtual void FillTreeView()
        {
            //Standard Types

            this.xml.Load(ImagesList.XmlFilePath);
            langNode = this.xml.SelectSingleNode(@"//Tables/Table[@TablaNombre='From SQL to C#']");

            var treeNodeStandardArray = new TreeNode[langNode.ChildNodes.Count];
            int i = 0;
            foreach (XmlNode mappingpNode in langNode.ChildNodes)
            {
               var treeNode = new TreeNode(mappingpNode.Attributes["To"].Value);
                treeNode.Name = mappingpNode.Attributes["To"].Value;


                treeNode.ImageIndex = (int) ImageLibraryIndex.CodeFluentStandardType;
                treeNode.SelectedImageIndex = treeNode.ImageIndex;

               treeNodeStandardArray[i] = treeNode;
                i++;
            }


            var treeNodeStandard = new TreeNode("Standard Types", treeNodeStandardArray);
            treeNodeStandard.Name = "treeNodeStandard";
            treeNodeStandard.Text = "Standard Types";
            treeNodeStandard.Tag = DBNull.Value;
            treeNodeStandard.ImageIndex = 7;
            treeNodeStandard.SelectedImageIndex = treeNodeStandard.ImageIndex;
            treeNodeStandard.ExpandAll();

            _treeViewMain.Nodes.Add(treeNodeStandard);

            if (this.nHydateModel != null)
            {

                if (this.nHydateModel.Entities.Count > 0 || this.nHydateModel.StoredProcedures.Count > 0)
                {
                    var treeNodeModelTypes = new TreeNode();
                    treeNodeModelTypes.Name = "treeNodeModelTypes";
                    treeNodeModelTypes.Text = "Model Types";
                    treeNodeModelTypes.Tag = DBNull.Value;
                    _treeViewMain.Nodes.Add(treeNodeModelTypes);
                    
                    foreach (var entity in this.nHydateModel.Entities)
                    {
                        var model1 = entity as Entity;
                        if (model1 != null)
                        {
                            var treeNode = new TreeNode(model1.Name) {Name = model1.Name};
                            treeNodeModelTypes.Nodes.Add(treeNode);

                            treeNodeModelTypes.ImageIndex = (int) ImageLibraryIndex.CodeFluentEntity;
                            treeNodeModelTypes.SelectedImageIndex = treeNodeModelTypes.ImageIndex;
                        }
                    }
                    foreach (var storedProcedure in this.nHydateModel.StoredProcedures)
                    {
                        var model1 = storedProcedure as StoredProcedure;
                        if (model1 != null)
                        {
                            var treeNode = new TreeNode(model1.Name) {Name = model1.Name};
                            treeNodeModelTypes.Nodes.Add(treeNode);

                            treeNodeModelTypes.ImageIndex = (int) ImageLibraryIndex.CodeFluentCfqlProcedure;
                            treeNodeModelTypes.SelectedImageIndex = treeNodeModelTypes.ImageIndex;
                        }
                    }
                }
            }

            //Other Types
            TreeNode treeNodeOtherTypesBrowser = new TreeNode();
            treeNodeOtherTypesBrowser.Name = "treeNodeOtherTypesBrowser";
            treeNodeOtherTypesBrowser.Text = "Browser Other Types...";

            TreeNode treeNodeFavoriteTypes = new TreeNode("Favorite Types");
            treeNodeFavoriteTypes.Name = "FavoriteTypes";
            treeNodeFavoriteTypes.Text = "Favorite Types";
            treeNodeFavoriteTypes.Tag = DBNull.Value;

            TreeNode treeNodeOtherTypes = new TreeNode("Other Types", new TreeNode[]
			{
                treeNodeFavoriteTypes,
				treeNodeOtherTypesBrowser
			});
            treeNodeOtherTypes.Name = "treeNodeOtherTypes";
            treeNodeOtherTypes.Text = "Other Types";

            treeNodeOtherTypes.ExpandAll();
            _treeViewMain.Nodes.Add(treeNodeOtherTypes);



           
            base.SuspendLayout();
            this._treeViewMain.Dock = DockStyle.Fill;
            this._treeViewMain.HideSelection = false;
            this._treeViewMain.Location = new Point(0, 0);
            this._treeViewMain.Name = "_treeViewMain";


            this._treeViewMain.Size = new Size(150, 150);
            this._treeViewMain.TabIndex = 0;
            this._treeViewMain.AfterCollapse += new TreeViewEventHandler(this.AfterCollapse);
            this._treeViewMain.AfterSelect += new TreeViewEventHandler(this.AfterSelect);
            this._treeViewMain.PreviewKeyDown += new PreviewKeyDownEventHandler(this.OnPreviewKeyDownEvent);
            this._treeViewMain.AfterExpand += new TreeViewEventHandler(this.AfterExpand);
            base.Controls.Add(this._treeViewMain);
            base.ResumeLayout(false);



        }


        public TypeNameControl(nHydrateModel project, object target)
        {
            this.Target = target;
            this.SelectOnSingleClick = true;

            base.Width = 300;
            base.Height = 530;

            this.nHydateModel = project;

            _treeViewMain = new TreeView();
            this._treeViewMain.ImageList = ImagesList.OvilILoOv;

            FillTreeView();



            this._treeNodeProjectTypes1 = this._treeViewMain.Nodes["treeNodeModelTypes"];
            if (_treeNodeProjectTypes1 != null)
            {
                this._treeNodeProjectTypes1.Tag = DBNull.Value;
                this._treeNodeProjectTypes1.ImageIndex = 7;
                this._treeNodeProjectTypes1.SelectedImageIndex = this._treeNodeProjectTypes1.ImageIndex;
                this._treeNodeProjectTypes1.ExpandAll();

                if (this._treeNodeProjectTypes1.Nodes.Count == 0)
                {
                    this._treeViewMain.Nodes.Remove(this._treeNodeProjectTypes1);
                }
            }

            this._treeNodeKeyTypes1 = this._treeViewMain.Nodes["treeNodeStandard"];
            if (_treeNodeKeyTypes1 != null)
            {

                _treeNodeKeyTypes1.Tag = DBNull.Value;
                _treeNodeKeyTypes1.ExpandAll();
            }

            TreeNode treeNodeOtherTypes = this._treeViewMain.Nodes["treeNodeOtherTypes"];
            
                treeNodeOtherTypes.Tag = DBNull.Value;
                treeNodeOtherTypes.ImageIndex = 7;
                treeNodeOtherTypes.SelectedImageIndex = treeNodeOtherTypes.ImageIndex;
                treeNodeOtherTypes.Expand();
           
            this._treeNodeClrTypes1 = treeNodeOtherTypes.Nodes["treeNodeOtherTypesBrowser"];
            if (_treeNodeClrTypes1 != null)
            {

                this._treeNodeClrTypes1.Tag = DBNull.Value;
                this._treeNodeClrTypes1.ImageIndex = 45;
                this._treeNodeClrTypes1.SelectedImageIndex = this._treeNodeClrTypes1.ImageIndex;
            }
            this._treeNodeFavoriteTypes1 = treeNodeOtherTypes.Nodes["FavoriteTypes"];
            this._treeNodeFavoriteTypes1.Tag = DBNull.Value;
            this._treeNodeFavoriteTypes1.ImageIndex = 7;
            this._treeNodeFavoriteTypes1.SelectedImageIndex = this._treeNodeFavoriteTypes1.ImageIndex;

            foreach (string current4 in TypeNameControl.dictionaryTypes)
            {
                TreeNode treeNode5 = this._treeNodeFavoriteTypes1.Nodes.Add(current4, current4);
                treeNode5.ImageIndex = 44;
                treeNode5.SelectedImageIndex = treeNode5.ImageIndex;
            }

        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.TreeViewForm != null)
            {
                this.TreeViewForm.LocationChanged -= new EventHandler(this.OnFormSize);
                this.TreeViewForm.Resize -= new EventHandler(this.OnFormSize);
                this.TreeViewForm = null;
            }
            this.TreeViewForm = (base.Parent as Form);
            if (this.TreeViewForm != null)
            {
                this.TreeViewForm.LocationChanged += new EventHandler(this.OnFormSize);
                this.TreeViewForm.Resize += new EventHandler(this.OnFormSize);
            }
        }
        private void OnFormSize(object iIuoIoIvi, EventArgs uUIullIiQl)
        {
            TypeNameControl.FormSize(this.TreeViewForm);
        }
        private static void FormSize(Control vioLUlLOvl)
        {
            Rectangle workingArea = Screen.FromControl(vioLUlLOvl).WorkingArea;
            Rectangle bounds = vioLUlLOvl.Bounds;
            if (bounds.X < workingArea.X)
            {
                bounds.X = workingArea.X;
            }
            if (bounds.Y < workingArea.Y)
            {
                bounds.Y = workingArea.Y;
            }
            if (bounds.Width > workingArea.Width)
            {
                bounds.Width = workingArea.Width;
            }
            if (bounds.Height > workingArea.Height)
            {
                bounds.Height = workingArea.Height;
            }
            vioLUlLOvl.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this._treeViewMain.SelectedNode != this._treeNodeClrTypes1)
            {
                this.ChooseTypeName(this._treeViewMain.SelectedNode);
            }
        }

        protected void OnPreviewKeyDownEvent(object uULLiuouv, PreviewKeyDownEventArgs previewKeyDownEventArgs)
        {
            if (previewKeyDownEventArgs.KeyCode == Keys.Return)
            {
                this.ChooseTypeName(this._treeViewMain.SelectedNode);
            }
        }

        private void ChooseTypeName(TreeNode UUUOouuII)
        {
            if (UUUOouuII == null)
            {
                return;
            }
            if (UUUOouuII == this._treeNodeClrTypes1)
            {
               
               string typeName = this._typeName;
                DialogResult dialogResult = ClrTypeForm.ChooseTypeName(this, this.nHydateModel, ref typeName );
                if (dialogResult == DialogResult.OK)
                {
                    this.TypeName = typeName;
                    if (this._treeNodeFavoriteTypes1.Nodes.Find(this.TypeName, true).Length == 0)
                    {
                        TypeNameControl.dictionaryTypes.Add(this.TypeName);
                        TreeNode treeNode = this._treeNodeFavoriteTypes1.Nodes.Add(this.TypeName, this.TypeName);
                        treeNode.ImageIndex = 44;
                        treeNode.SelectedImageIndex = treeNode.ImageIndex;
                        this._treeViewMain.SelectedNode = treeNode;
                    }
                }
                return;
            }
            if (Convert.IsDBNull(UUUOouuII.Tag))
            {
                this.TypeName = null;
                return;
            }



            this.TypeName = UUUOouuII.Name;
        }

        private void OnTypeChanged(object sender, EventArgs e)
        {
            EventHandler<EventArgs> eventHandler = this._eventHandler;
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        protected void AfterExpand(object ooLiuvolQl, TreeViewEventArgs oIuuQLOOll)
        {
            if (oIuuQLOOll.Node.ImageIndex == 7)
            {
                oIuuQLOOll.Node.ImageIndex = 8;
                oIuuQLOOll.Node.SelectedImageIndex = oIuuQLOOll.Node.ImageIndex;
            }
        }

        protected void AfterCollapse(object oOLilOuLo, TreeViewEventArgs QIulOuOOU)
        {
            if (QIulOuOOU.Node.ImageIndex == 8)
            {
                QIulOuOOU.Node.ImageIndex = 7;
                QIulOuOOU.Node.SelectedImageIndex = QIulOuOOU.Node.ImageIndex;
            }
        }

        protected void AfterSelect(object UvouOoOOI, TreeViewEventArgs IoLvQvuoQ)
        {
            if (IoLvQvuoQ.Action == TreeViewAction.ByKeyboard || IoLvQvuoQ.Action == TreeViewAction.ByMouse)
            {
                this.ChooseTypeName(IoLvQvuoQ.Node);
            }
        }

        public void SelectTypeName()
        {
            this.SelectTypeName(this._typeName);
        }
        private void SelectTypeName(string typeName)
        {
            if (typeName != null)
            {

                if (_treeNodeKeyTypes1 != null)
                {
                    foreach (TreeNode treeNode in this._treeNodeKeyTypes1.Nodes)
                    {
                        if (string.Compare(treeNode.Name, typeName, true) == 0)
                        {
                            this._treeViewMain.SelectedNode = treeNode;

                            return;
                        }
                    }
                }

                if (_treeNodeProjectTypes1 != null)
                {
                    foreach (TreeNode treeNode in this._treeNodeProjectTypes1.Nodes)
                    {
                        if (string.Compare(treeNode.Name, typeName, true) == 0)
                        {
                            this._treeViewMain.SelectedNode = treeNode;

                            return;
                        }
                    }
                }

                if (_treeNodeFavoriteTypes1 != null)
                {
                    foreach (TreeNode treeNode in this._treeNodeFavoriteTypes1.Nodes)
                    {
                        if (string.Compare(treeNode.Name, typeName, true) == 0)
                        {
                            this._treeViewMain.SelectedNode = treeNode;

                            return;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(typeName))
                    {
                        TypeNameControl.dictionaryTypes.Add(typeName);
                        var treeNodeFavoriteTypes1 = this._treeNodeFavoriteTypes1;
                        if (treeNodeFavoriteTypes1 != null)
                        {
                            TreeNode treeNode4 = treeNodeFavoriteTypes1.Nodes.Add(typeName);
                            treeNode4.Name = typeName;
                            treeNode4.ImageIndex = 44;
                            treeNode4.SelectedImageIndex = treeNode4.ImageIndex;
                            this._treeViewMain.SelectedNode = treeNode4;
                        }
                    }

            }
        }

    }
}
