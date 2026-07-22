using Microsoft.VisualBasic;
using ReserveWorkbookGenerator.Editor.Forms;
using ReserveWorkbookGenerator.Editor.Helpers;
using ReserveWorkbookGenerator.Editor.Services;
using ReserveWorkbookGenerator.Editor.State;
using ReserveWorkbookGenerator.Editor.Validation;
using ReserveWorkbookGenerator.Models;
using System.ComponentModel;
using System.Diagnostics;

namespace ReserveWorkbookGenerator.Editor
{
    public partial class MainForm : Form
    {
        #region Fields
        private readonly EditorState _state = new();
        private readonly StudyFileService _studyFileService = new();
        private readonly WorkbookGenerator _workbookGenerator;

        private readonly ToolStripItem[] _studyTools;
        private readonly ToolStripItem[] _componentTools;

        public string DisplayName =>
            string.IsNullOrWhiteSpace(_state.DisplayName)
                ? "Untitled"
                : Path.GetFileName(_state.DisplayName);
        private bool _loadingStudy;
        #endregion
        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            RefreshUi();
            dgvComponents.AutoGenerateColumns = false;

            var methods = Enum
                .GetValues<AllocationMethod>()
                .Select(m => new
                {
                    Value = m,
                    Text = EnumHelper.GetDescription(m)
                })
                .ToList();

            cboAllocationMethod.DisplayMember = "Text";
            cboAllocationMethod.ValueMember = "Value";
            cboAllocationMethod.DataSource = methods;
            _workbookGenerator = new WorkbookGenerator();
            InitializeComponentGrid();

            _studyTools =
                [
                    btnValidate,
                    btnGenerate,
                    sepToolStripMenuItem
                ];

            _componentTools =
            [
                btnAddComponent,
                btnDuplicateComponent,
                btnDeleteComponent,
                btnMoveUp,
                btnMoveDown,
                sepToolStripMenuItem1
            ];
            UpdateToolbar();

        }
        #endregion

        #region File Menu Handlers
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (!CheckForUnsavedChanges())
                return;

