using ReserveWorkbookGenerator.Editor.Validation;

namespace ReserveWorkbookGenerator.Editor.Forms;

public partial class ValidationResultsForm : Form
{
    public ValidationResultsForm(IEnumerable<ValidationResult> results)
    {
        InitializeComponent();

        foreach (var result in results)
        {
            lstResults.Items.Add(result.Message);
        }
    }
}