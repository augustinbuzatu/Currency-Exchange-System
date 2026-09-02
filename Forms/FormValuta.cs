using System;
using System.Windows.Forms;
using CasaSchimbValutar.Models;
using CasaSchimbValutar.Repositories;

namespace CasaSchimbValutar.Forms
{
    public partial class FormValuta : Form
    {
        private readonly ValutaRepository _repository = new ValutaRepository();
        private readonly Valuta _valuta;
        private readonly bool _esteEditare;

        public FormValuta(Valuta valuta = null)
        {
            InitializeComponent();

            if (valuta != null)
            {
                _esteEditare = true;
                _valuta = valuta;
                Text = $"Editează valuta {valuta.Cod}";
                txtCod.Text = valuta.Cod;
                txtNume.Text = valuta.Nume;
                txtSimbol.Text = valuta.Simbol;
            }
            else
            {
                _esteEditare = false;
                _valuta = new Valuta();
                Text = "Adaugă valută";
            }
        }

        private void btnSalveaza_Click_1(object sender, EventArgs e)
        {
            if (!Valideaza()) return;

            _valuta.Cod = txtCod.Text.Trim().ToUpper();
            _valuta.Nume = txtNume.Text.Trim();
            _valuta.Simbol = txtSimbol.Text.Trim();

            if (_esteEditare)
                _repository.Update(_valuta);
            else
                _repository.Add(_valuta);

            DialogResult = DialogResult.OK;
        }

        private bool Valideaza()
        {
            epValuta.Clear();
            bool esteValid = true;

            if (string.IsNullOrWhiteSpace(txtCod.Text))
            {
                epValuta.SetError(txtCod, "Codul este obligatoriu");
                esteValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                epValuta.SetError(txtNume, "Numele este obligatoriu");
                esteValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtSimbol.Text))
            {
                epValuta.SetError(txtSimbol, "Simbolul este obligatoriu");
                esteValid = false;
            }

            return esteValid;
        }


    }
}