            OpenStudy();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            SaveStudy();
        }
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void mnuFileGenerate_Click(object sender, EventArgs e)
        {
            GenerateWorkbook();
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
            RefreshSettingsTab();
            RefreshComponentGrid();
            RefreshStudyTab();
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
        private void RefreshComponentGrid(ReserveComponent? selectedComponent = null)
        {
            if (_state.Study == null)
            {
                dgvComponents.DataSource = null;
                return;
            }

            dgvComponents.DataSource = new BindingList<ReserveComponent>(
                _state.Study.Components);

            if (selectedComponent == null)
                return;

            foreach (DataGridViewRow row in dgvComponents.Rows)
            {
                if (ReferenceEquals(row.DataBoundItem, selectedComponent))
                {
                    row.Selected = true;
                    dgvComponents.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
        private bool SaveStudy()
        {
            if (!_state.HasStudy)
                return false;

            _studyFileService.Save(_state.FileName!, _state.Study!);

            _state.IsDirty = false;

            RefreshUi();

            lblStatus.Text = "Study saved.";
            return true;
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
            lblFile.Text = _state.DisplayName;
        }

        private void lblAssociationName_Click(object sender, EventArgs e)
        {

        }
        private void RefreshStudyTab()
        {
            _loadingStudy = true;

            try
            {
                if (!_state.HasStudy)
                {
                    txtAssociationName.Text = "";
                    txtPropertyDescription.Text = "";
                    dtStudyDate.Value = DateTime.Today;
                    txtPreparedBy.Text = "";
                    txtVersion.Text = "";
                    txtNotes.Text = "";
                    return;
                }

                var study = _state.Study!.Study;

                txtAssociationName.Text = study.AssociationName;
                txtPropertyDescription.Text = study.PropertyDescription;
                dtStudyDate.Value = study.StudyDate.ToDateTime(TimeOnly.MinValue);
                txtPreparedBy.Text = study.PreparedBy;
                txtVersion.Text = study.Version;
                txtNotes.Text = study.Notes;
            }
            finally
            {
                _loadingStudy = false;
            }
        }
        private void MarkStudyDirty()
        {
            if (!_state.HasStudy || _loadingStudy)
                return;

            _state.IsDirty = true;

            RefreshUi();

            lblStatus.Text = "Study modified.";
        }

        private void txtAssociationName_TextChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy)
                return;

            _state.Study!.Study.AssociationName = txtAssociationName.Text;

            MarkStudyDirty();
        }

        private void txtPropertyDescription_TextChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy)
                return;

            _state.Study!.Study.PropertyDescription =
                txtPropertyDescription.Text;

            MarkStudyDirty();
        }

        private void txtPreparedBy_TextChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy)
                return;

            _state.Study!.Study.PreparedBy =
                txtPreparedBy.Text;


            MarkStudyDirty();
        }

        private void txtVersion_TextChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy)
                return;

            _state.Study!.Study.Version =
                txtVersion.Text;

            MarkStudyDirty();
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy)
                return;

            _state.Study!.Study.Notes =
                txtNotes.Text;

            MarkStudyDirty();
        }

        private void dtStudyDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy)
                return;

            _state.Study!.Study.StudyDate =
                DateOnly.FromDateTime(dtStudyDate.Value);

            MarkStudyDirty();
        }
        private void RefreshSettingsTab()
        {
            _loadingStudy = true;

            try
            {
                if (!_state.HasStudy)
                {
                    nudCurrentYear.Value = DateTime.Now.Year;
                    nudUnitCount.Value = 1;
                    nudBeginningReservePool.Value = 0;
                    nudInterestRate.Value = 0;
                    nudInflationRate.Value = 0;
                    cboAllocationMethod.SelectedIndex = -1;
                    return;
                }

                var settings = _state.Study!.Settings;

                nudCurrentYear.Value = settings.CurrentYear;
                nudUnitCount.Value = settings.UnitCount;
                nudBeginningReservePool.Value = settings.BeginningReservePool;
                nudInterestRate.Value = settings.InterestRate;
                nudInflationRate.Value = settings.InflationRate;
                cboAllocationMethod.SelectedValue = settings.AllocationMethod;
            }
            finally
            {
                _loadingStudy = false;
            }
        }

        private void nudCurrentYear_ValueChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy || _loadingStudy)
                return;

            _state.Study!.Settings.CurrentYear = (int)nudCurrentYear.Value;

            MarkStudyDirty();
        }

        private void nudUnitCount_ValueChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy || _loadingStudy)
                return;

            _state.Study!.Settings.UnitCount = (int)nudUnitCount.Value;

            MarkStudyDirty();
        }

        private void nudBeginningReservePool_ValueChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy || _loadingStudy)
                return;

            _state.Study!.Settings.BeginningReservePool =
                nudBeginningReservePool.Value;

            MarkStudyDirty();
        }

        private void nudInterestRate_ValueChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy || _loadingStudy)
                return;

            _state.Study!.Settings.InterestRate =
                nudInterestRate.Value;

            MarkStudyDirty();
        }

        private void nudInflationRate_ValueChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy || _loadingStudy)
                return;

            _state.Study!.Settings.InflationRate =
                nudInflationRate.Value;

            MarkStudyDirty();
        }

        private void cboAllocationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_state.HasStudy || _loadingStudy)
                return;

            if (cboAllocationMethod.SelectedValue is AllocationMethod method)
            {
                _state.Study!.Settings.AllocationMethod = method;

                MarkStudyDirty();
            }
        }
        private bool CheckForUnsavedChanges()
        {
            if (!_state.IsDirty)
                return true;

            var result = MessageBox.Show(
                "The current study has unsaved changes.\n\nDo you want to save your changes?",
                "Unsaved Changes",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            return result switch
            {
                DialogResult.Yes => Save(),
                DialogResult.No => true,
                _ => false
            };
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckForUnsavedChanges())
                e.Cancel = true;
        }
        private bool Save()
        {
            return SaveStudy(_state.FileName);
        }

        private bool SaveAs()
        {
            using var dialog = new SaveFileDialog();

            dialog.Filter = "Reserve Studies (*.json)|*.json";
            dialog.FileName = Path.GetFileName(_state.FileName);

            if (dialog.ShowDialog() != DialogResult.OK)
                return false;

            _state.FileName = dialog.FileName;

            return SaveStudy(dialog.FileName);
        }

        private bool SaveStudy(string fileName)
        {
            try
            {
                _studyFileService.Save(fileName, _state.Study!);

                _state.FileName = fileName;

                _state.IsDirty = false;

                RefreshUi();

                lblStatus.Text = $"Saved {Path.GetFileName(fileName)} at {DateTime.Now:t}";

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private void GenerateWorkbook()
        {
            if (!_state.HasStudy)
            {
                MessageBox.Show(
                    "No study is currently open.",
                    "Generate Workbook",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            //if (!ValidateStudy())
            //    return;

            using var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                Title = "Save Reserve Workbook",
                FileName = $"{_state.Study!.Study.AssociationName} Reserve Workbook.xlsx"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                var validator = new StudyValidator();

                var results = validator.Validate(_state.Study!);

                if (results.Any())
                {
                    using (var dialog = new ValidationResultsForm(results))
                    {
                        dialog.ShowDialog(this);
                    }

                    return;
                }


                try
                {
                    string outputFile = _workbookGenerator.Generate(
                                        _state.Study!,
                                        saveFileDialog.FileName);
                    lblStatus.Text = "Workbook generated.";

                    Process.Start(new ProcessStartInfo(outputFile)
                    {
                        UseShellExecute = true
                    });

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



                
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Generate Workbook",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void SetVisible(IEnumerable<ToolStripItem> items, bool visible)
        {
            foreach (var item in items)
                item.Visible = visible;
        }
        private void UpdateToolbar()
        {
            SetVisible(_studyTools, tabControl.SelectedTab == tabStudy);
            SetVisible(_componentTools, tabControl.SelectedTab == tabComponents);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateToolbar();
        }

        private void tsbDuplicateComponent_Click(object sender, EventArgs e)
        {
            DuplicateSelectedComponent();
        }
        private void DuplicateSelectedComponent()
        {
            if (!_state.HasStudy)
                return;

            if (dgvComponents.CurrentRow == null)
                return;

            var selectedComponent = GetSelectedComponent();

            if (selectedComponent == null)
                return;

            var copy = new ReserveComponent
            {
                Id = GetNextComponentId(),

                Type = selectedComponent.Type,
                Category = selectedComponent.Category,
                Name = selectedComponent.Name,

                LastReplaced = selectedComponent.LastReplaced,
                UsefulLife = selectedComponent.UsefulLife,
                RemainingLife = selectedComponent.RemainingLife,

                ReplacementCost = selectedComponent.ReplacementCost,

                Comments = selectedComponent.Comments
            };

            int index = _state.Study.Components.IndexOf(selectedComponent);

            _state.Study.Components.Insert(index + 1, copy);

            _state.IsDirty = true;

            RefreshComponentGrid();

            lblStatus.Text = "Component duplicated.";
        }

        private void dgvComponents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDuplicateComponent_Click(object sender, EventArgs e)
        {
            DuplicateSelectedComponent();
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            AddComponent();
        }
        private void AddComponent()
        {
            if (!_state.HasStudy)
                return;

            var component = new ReserveComponent
            {
                Id = GetNextComponentId(),
                Type = ReserveType.NonSirs,

                Category = string.Empty,
                Name = "New Component",

                LastReplaced = _state.Study.Settings.CurrentYear,

                UsefulLife = 1,
                RemainingLife = 1,

                ReplacementCost = 0m,

                Comments = string.Empty
            };

            _state.Study.Components.Add(component);

            _state.IsDirty = true;

            RefreshComponentGrid();

            lblStatus.Text = "Component added.";
        }
        private int GetNextComponentId()
        {
            return _state.Study!.Components.Any()
                ? _state.Study.Components.Max(c => c.Id) + 1
                : 1;
        }

        private void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            DeleteSelectedComponent();
        }
        private void DeleteSelectedComponent()
        {
            if (!_state.HasStudy)
                return;

            if (dgvComponents.CurrentRow == null)
                return;

            var selectedComponent = GetSelectedComponent();

            if (selectedComponent == null)
                return;

            var result = MessageBox.Show(
                $"Delete '{selectedComponent.Name}'?",
                "Delete Component",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            int index = _state.Study!.Components.IndexOf(selectedComponent);

            ReserveComponent? nextSelection = null;

            if (_state.Study.Components.Count > 1)
            {
                if (index < _state.Study.Components.Count - 1)
                    nextSelection = _state.Study.Components[index + 1];
                else
                    nextSelection = _state.Study.Components[index - 1];
            }

            _state.Study.Components.Remove(selectedComponent);

            _state.IsDirty = true;

            RefreshComponentGrid();

            lblStatus.Text = "Component deleted.";
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveSelectedComponent(-1);
        }
        private void MoveSelectedComponent(int direction)
        {
            if (!_state.HasStudy)
                return;

            var selectedComponent = GetSelectedComponent();

            if (selectedComponent == null)
                return;

            var components = _state.Study!.Components;

            int index = components.IndexOf(selectedComponent);

            int newIndex = index + direction;

            if (newIndex < 0 || newIndex >= components.Count)
                return;

            components.RemoveAt(index);

            components.Insert(newIndex, selectedComponent);

            _state.IsDirty = true;

            RefreshComponentGrid();

            lblStatus.Text = direction < 0
                ? "Component moved up."
                : "Component moved down.";
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveSelectedComponent(1);
        }
        private ReserveComponent? GetSelectedComponent()
        {
            return dgvComponents.CurrentRow?.DataBoundItem as ReserveComponent;
        }
    }
}


