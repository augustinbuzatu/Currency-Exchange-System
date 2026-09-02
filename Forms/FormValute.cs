using System;
using System.Windows.Forms;
using CasaSchimbValutar.Models;
using CasaSchimbValutar.Repositories;

namespace CasaSchimbValutar.Forms
{
    public partial class FormValute : Form
    {
        private readonly ValutaRepository _repository = new ValutaRepository();

        public FormValute()
        {
            InitializeComponent();
            ConfigureazaListView();
            RefreshLista();
        }

        private void ConfigureazaListView()
        {
            lvValute.View = View.Details;
            lvValute.FullRowSelect = true;
            lvValute.MultiSelect = false;
            lvValute.GridLines = true;

            var w = lvValute.ClientSize.Width;
            lvValute.Columns.Add("Cod", (int)(w * 0.2), HorizontalAlignment.Left);
            lvValute.Columns.Add("Nume", (int)(w * 0.55), HorizontalAlignment.Left);
            lvValute.Columns.Add("Simbol", (int)(w * 0.25), HorizontalAlignment.Center);
        }

        private void RefreshLista()
        {
            lvValute.Items.Clear();
            foreach (var v in _repository.GetAll())
            {
                var item = new ListViewItem(v.Cod);
                item.SubItems.Add(v.Nume);
                item.SubItems.Add(v.Simbol);
                item.Tag = v;
                lvValute.Items.Add(item);
            }
        }

        private void lvValute_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esteSelectat = lvValute.SelectedItems.Count > 0;
            btnEditeaza.Enabled = esteSelectat;
            btnSterge.Enabled = esteSelectat;
        }

        private void btnAdauga_Click_1(object sender, EventArgs e)
        {
            using (var form = new FormValuta())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshLista();
            }
        }

        private void btnEditeaza_Click_1(object sender, EventArgs e)
        {
            var valuta = lvValute.SelectedItems[0].Tag as Valuta;
            using (var form = new FormValuta(valuta))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshLista();
            }
        }

        private void btnSterge_Click_1(object sender, EventArgs e)
        {
            var valuta = lvValute.SelectedItems[0].Tag as Valuta;
            if (MessageBox.Show(
                $"Ești sigur că vrei să ștergi valuta {valuta.Cod} - {valuta.Nume}?",
                "Confirmare ștergere",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _repository.Delete(valuta.Id);
                RefreshLista();
            }
        }


    }
}