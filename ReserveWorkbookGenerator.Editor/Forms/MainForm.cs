using Microsoft.VisualBasic;
using ReserveWorkbookGenerator.Editor.State;

namespace ReserveWorkbookGenerator.Editor
{
    public partial class MainForm : Form
    {
        private readonly EditorState _state = new();
        public string DisplayName =>
            string.IsNullOrWhiteSpace(_state.DisplayName)
                ? "Untitled"
                : Path.GetFileName(_state.DisplayName);
        public MainForm()
        {
            InitializeComponent();
            UpdateWindowTitle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Open");
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Save");
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

        private void UpdateWindowTitle()
        {
            var dirty = _state.IsDirty ? "*" : "";

            Text = $"Reserve Study Editor - {dirty}{_state.DisplayName}";
        }
    }
}
