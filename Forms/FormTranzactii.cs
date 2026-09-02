using System;
using System.Windows.Forms;
using CasaSchimbValutar.Models;
using CasaSchimbValutar.Repositories;

namespace CasaSchimbValutar.Forms
{
    public partial class FormTranzactii : Form
    {
        private readonly TranzactieRepository _repository = new TranzactieRepository();

        public FormTranzactii()
        {
            InitializeComponent();
            ConfigureazaListView();
            RefreshLista();
        }

        private void ConfigureazaListView()
        {
            lvTranzactii.View = View.Details;
            lvTranzactii.FullRowSelect = true;
            lvTranzactii.MultiSelect = false;
            lvTranzactii.GridLines = true;

            var w = lvTranzactii.ClientSize.Width;
            lvTranzactii.Columns.Add("Valuta", (int)(w * 0.12), HorizontalAlignment.Left);
            lvTranzactii.Columns.Add("Tip", (int)(w * 0.15), HorizontalAlignment.Left);
            lvTranzactii.Columns.Add("Suma valuta", (int)(w * 0.18), HorizontalAlignment.Right);
            lvTranzactii.Columns.Add("Curs", (int)(w * 0.15), HorizontalAlignment.Right);
            lvTranzactii.Columns.Add("Suma RON", (int)(w * 0.18), HorizontalAlignment.Right);
            lvTranzactii.Columns.Add("Data", (int)(w * 0.22), HorizontalAlignment.Center);
        }

        private void RefreshLista()
        {
            lvTranzactii.Items.Clear();
            foreach (var t in _repository.GetAll())
            {
                var item = new ListViewItem(t.CodValuta);
                item.SubItems.Add(t.Tip.ToString());
                item.SubItems.Add(t.SumaValuta.ToString("F2"));
                item.SubItems.Add(t.CursUtilizat.ToString("F4"));
                item.SubItems.Add(t.SumaRON.ToString("F2"));
                item.SubItems.Add(t.DataTranzactie.ToString("dd.MM.yyyy HH:mm"));
                item.Tag = t;
                lvTranzactii.Items.Add(item);
            }
        }

        private void lvTranzactii_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esteSelectat = lvTranzactii.SelectedItems.Count > 0;
            btnEditeaza.Enabled = esteSelectat;
            btnSterge.Enabled = esteSelectat;
        }

        private void btnAdauga_Click_1(object sender, EventArgs e)
        {
            using (var form = new FormTranzactie())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshLista();
            }
        }

        private void btnEditeaza_Click_1(object sender, EventArgs e)
        {
            var tranzactie = lvTranzactii.SelectedItems[0].Tag as Tranzactie;
            using (var form = new FormTranzactie(tranzactie))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshLista();
            }
        }

        private void btnSterge_Click_1(object sender, EventArgs e)
        {
            var t = lvTranzactii.SelectedItems[0].Tag as Tranzactie;
            if (MessageBox.Show(
                $"Ștergi tranzacția de {t.SumaValuta} {t.CodValuta} din {t.DataTranzactie:dd.MM.yyyy}?",
                "Confirmare ștergere",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _repository.Delete(t.Id);
                RefreshLista();
            }
        }


    }
}