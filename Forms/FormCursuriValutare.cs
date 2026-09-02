using System;
using System.Windows.Forms;
using CasaSchimbValutar.Models;
using CasaSchimbValutar.Repositories;

namespace CasaSchimbValutar.Forms
{
    public partial class FormCursuriValutare : Form
    {
        private readonly CursValutarRepository _repository = new CursValutarRepository();

        public FormCursuriValutare()
        {
            InitializeComponent();
            ConfigureazaListView();
            RefreshLista();
        }

        private void ConfigureazaListView()
        {
            lvCursuri.View = View.Details;
            lvCursuri.FullRowSelect = true;
            lvCursuri.MultiSelect = false;
            lvCursuri.GridLines = true;

            var w = lvCursuri.ClientSize.Width;
            lvCursuri.Columns.Add("Valuta", (int)(w * 0.25), HorizontalAlignment.Left);
            lvCursuri.Columns.Add("Data", (int)(w * 0.35), HorizontalAlignment.Center);
            lvCursuri.Columns.Add("Curs (RON)", (int)(w * 0.40), HorizontalAlignment.Right);
        }

        private void RefreshLista()
        {
            lvCursuri.Items.Clear();
            foreach (var c in _repository.GetAll())
            {
                var item = new ListViewItem(c.CodValuta);
                item.SubItems.Add(c.DataCurs.ToString("dd.MM.yyyy"));
                item.SubItems.Add(c.CursLaRON.ToString("F4"));
                item.Tag = c;
                lvCursuri.Items.Add(item);
            }
        }

        private void lvCursuri_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esteSelectat = lvCursuri.SelectedItems.Count > 0;
            btnEditeaza.Enabled = esteSelectat;
            btnSterge.Enabled = esteSelectat;
        }

        private void btnAdauga_Click_1(object sender, EventArgs e)
        {
            using (var form = new FormCursValutar())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshLista();
            }
        }

        private void btnEditeaza_Click_1(object sender, EventArgs e)
        {
            var curs = lvCursuri.SelectedItems[0].Tag as CursValutar;
            using (var form = new FormCursValutar(curs))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshLista();
            }
        }

        private void btnSterge_Click_1(object sender, EventArgs e)
        {
            var curs = lvCursuri.SelectedItems[0].Tag as CursValutar;
            if (MessageBox.Show(
                $"Ștergi cursul din {curs.DataCurs:dd.MM.yyyy} pentru {curs.CodValuta}?",
                "Confirmare ștergere",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _repository.Delete(curs.Id);
                RefreshLista();
            }
        }


    }
}