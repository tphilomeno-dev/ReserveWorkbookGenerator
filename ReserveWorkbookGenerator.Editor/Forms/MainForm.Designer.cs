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
            btnAddComponent = new ToolStripButton();
            btnDuplicateComponent = new ToolStripButton();
            btnDeleteComponent = new ToolStripButton();
            btnMoveUp = new ToolStripButton();
            btnMoveDown = new ToolStripButton();
            tabControl = new TabControl();
            tabStudy = new TabPage();
            txtNotes = new TextBox();
            lblNotes = new Label();
            txtVersion = new TextBox();
            lblVersion = new Label();
            txtPreparedBy = new TextBox();
            lblPreparedBy = new Label();
            dtStudyDate = new DateTimePicker();
            lblStudyDate = new Label();
            txtPropertyDescription = new TextBox();
            lblPropertyDescription = new Label();
            txtAssociationName = new TextBox();
            lblAssociationName = new Label();
            tabSettings = new TabPage();
            cboAllocationMethod = new ComboBox();
            lblAllocationMethod = new Label();
            nudInflationRate = new NumericUpDown();
            lblInflationRate = new Label();
            nudInterestRate = new NumericUpDown();
            lblInterestRate = new Label();
            nudBeginningReservePool = new NumericUpDown();
            lblBeginReservePool = new Label();
            nudUnitCount = new NumericUpDown();
            lblUnitCount = new Label();
            lblCurrentYear = new Label();
            nudCurrentYear = new NumericUpDown();
            tabComponents = new TabPage();
            dgvComponents = new DataGridView();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblSpacer = new ToolStripStatusLabel();
            lblFile = new ToolStripStatusLabel();
            MenuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            tabControl.SuspendLayout();
            tabStudy.SuspendLayout();
            tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudInflationRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudInterestRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBeginningReservePool).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCurrentYear).BeginInit();
            tabComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComponents).BeginInit();
            statusStrip.SuspendLayout();
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
            toolStrip.Items.AddRange(new ToolStripItem[] { btnNew, btnOpen, btnSave, btnGenerate, btnValidate, btnAddComponent, btnDuplicateComponent, btnDeleteComponent, btnMoveUp, btnMoveDown });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1184, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(68, 22);
            btnNew.Text = "New Study";
            btnNew.Click += btnNew_Click;
            // 
            // btnOpen
            // 
            btnOpen.ImageTransparentColor = Color.Magenta;
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(40, 22);
            btnOpen.Text = "Open";
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(35, 22);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.ImageTransparentColor = Color.Magenta;
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(58, 22);
            btnGenerate.Text = "Generate";
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnValidate
            // 
            btnValidate.ImageTransparentColor = Color.Magenta;
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(52, 22);
            btnValidate.Text = "Validate";
            btnValidate.Click += btnValidate_Click;
            // 
            // btnAddComponent
            // 
            btnAddComponent.ImageTransparentColor = Color.Magenta;
            btnAddComponent.Name = "btnAddComponent";
            btnAddComponent.Size = new Size(100, 22);
            btnAddComponent.Text = "Add Component";
            btnAddComponent.Click += btnAddComponent_Click;
            // 
            // btnDuplicateComponent
            // 
            btnDuplicateComponent.ImageTransparentColor = Color.Magenta;
            btnDuplicateComponent.Name = "btnDuplicateComponent";
            btnDuplicateComponent.Size = new Size(128, 22);
            btnDuplicateComponent.Text = "Duplicate Component";
            btnDuplicateComponent.Click += btnDuplicateComponent_Click;
            // 
            // btnDeleteComponent
            // 
            btnDeleteComponent.ImageTransparentColor = Color.Magenta;
            btnDeleteComponent.Name = "btnDeleteComponent";
            btnDeleteComponent.Size = new Size(111, 22);
            btnDeleteComponent.Text = "Delete Component";
            btnDeleteComponent.Click += btnDeleteComponent_Click;
            // 
            // btnMoveUp
            // 
            btnMoveUp.ImageTransparentColor = Color.Magenta;
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(59, 22);
            btnMoveUp.Text = "Move Up";
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // btnMoveDown
            // 
            btnMoveDown.ImageTransparentColor = Color.Magenta;
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(75, 22);
            btnMoveDown.Text = "Move Down";
            btnMoveDown.Click += btnMoveDown_Click;
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
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabStudy
            // 
            tabStudy.Controls.Add(txtNotes);
            tabStudy.Controls.Add(lblNotes);
            tabStudy.Controls.Add(txtVersion);
            tabStudy.Controls.Add(lblVersion);
            tabStudy.Controls.Add(txtPreparedBy);
            tabStudy.Controls.Add(lblPreparedBy);
            tabStudy.Controls.Add(dtStudyDate);
            tabStudy.Controls.Add(lblStudyDate);
            tabStudy.Controls.Add(txtPropertyDescription);
            tabStudy.Controls.Add(lblPropertyDescription);
            tabStudy.Controls.Add(txtAssociationName);
            tabStudy.Controls.Add(lblAssociationName);
            tabStudy.Location = new Point(4, 24);
            tabStudy.Name = "tabStudy";
            tabStudy.Padding = new Padding(3);
            tabStudy.Size = new Size(1176, 684);
            tabStudy.TabIndex = 0;
            tabStudy.Text = "Study";
            tabStudy.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(186, 260);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(406, 138);
            txtNotes.TabIndex = 11;
            txtNotes.TextChanged += txtNotes_TextChanged;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(130, 263);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(38, 15);
            lblNotes.TabIndex = 10;
            lblNotes.Text = "Notes";
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(186, 222);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(56, 23);
            txtVersion.TabIndex = 9;
            txtVersion.TextChanged += txtVersion_TextChanged;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(123, 225);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(45, 15);
            lblVersion.TabIndex = 8;
            lblVersion.Text = "Version";
            // 
            // txtPreparedBy
            // 
            txtPreparedBy.Location = new Point(186, 178);
            txtPreparedBy.Name = "txtPreparedBy";
            txtPreparedBy.Size = new Size(261, 23);
            txtPreparedBy.TabIndex = 7;
            txtPreparedBy.TextChanged += txtPreparedBy_TextChanged;
            // 
            // lblPreparedBy
            // 
            lblPreparedBy.AutoSize = true;
            lblPreparedBy.Location = new Point(98, 181);
            lblPreparedBy.Name = "lblPreparedBy";
            lblPreparedBy.Size = new Size(70, 15);
            lblPreparedBy.TabIndex = 6;
            lblPreparedBy.Text = "Prepared By";
            // 
            // dtStudyDate
            // 
            dtStudyDate.Format = DateTimePickerFormat.Short;
            dtStudyDate.Location = new Point(186, 139);
            dtStudyDate.Name = "dtStudyDate";
            dtStudyDate.Size = new Size(100, 23);
            dtStudyDate.TabIndex = 5;
            dtStudyDate.ValueChanged += dtStudyDate_ValueChanged;
            // 
            // lblStudyDate
            // 
            lblStudyDate.AutoSize = true;
            lblStudyDate.Location = new Point(104, 145);
            lblStudyDate.Name = "lblStudyDate";
            lblStudyDate.Size = new Size(64, 15);
            lblStudyDate.TabIndex = 4;
            lblStudyDate.Text = "Study Date";
            // 
            // txtPropertyDescription
            // 
            txtPropertyDescription.Location = new Point(186, 67);
            txtPropertyDescription.Multiline = true;
            txtPropertyDescription.Name = "txtPropertyDescription";
            txtPropertyDescription.Size = new Size(227, 66);
            txtPropertyDescription.TabIndex = 3;
            txtPropertyDescription.TextChanged += txtPropertyDescription_TextChanged;
            // 
            // lblPropertyDescription
            // 
            lblPropertyDescription.AutoSize = true;
            lblPropertyDescription.Location = new Point(53, 70);
            lblPropertyDescription.Name = "lblPropertyDescription";
            lblPropertyDescription.Size = new Size(115, 15);
            lblPropertyDescription.TabIndex = 2;
            lblPropertyDescription.Text = "Property Description";
            // 
            // txtAssociationName
            // 
            txtAssociationName.Location = new Point(186, 25);
            txtAssociationName.Name = "txtAssociationName";
            txtAssociationName.Size = new Size(261, 23);
            txtAssociationName.TabIndex = 1;
            txtAssociationName.TextChanged += txtAssociationName_TextChanged;
            // 
            // lblAssociationName
            // 
            lblAssociationName.AutoSize = true;
            lblAssociationName.Location = new Point(65, 28);
            lblAssociationName.Name = "lblAssociationName";
            lblAssociationName.Size = new Size(103, 15);
            lblAssociationName.TabIndex = 0;
            lblAssociationName.Text = "Association Name";
            lblAssociationName.Click += lblAssociationName_Click;
            // 
            // tabSettings
            // 
            tabSettings.Controls.Add(cboAllocationMethod);
            tabSettings.Controls.Add(lblAllocationMethod);
            tabSettings.Controls.Add(nudInflationRate);
            tabSettings.Controls.Add(lblInflationRate);
            tabSettings.Controls.Add(nudInterestRate);
            tabSettings.Controls.Add(lblInterestRate);
            tabSettings.Controls.Add(nudBeginningReservePool);
            tabSettings.Controls.Add(lblBeginReservePool);
            tabSettings.Controls.Add(nudUnitCount);
            tabSettings.Controls.Add(lblUnitCount);
            tabSettings.Controls.Add(lblCurrentYear);
            tabSettings.Controls.Add(nudCurrentYear);
            tabSettings.Location = new Point(4, 24);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new Padding(3);
            tabSettings.Size = new Size(1176, 684);
            tabSettings.TabIndex = 1;
            tabSettings.Text = "Settings";
            tabSettings.UseVisualStyleBackColor = true;
            // 
            // cboAllocationMethod
            // 
            cboAllocationMethod.FormattingEnabled = true;
            cboAllocationMethod.Location = new Point(271, 272);
            cboAllocationMethod.Name = "cboAllocationMethod";
            cboAllocationMethod.Size = new Size(185, 23);
            cboAllocationMethod.TabIndex = 11;
            cboAllocationMethod.SelectedIndexChanged += cboAllocationMethod_SelectedIndexChanged;
            // 
            // lblAllocationMethod
            // 
            lblAllocationMethod.AutoSize = true;
            lblAllocationMethod.Location = new Point(144, 279);
            lblAllocationMethod.Name = "lblAllocationMethod";
            lblAllocationMethod.Size = new Size(106, 15);
            lblAllocationMethod.TabIndex = 10;
            lblAllocationMethod.Text = "Allocation Method";
            // 
            // nudInflationRate
            // 
            nudInflationRate.Location = new Point(271, 226);
            nudInflationRate.Name = "nudInflationRate";
            nudInflationRate.Size = new Size(79, 23);
            nudInflationRate.TabIndex = 9;
            nudInflationRate.ValueChanged += nudInflationRate_ValueChanged;
            // 
            // lblInflationRate
            // 
            lblInflationRate.AutoSize = true;
            lblInflationRate.Location = new Point(173, 232);
            lblInflationRate.Name = "lblInflationRate";
            lblInflationRate.Size = new Size(77, 15);
            lblInflationRate.TabIndex = 8;
            lblInflationRate.Text = "Inflation Rate";
            // 
            // nudInterestRate
            // 
            nudInterestRate.Location = new Point(271, 180);
            nudInterestRate.Name = "nudInterestRate";
            nudInterestRate.Size = new Size(79, 23);
            nudInterestRate.TabIndex = 7;
            nudInterestRate.ValueChanged += nudInterestRate_ValueChanged;
            // 
            // lblInterestRate
            // 
            lblInterestRate.AutoSize = true;
            lblInterestRate.Location = new Point(178, 185);
            lblInterestRate.Name = "lblInterestRate";
            lblInterestRate.Size = new Size(72, 15);
            lblInterestRate.TabIndex = 6;
            lblInterestRate.Text = "Interest Rate";
            // 
            // nudBeginningReservePool
            // 
            nudBeginningReservePool.Location = new Point(271, 134);
            nudBeginningReservePool.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudBeginningReservePool.Name = "nudBeginningReservePool";
            nudBeginningReservePool.Size = new Size(79, 23);
            nudBeginningReservePool.TabIndex = 5;
            nudBeginningReservePool.ValueChanged += nudBeginningReservePool_ValueChanged;
            // 
            // lblBeginReservePool
            // 
            lblBeginReservePool.AutoSize = true;
            lblBeginReservePool.Location = new Point(119, 136);
            lblBeginReservePool.Name = "lblBeginReservePool";
            lblBeginReservePool.Size = new Size(131, 15);
            lblBeginReservePool.TabIndex = 4;
            lblBeginReservePool.Text = "Beginning Reserve Pool";
            // 
            // nudUnitCount
            // 
            nudUnitCount.Location = new Point(271, 88);
            nudUnitCount.Name = "nudUnitCount";
            nudUnitCount.Size = new Size(79, 23);
            nudUnitCount.TabIndex = 3;
            nudUnitCount.ValueChanged += nudUnitCount_ValueChanged;
            // 
            // lblUnitCount
            // 
            lblUnitCount.AutoSize = true;
            lblUnitCount.Location = new Point(185, 91);
            lblUnitCount.Name = "lblUnitCount";
            lblUnitCount.Size = new Size(65, 15);
            lblUnitCount.TabIndex = 2;
            lblUnitCount.Text = "Unit Count";
            // 
            // lblCurrentYear
            // 
            lblCurrentYear.AutoSize = true;
            lblCurrentYear.Location = new Point(178, 44);
            lblCurrentYear.Name = "lblCurrentYear";
            lblCurrentYear.Size = new Size(72, 15);
            lblCurrentYear.TabIndex = 1;
            lblCurrentYear.Text = "Current Year";
            // 
            // nudCurrentYear
            // 
            nudCurrentYear.Location = new Point(271, 42);
            nudCurrentYear.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudCurrentYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudCurrentYear.Name = "nudCurrentYear";
            nudCurrentYear.Size = new Size(79, 23);
            nudCurrentYear.TabIndex = 0;
            nudCurrentYear.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            nudCurrentYear.ValueChanged += nudCurrentYear_ValueChanged;
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
            dgvComponents.CellContentClick += dgvComponents_CellContentClick;
            dgvComponents.CellValueChanged += dgvComponents_CellValueChanged;
            dgvComponents.CurrentCellDirtyStateChanged += dgvComponents_CurrentCellDirtyStateChanged;
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
            lblSpacer.Size = new Size(1044, 17);
            lblSpacer.Spring = true;
            // 
            // lblFile
            // 
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(86, 17);
            lblFile.Text = "No File Loaded";
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
            FormClosing += MainForm_FormClosing;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            tabControl.ResumeLayout(false);
            tabStudy.ResumeLayout(false);
            tabStudy.PerformLayout();
            tabSettings.ResumeLayout(false);
            tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudInflationRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudInterestRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudBeginningReservePool).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCurrentYear).EndInit();
            tabComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvComponents).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
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
        private TextBox txtVersion;
        private Label lblVersion;
        private TextBox txtPreparedBy;
        private Label lblPreparedBy;
        private DateTimePicker dtStudyDate;
        private Label lblStudyDate;
        private TextBox txtPropertyDescription;
        private Label lblPropertyDescription;
        private TextBox txtAssociationName;
        private Label lblAssociationName;
        private TextBox txtNotes;
        private Label lblNotes;
        private Label lblCurrentYear;
        private NumericUpDown nudCurrentYear;
        private ComboBox cboAllocationMethod;
        private Label lblAllocationMethod;
        private NumericUpDown nudInflationRate;
        private Label lblInflationRate;
        private NumericUpDown nudInterestRate;
        private Label lblInterestRate;
        private NumericUpDown nudBeginningReservePool;
        private Label lblBeginReservePool;
        private NumericUpDown nudUnitCount;
        private Label lblUnitCount;
        private ToolStripButton btnAddComponent;
        private ToolStripButton btnDuplicateComponent;
        private ToolStripButton btnDeleteComponent;
        private ToolStripButton btnMoveUp;
        private ToolStripButton btnMoveDown;
    }
}
