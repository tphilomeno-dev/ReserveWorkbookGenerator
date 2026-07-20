using Microsoft.VisualBasic;
using ReserveWorkbookGenerator.Editor.Services;
using ReserveWorkbookGenerator.Editor.State;
using ReserveWorkbookGenerator.Models;
using System.ComponentModel;

namespace ReserveWorkbookGenerator.Editor
{
    public partial class MainForm : Form
    {
        #region Fields
        private readonly EditorState _state = new();
        private readonly StudyFileService _studyFileService = new();

        public string DisplayName =>
            string.IsNullOrWhiteSpace(_state.DisplayName)
                ? "Untitled"
                : Path.GetFileName(_state.DisplayName);
        #endregion
        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            RefreshUi();
            dgvComponents.AutoGenerateColumns = false;

            InitializeComponentGrid();
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region File Menu Handlers
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenStudy();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            SaveStudy();
        }
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Save As");
        }

        private void mnuFileGenerate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Generate");
        }
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Click");
        }
        private void mnuStudyValidate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Validate Click");
        }
        private void mnuStudyStats_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stats Click");
        }
        private void mnuToolsOptions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Options Click");
        }
        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About Click");
        }
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Toolbar Button Handlers
        private void btnNew_Click(object sender, EventArgs e)
        {
            mnuFileOpen_Click(sender, e);
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            mnuFileOpen_Click(sender, e);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            mnuFileSave_Click(sender, e);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            mnuFileGenerate_Click(sender, e);
        }
        private void btnValidate_Click(object sender, EventArgs e)
        {
            mnuStudyValidate_Click(sender, e);
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About Click");
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help Click");
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings Click");
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Refresh Click");
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clear Click");
        }
        #endregion
        private void UpdateWindowTitle()
        {
            var dirty = _state.IsDirty ? "*" : "";

            Text = $"Reserve Study Editor - {dirty}{_state.DisplayName}";
        }
        private void OpenStudy()
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Open Reserve Study",
                Filter = "Reserve Study (*.json)|*.json|All Files (*.*)|*.*",
                DefaultExt = "json",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var study = _studyFileService.Load(dialog.FileName);

                SetCurrentStudy(study, dialog.FileName);

                //MessageBox.Show(
                //    this,
                //    $"Successfully loaded '{_state.DisplayName}'.\n\n" +
                //    $"Components: {study.Components.Count}",
                //    "Reserve Study Loaded",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Error Opening Study",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void SetCurrentStudy(ReserveStudy study, string fileName)
        {
            _state.Study = study;
            _state.FileName = fileName;
            _state.IsDirty = false;

            RefreshUi();
            lblStatus.Text = $"Loaded {study.Components.Count} components.";
            lblFile.Text = _state.DisplayName;
            RefreshComponentGrid();
        }
        private void InitializeComponentGrid()
        {
            dgvComponents.Columns.Clear();

            dgvComponents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 60,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvComponents.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "colType",
                HeaderText = "Type",
                DataPropertyName = "Type",
                DataSource = Enum.GetValues<ReserveType>(),
                Width = 90
            });

            dgvComponents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                HeaderText = "Category",
                DataPropertyName = "Category",
                Width = 140
            });

            dgvComponents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Name",
                DataPropertyName = "Name",
                Width = 240
            });

            dgvComponents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLastReplaced",
                HeaderText = "Last Replaced",
                DataPropertyName = "LastReplaced",
                Width = 90,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvComponents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUsefulLife",
                HeaderText = "Useful Life",
                DataPropertyName = "UsefulLife",
                Width = 90,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvComponents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRemainingLife",
                HeaderText = "Remaining Life",
                DataPropertyName = "RemainingLife",
                Width = 110,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvComponents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colReplacementCost",
                HeaderText = "Replacement Cost",
                DataPropertyName = "ReplacementCost",
                Width = 120,
                DefaultCellStyle =
        {
            Format = "C0",
            Alignment = DataGridViewContentAlignment.MiddleRight
        }
            });

            dgvComponents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colComments",
                HeaderText = "Comments",
                DataPropertyName = "Comments",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

        }
        private void RefreshComponentGrid()
        {
            if (_state.Study == null)
            {
                dgvComponents.DataSource = null;
                return;
            }

            dgvComponents.DataSource = new BindingList<ReserveComponent>(
                _state.Study.Components);
        }
        private void SaveStudy()
        {
            if (!_state.HasStudy)
                return;

            _studyFileService.Save(_state.FileName!, _state.Study!);

            _state.IsDirty = false;

            RefreshUi();

            lblStatus.Text = "Study saved.";
        }
        private void dgvComponents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_state.HasStudy)
                return;

            _state.IsDirty = true;

            RefreshUi();

            lblStatus.Text = "Study modified.";

            
        }
        private void dgvComponents_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvComponents.IsCurrentCellDirty)
            {
                dgvComponents.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void UpdateSaveState()
        {
            bool canSave = _state.HasStudy && _state.IsDirty;

            mnuFileSave.Enabled = canSave;
            btnSave.Enabled = canSave;
        }
        private void RefreshUi()
        {
            UpdateWindowTitle();
            UpdateSaveState();
        }
    }
}
    
