using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sophist.Gerator.UI
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using Sophist.Generator.Configuration;

    public class MainForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MenuItem menuItemFile;
        private MenuItem menuItemOpen;
        private MenuItem menuItemSave;
        private MenuItem menuItemSaveAs;
        private MenuItem menuItemExit;
        private ToolStrip tsMain;
        private ToolStripButton tsButtonOpen;
        private ToolStripButton tsButtonNew;
        private ToolStripButton tsButtonSave;
        private ToolStripButton tsButtonExit;
        private PropertyGrid settingsGrid;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator2;
        private MainMenu mainMenu = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Sophist.Generator.Configuration.GenerationSettings generationSettings2 = new Sophist.Generator.Configuration.GenerationSettings();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.settingsGrid = new System.Windows.Forms.PropertyGrid();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.tsButtonNew = new System.Windows.Forms.ToolStripButton();
            this.tsButtonSave = new System.Windows.Forms.ToolStripButton();
            this.tsButtonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemSaveAs,
            this.menuItemExit});
            this.menuItemFile.Text = "&File";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Text = "&Open";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 1;
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.tsButtonSave_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Index = 2;
            this.menuItemSaveAs.Text = "&SaveAs";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 3;
            this.menuItemExit.Text = "&Exit";
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonOpen,
            this.tsButtonNew,
            this.tsButtonSave,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.tsButtonExit});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMain.Size = new System.Drawing.Size(580, 25);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "tsMain";
            // 
            // settingsGrid
            // 
            this.settingsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsGrid.Location = new System.Drawing.Point(0, 25);
            this.settingsGrid.Name = "settingsGrid";
            this.settingsGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            generationSettings2.ContractsNamespace = "";
            generationSettings2.ContractsPath = "";
            generationSettings2.DataProvidersNamespace = "";
            generationSettings2.DataProvidersPath = "";
            generationSettings2.EntitiesMetadataNamespace = "";
            generationSettings2.EntitiesMetadataPath = "";
            generationSettings2.EntitiesNamespace = "";
            generationSettings2.EntitiesPath = "";
            generationSettings2.MappingsNamespace = "";
            generationSettings2.MappingsPath = "";
            generationSettings2.ProjectName = "";
            generationSettings2.ProjectNamespace = "";
            generationSettings2.ProjectPath = "";
            generationSettings2.ValidationNamespace = "";
            generationSettings2.ValidationPath = "";
            this.settingsGrid.SelectedObject = generationSettings2;
            this.settingsGrid.Size = new System.Drawing.Size(580, 453);
            this.settingsGrid.TabIndex = 4;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButtonOpen
            // 
            this.tsButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonOpen.Image = global::Sophist.Gerator.UI.GenResources.Folder;
            this.tsButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonOpen.Name = "tsButtonOpen";
            this.tsButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.tsButtonOpen.Text = "toolStripButton1";
            this.tsButtonOpen.Click += new System.EventHandler(this.tsButtonOpen_Click);
            // 
            // tsButtonNew
            // 
            this.tsButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonNew.Image = global::Sophist.Gerator.UI.GenResources.New_document;
            this.tsButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonNew.Name = "tsButtonNew";
            this.tsButtonNew.Size = new System.Drawing.Size(23, 22);
            this.tsButtonNew.Text = "toolStripButton2";
            // 
            // tsButtonSave
            // 
            this.tsButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonSave.Image = global::Sophist.Gerator.UI.GenResources.Save;
            this.tsButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonSave.Name = "tsButtonSave";
            this.tsButtonSave.Size = new System.Drawing.Size(23, 22);
            this.tsButtonSave.Text = "toolStripButton3";
            this.tsButtonSave.Click += new System.EventHandler(this.tsButtonSave_Click);
            // 
            // tsButtonExit
            // 
            this.tsButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonExit.Image = global::Sophist.Gerator.UI.GenResources.Exit;
            this.tsButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonExit.Name = "tsButtonExit";
            this.tsButtonExit.Size = new System.Drawing.Size(23, 22);
            this.tsButtonExit.Text = "toolStripButton4";
            this.tsButtonExit.Click += new System.EventHandler(this.tsButtonExit_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Sophist.Gerator.UI.GenResources.Refresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "tsButtonUpdateSetting";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 478);
            this.Controls.Add(this.settingsGrid);
            this.Controls.Add(this.tsMain);
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Sophist Gerator Project Editor";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void tsButtonSave_Click(object sender, EventArgs e)
        {            
            GenerationSettings currentSetting = (GenerationSettings)this.settingsGrid.SelectedObject;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save project";
            saveFileDialog.DefaultExt = "Project Generation Configuration (*.pgc)|*.pgc";
            saveFileDialog.FileName = currentSetting.ProjectName + ".pgc";
            saveFileDialog.Filter = "Project Generation Configuration (*.pgc)|*.pgc|Xml files (*.xml)|*.xml|Configuration files (*.config)|*.config";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(currentSetting.GetType());
                using(Stream fileStream = saveFileDialog.OpenFile())
                {
                    xmlSerializer.Serialize(fileStream, currentSetting);
                    fileStream.Flush();
                    fileStream.Close();
                }
            }
        }

        private void tsButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open project file";
            openFileDialog.DefaultExt = "Project Generation Configuration (*.pgc)|*.pgc";
            openFileDialog.Filter = "Project Generation Configuration (*.pgc)|*.pgc|Xml files (*.xml)|*.xml|Configuration files (*.config)|*.config";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                GenerationSettings currentSetting = (GenerationSettings)this.settingsGrid.SelectedObject;
                XmlSerializer xmlSerial = new XmlSerializer(currentSetting.GetType());
                using (Stream fileStream = openFileDialog.OpenFile())
                {
                    try
                    {
                        this.settingsGrid.SelectedObject = xmlSerial.Deserialize(fileStream);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(openFileDialog.FileName, "Error while reading project file configuration " + openFileDialog.FileName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
