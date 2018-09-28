using KontrahenciV2.Model;
using System.Windows.Forms;

namespace KontrahenciV2.ModelForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonNowyKontrahent_Click(object sender, System.EventArgs e)
        {
            FormNowyKontrah  form = new FormNowyKontrah();
            form.ShowDialog();
        }
    }
}
