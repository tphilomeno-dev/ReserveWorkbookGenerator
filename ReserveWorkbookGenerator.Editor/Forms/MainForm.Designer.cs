namespace ReserveWorkbookGenerator.Editor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MenuStrip = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuFileNew = new ToolStripMenuItem();
            mnuFileOpen = new ToolStripMenuItem();
            mnuFileSave = new ToolStripMenuItem();
            mnuFileSaveAs = new ToolStripMenuItem();
            sepToolStripMenuItem = new ToolStripSeparator();
            mnuFileGenerate = new ToolStripMenuItem();
            sepToolStripMenuItem1 = new ToolStripSeparator();
            mnuFileExit = new ToolStripMenuItem();
            mnuStudy = new ToolStripMenuItem();
            mnuStudyValidate = new ToolStripMenuItem();
            mnuStudyStats = new ToolStripMenuItem();
            mnuTools = new ToolStripMenuItem();
            mnuToolsOptions = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuHelpAbout = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            btnNew = new ToolStripButton();
            btnOpen = new ToolStripButton();
            btnSave = new ToolStripButton();
            btnGenerate = new ToolStripButton();
            btnValidate = new ToolStripButton();
            tabControl = new TabControl();
            tabStudy = new TabPage();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblSpacer = new ToolStripStatusLabel();
            lblFile = new ToolStripStatusLabel();
            tabSettings = new TabPage();
            tabComponents = new TabPage();
            dgvComponents = new DataGridView();
            MenuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            tabControl.SuspendLayout();
            statusStrip.SuspendLayout();
            tabComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComponents).BeginInit();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { mnuFile, mnuStudy, mnuTools, mnuHelp });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(1184, 24);
            MenuStrip.TabIndex = 0;
            MenuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileNew, mnuFileOpen, mnuFileSave, mnuFileSaveAs, sepToolStripMenuItem, mnuFileGenerate, sepToolStripMenuItem1, mnuFileExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(37, 20);
            mnuFile.Text = "File";
            // 
            // mnuFileNew
            // 
            mnuFileNew.Name = "mnuFileNew";
            mnuFileNew.Size = new Size(179, 22);
            mnuFileNew.Text = "New Study";
            mnuFileNew.Click += mnuFileNew_Click;
            // 
            // mnuFileOpen
            // 
            mnuFileOpen.Name = "mnuFileOpen";
            mnuFileOpen.Size = new Size(179, 22);
            mnuFileOpen.Text = "Open";
            mnuFileOpen.Click += mnuFileOpen_Click;
            // 
            // mnuFileSave
            // 
            mnuFileSave.Name = "mnuFileSave";
            mnuFileSave.Size = new Size(179, 22);
            mnuFileSave.Text = "Save";
            mnuFileSave.Click += mnuFileSave_Click;
            // 
            // mnuFileSaveAs
            // 
            mnuFileSaveAs.Name = "mnuFileSaveAs";
            mnuFileSaveAs.Size = new Size(179, 22);
            mnuFileSaveAs.Text = "Save As";
            mnuFileSaveAs.Click += mnuFileSaveAs_Click;
            // 
            // sepToolStripMenuItem
            // 
            sepToolStripMenuItem.Name = "sepToolStripMenuItem";
            sepToolStripMenuItem.Size = new Size(176, 6);
            // 
            // mnuFileGenerate
            // 
            mnuFileGenerate.Name = "mnuFileGenerate";
            mnuFileGenerate.Size = new Size(179, 22);
            mnuFileGenerate.Text = "Generate Workbook";
            mnuFileGenerate.Click += mnuFileGenerate_Click;
            // 
            // sepToolStripMenuItem1
            // 
            sepToolStripMenuItem1.Name = "sepToolStripMenuItem1";
            sepToolStripMenuItem1.Size = new Size(176, 6);
            // 
            // mnuFileExit
            // 
            mnuFileExit.Name = "mnuFileExit";
            mnuFileExit.Size = new Size(179, 22);
            mnuFileExit.Text = "Exit";
            mnuFileExit.Click += mnuFileExit_Click;
            // 
            // mnuStudy
            // 
            mnuStudy.DropDownItems.AddRange(new ToolStripItem[] { mnuStudyValidate, mnuStudyStats });
            mnuStudy.Name = "mnuStudy";
            mnuStudy.Size = new Size(49, 20);
            mnuStudy.Text = "Study";
            // 
            // mnuStudyValidate
            // 
            mnuStudyValidate.Name = "mnuStudyValidate";
            mnuStudyValidate.Size = new Size(153, 22);
            mnuStudyValidate.Text = "Validate";
            mnuStudyValidate.Click += mnuStudyValidate_Click;
            // 
            // mnuStudyStats
            // 
            mnuStudyStats.Name = "mnuStudyStats";
            mnuStudyStats.Size = new Size(153, 22);
            mnuStudyStats.Text = "Study Statistics";
            mnuStudyStats.Click += mnuStudyStats_Click;
            // 
            // mnuTools
            // 
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuToolsOptions });
            mnuTools.Name = "mnuTools";
            mnuTools.Size = new Size(47, 20);
            mnuTools.Text = "Tools";
            // 
            // mnuToolsOptions
            // 
            mnuToolsOptions.Name = "mnuToolsOptions";
            mnuToolsOptions.Size = new Size(116, 22);
            mnuToolsOptions.Text = "Options";
            mnuToolsOptions.Click += mnuToolsOptions_Click;
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuHelpAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(44, 20);
            mnuHelp.Text = "Help";
            // 
            // mnuHelpAbout
            // 
            mnuHelpAbout.Name = "mnuHelpAbout";
            mnuHelpAbout.Size = new Size(107, 22);
            mnuHelpAbout.Text = "About";
            mnuHelpAbout.Click += mnuHelpAbout_Click;
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { btnNew, btnOpen, btnSave, btnGenerate, btnValidate });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1184, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(84, 22);
            btnNew.Text = "New Study";
            btnNew.Click += btnNew_Click;
            // 
            // btnOpen
            // 
            btnOpen.Image = (Image)resources.GetObject("btnOpen.Image");
            btnOpen.ImageTransparentColor = Color.Magenta;
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(56, 22);
            btnOpen.Text = "Open";
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(51, 22);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Image = (Image)resources.GetObject("btnGenerate.Image");
            btnGenerate.ImageTransparentColor = Color.Magenta;
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(74, 22);
            btnGenerate.Text = "Generate";
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnValidate
            // 
            btnValidate.Image = (Image)resources.GetObject("btnValidate.Image");
            btnValidate.ImageTransparentColor = Color.Magenta;
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(68, 22);
            btnValidate.Text = "Validate";
            btnValidate.Click += btnValidate_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabStudy);
            tabControl.Controls.Add(tabSettings);
            tabControl.Controls.Add(tabComponents);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 49);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1184, 712);
            tabControl.TabIndex = 2;
            // 
            // tabStudy
            // 
            tabStudy.Location = new Point(4, 24);
            tabStudy.Name = "tabStudy";
            tabStudy.Padding = new Padding(3);
            tabStudy.Size = new Size(1176, 684);
            tabStudy.TabIndex = 0;
            tabStudy.Text = "Study";
            tabStudy.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, lblSpacer, lblFile });
            statusStrip.Location = new Point(0, 739);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1184, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 17);
            lblStatus.Text = "Ready";
            // 
            // lblSpacer
            // 
            lblSpacer.Name = "lblSpacer";
            lblSpacer.Size = new Size(1013, 17);
            lblSpacer.Spring = true;
            // 
            // lblFile
            // 
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(86, 17);
            lblFile.Text = "No File Loaded";
            // 
            // tabSettings
            // 
            tabSettings.Location = new Point(4, 24);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new Padding(3);
            tabSettings.Size = new Size(1176, 684);
            tabSettings.TabIndex = 1;
            tabSettings.Text = "Settings";
            tabSettings.UseVisualStyleBackColor = true;
            // 
            // tabComponents
            // 
            tabComponents.Controls.Add(dgvComponents);
            tabComponents.Location = new Point(4, 24);
            tabComponents.Name = "tabComponents";
            tabComponents.Size = new Size(1176, 684);
            tabComponents.TabIndex = 2;
            tabComponents.Text = "Components";
            tabComponents.UseVisualStyleBackColor = true;
            // 
            // dgvComponents
            // 
            dgvComponents.AllowUserToAddRows = false;
            dgvComponents.AllowUserToDeleteRows = false;
            dgvComponents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComponents.Dock = DockStyle.Fill;
            dgvComponents.Location = new Point(0, 0);
            dgvComponents.MultiSelect = false;
            dgvComponents.Name = "dgvComponents";
            dgvComponents.RowHeadersVisible = false;
            dgvComponents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComponents.Size = new Size(1176, 684);
            dgvComponents.TabIndex = 0;
            dgvComponents.CellValueChanged += dgvComponents_CellValueChanged;
            dgvComponents.CurrentCellDirtyStateChanged += dgvComponents_CurrentCellDirtyStateChanged;
            //dgvComponents.CellValidating += dgvComponents_CellValidating;
            //dgvComponents.DataError += dgvComponents_DataError;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(statusStrip);
            Controls.Add(tabControl);
            Controls.Add(toolStrip);
            Controls.Add(MenuStrip);
            MainMenuStrip = MenuStrip;
            MinimumSize = new Size(1200, 800);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reserve Study Editor";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            tabControl.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tabComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvComponents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MenuStrip;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuFileNew;
        private ToolStripMenuItem mnuFileOpen;
        private ToolStripMenuItem mnuFileSave;
        private ToolStripMenuItem mnuFileSaveAs;
        private ToolStripSeparator sepToolStripMenuItem;
        private ToolStripMenuItem mnuFileGenerate;
        private ToolStripSeparator sepToolStripMenuItem1;
        private ToolStripMenuItem mnuFileExit;
        private ToolStripMenuItem mnuStudy;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem mnuStudyValidate;
        private ToolStripMenuItem mnuStudyStats;
        private ToolStripMenuItem mnuTools;
        private ToolStripMenuItem mnuToolsOptions;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuHelpAbout;
        private ToolStrip toolStrip;
        private ToolStripButton btnNew;
        private ToolStripButton btnOpen;
        private TabControl tabControl;
        private TabPage tabStudy;
        private TabPage tabSettings;
        private ToolStripButton btnSave;
        private ToolStripButton btnGenerate;
        private ToolStripButton btnValidate;
        private TabPage tabComponents;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblSpacer;
        private ToolStripStatusLabel lblFile;
        private DataGridView dgvComponents;
    }
}
