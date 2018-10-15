using KontrahenciV2.Model;
using System;
using System.Windows.Forms;

namespace KontrahenciV2.ModelForm
{
    public partial class FormMain : Form
    {
        private Polaczenie _polaczenie = new Polaczenie();

        public FormMain()
        {
            InitializeComponent();
            AktualizujListeKontrahentow();
        }

        private void AktualizujListeKontrahentow()
        {
            GridGlowny.DataSource = _polaczenie.PobierzListeKontrahentow();
            UstawWidokGrida();
        }

        private void UstawWidokGrida()
        {
            for (int i = 0; i < GridGlowny.Columns.Count; i++)
            {
                GridGlowny.Columns[i].Visible = false;
            }
            GridGlowny.Columns["Nazwa"].Visible = true;
            GridGlowny.Columns["NazwaSkrocona"].Visible = true;
            GridGlowny.Columns["Nip"].Visible = true;
            GridGlowny.Columns["Regon"].Visible = true;
            GridGlowny.Columns["Email"].Visible = true;
            GridGlowny.Columns["Telefon"].Visible = true;
            GridGlowny.Columns["Status"].Visible = true;
        }

        private void ButtonNowyKontrahent_Click(object sender, System.EventArgs e)
        {
            FormKontrah  form = new FormKontrah();
            form.ShowDialog();
            AktualizujListeKontrahentow();
        }

        private void GridGlowny_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Int32.Parse(GridGlowny.SelectedRows[0].Cells["Id"].Value.ToString());
            FormKontrah form = new FormKontrah(id);
            form.ShowDialog();
            AktualizujListeKontrahentow();
        }

        private void ButtonUsunKontrahenta_Click(object sender, EventArgs e)
        {
            var id = Int32.Parse(GridGlowny.SelectedRows[0].Cells["Id"].Value.ToString());
            _polaczenie.UsunKontrahenta(id);
            AktualizujListeKontrahentow();
        }
    }
}
