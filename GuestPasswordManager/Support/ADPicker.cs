/*
 *
 *
 * Licensed under the Code Project Open License (CPOL) 1.02
 * https://www.codeproject.com/info/cpol10.aspx
 *
 * Derived from
 *
 * https://www.codeproject.com/Articles/6848/Active-Directory-object-picker-control
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GuestPasswordManager.Support;

namespace GuestPasswordManager.Support
{
	public class ADPicker : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TreeView treeView1;
		private string _adspath = "";
		private ArrayList alExceptions = new ArrayList(2);

        /// <summary>
        /// TODO temp
        /// </summary>
        public TreeView TreeView => treeView1;

		private ADHelper adh;

        /// <summary>
        /// Trigger when the user selects an item in the list.
        /// </summary>
	    public event Action AfterSelect;
        
	    /// <summary>
        /// Reference to logger
        /// </summary>
	    private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
	        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Trigger when the user selects a collection in the list.
        /// </summary>
        public event Action AfterExpand;

		public ADPicker()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			alExceptions.Add("OU=Domain Controllers");
			alExceptions.Add("CN=Computers");
			alExceptions.Add("OU=Computers");
		}

		public string ADsPath
		{
			get => _adspath;
		    set
            {
                Logger.Debug($"Try to set ADsPath to {value}");

                if (string.IsNullOrEmpty(value))
                {
                    Logger.Debug("Cannot set to an empty string -- silent for designer");
                    _adspath = value;
                    return;
                }

                if (treeView1.Nodes.Count < 1)
                {
                    throw new InvalidOperationException("Cannot expand an empty tree view");
                }


                // split adspath to components so we can loop through and expand correct nodes
                List<string> components = value.Split(',').ToList();
                int currentComponentIndex = 0;

                components.Reverse();

                // remove LDAP://
                if (components.Count > 0)
                {
                    components[components.Count-1] = components[components.Count-1].Replace("LDAP://", "");
                }

                // remove DC= components
                List<string> removeIndex = new List<string>();
                foreach(string component in components)
                {
                    if (component.StartsWith("DC"))
                    {
                        removeIndex.Add(component);
                    }
                }
                foreach(string remove in removeIndex)
                {
                    components.Remove(remove);
                }

                Logger.Debug($"components: {value}, split by ,");
                foreach(string component in components)
                {
                    Logger.Debug($"{component}");
                }

                // expand root node
                treeView1.Nodes[0].Expand();

                TreeNode currentNode = treeView1.Nodes[0];
                TreeNodeCollection currentNodeCollection = treeView1.Nodes;
                int currentNodeIndex = 0;
                int expandCount = 0;
                int maxExpandWatchdog = 128; // some protection against infinite loops

                _adspath = value;

                while (expandCount < maxExpandWatchdog)
                {
                    expandCount++;

                    string[] pathComponents = currentNode.FullPath.Split('\\');
                    // ignore index 0, will be "Root"

                    if (pathComponents.Length < 2)
                    {
                        if (currentNode.Nodes.Count > 0)
                        {
                            currentNode = currentNode.Nodes[0];
                            //currentNodeCollection = currentNode.Nodes;
                            currentNodeIndex = 0;
                        }
                        continue;
                    }

                    if (pathComponents.Length < currentComponentIndex + 1)
                    {
                        Logger.Debug($"Ran out of path components");
                        break;
                    }
                    if (components.Count < currentComponentIndex + 1)
                    {
                        Logger.Debug($"Ran out of target components");
                        break;
                    }

                    Logger.Debug($"pathComponents[currentComponentIndex+1] = {pathComponents[currentComponentIndex + 1]}");
                    Logger.Debug($"components[currentComponentIndex] = {components[currentComponentIndex]}");

                    if (pathComponents[currentComponentIndex + 1] == components[currentComponentIndex])
                    {
                        Logger.Debug($"Match -- expand {currentNode.FullPath}");

                        currentNode.Expand();
                        if (components[components.Count-1] == currentNode.Text)
                        {
                            Logger.Debug($"Matched complete node path {currentNode}");
                            treeView1.SelectedNode = currentNode;
                        }
                        currentNode = currentNode.Nodes[0];
                        currentNodeCollection = currentNode.Nodes;
                        currentComponentIndex++;
                        currentNodeIndex = 0;
                    }
                    else
                    {
                        // does not match current drill down target

                        //if (currentNodeIndex + 1 < currentNodeCollection.Count)
                        //{
                        //    Logger.Debug($"Will set currentNode to collection index+1 {currentNodeCollection[currentNodeIndex + 1].FullPath}");
                        //    currentNode = currentNodeCollection[currentNodeIndex + 1];
                        //    currentNodeIndex++;
                        //}
                        if (currentNodeIndex + 1 < currentNode.Parent.Nodes.Count)
                        {
                            Logger.Debug($"Will set currentNode to parent {currentNode.Parent.FullPath}");
                            currentNode = currentNode.Parent.Nodes[currentNodeIndex + 1];
                            currentNodeIndex++;
                        }
                        else
                        {
                            Logger.Info($"Ran out of nodes trying to search for {value}");
                            break;
                        }
                        
                    }
                }
                if (expandCount > maxExpandWatchdog)
                {
                    Logger.Info($"Gave up trying to manage nodes after {expandCount}");
                }

                
                
            }
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ADPicker));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(296, 360);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// ADPicker
			// 
			this.Controls.Add(this.treeView1);
			this.Name = "ADPicker";
			this.Size = new System.Drawing.Size(296, 360);
			this.Load += new System.EventHandler(this.ADPicker_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ADPicker_Load(object sender, System.EventArgs e)
		{
			TreeNode parentNode = new TreeNode("Root");
			parentNode.Tag = "";
			treeView1.Nodes.Add(parentNode);
			AddTreeNodes(parentNode);
			treeView1.Nodes[0].Expand();

		    treeView1.AfterSelect += delegate { AfterSelect?.Invoke(); };
		    treeView1.AfterExpand += delegate { AfterExpand?.Invoke(); };

            foreach (TreeNode childNode in parentNode.Nodes)
				AddTreeNodes(childNode);
		}

		private void AddTreeNodes(TreeNode node)
		{
			Cursor.Current = Cursors.WaitCursor;
			treeView1.BeginUpdate();
			adh = new ADHelper();
			adh.GetChildEntries((string)node.Tag);
			IDictionaryEnumerator enumerator = adh.Children.GetEnumerator();
		
			while (enumerator.MoveNext())
			{
				TreeNode childNode = new TreeNode((string)enumerator.Key);
				childNode.Tag = enumerator.Value;
				node.Nodes.Add(childNode);

				if (!alExceptions.Contains(node.Text))
					childNode.ImageIndex = 
						SetImageIndex(enumerator.Key.ToString().Substring(0,2));					
				else
					childNode.ImageIndex = 3;
			}
			treeView1.EndUpdate();
			Cursor.Current = Cursors.Default;
		}

		private void treeView1_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			foreach (TreeNode childNode in e.Node.Nodes)
				AddTreeNodes(childNode);
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			_adspath = (string)e.Node.Tag;

			if (e.Node.Parent != null)
			{
				if (!alExceptions.Contains(e.Node.Parent.Text) && e.Node.Parent.Text != "")
					e.Node.SelectedImageIndex = SetImageIndex(e.Node.Text.Substring(0,2));
				else
					e.Node.SelectedImageIndex = 3;
			}
		}

		private int SetImageIndex(string objectType)
		{
			int imageIndex = 0;

			switch (objectType)
			{
				case "CN":
					imageIndex = 1;
					break;
				case "OU":
					imageIndex = 2;
					break;
				case "DC":
					imageIndex = 3;
					break;
			}
			return imageIndex;
		}
	}
}
