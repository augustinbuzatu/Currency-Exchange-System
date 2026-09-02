using System;
using System.Windows.Forms;
using CasaSchimbValutar.Models;
using CasaSchimbValutar.Repositories;

namespace CasaSchimbValutar.Forms
{
    public partial class FormTranzactie : Form
    {
        private readonly TranzactieRepository _tranzactieRepository = new TranzactieRepository();
        private readonly ValutaRepository _valutaRepository = new ValutaRepository();
        private readonly CursValutarRepository _cursRepository = new CursValutarRepository();
        private readonly Tranzactie _tranzactie;
        private readonly bool _esteEditare;
        private decimal _cursActual;

        public FormTranzactie(Tranzactie tranzactie = null)
        {
            InitializeComponent();

            cmbValuta.DataSource = _valutaRepository.GetAll();
            cmbValuta.DisplayMember = "Cod";
            cmbValuta.ValueMember = "Id";

            cmbTip.DataSource = Enum.GetValues(typeof(TipTranzactie));

            if (tranzactie != null)
            {
                _esteEditare = true;
                _tranzactie = tranzactie;
                Text = "Editează tranzacție";
                cmbValuta.SelectedValue = tranzactie.ValutaId;
                cmbTip.SelectedItem = tranzactie.Tip;
                numSumaValuta.Value = tranzactie.SumaValuta;
                dtpDataTranzactie.Value = tranzactie.DataTranzactie;
            }
            else
            {
                _esteEditare = false;
                _tranzactie = new Tranzactie();
                Text = "Adaugă tranzacție";
                dtpDataTranzactie.Value = DateTime.Now;
            }

            ActualizeazaCurs();
        }

        private void ActualizeazaCurs()
        {
            if (cmbValuta.SelectedItem is Valuta valuta)
            {
                var curs = _cursRepository.GetCurentByValutaId(valuta.Id);
                if (curs != null)
                {
                    _cursActual = curs.CursLaRON;
                    lblCursActual.Text = $"Curs: 1 {valuta.Nume} = {_cursActual:F4} RON";
                }
                else
                {
                    _cursActual = 0;
                    lblCursActual.Text = "Nu există curs definit pentru această valută!";
                }
                ActualizeazaSumaRON();
            }
        }

        private void ActualizeazaSumaRON()
        {
            var sumaRON = numSumaValuta.Value * _cursActual;
            lblSumaRON.Text = $"Suma în RON: {sumaRON:F2} RON";
        }

        private void cmbValuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizeazaCurs();
        }

        private void numSumaValuta_ValueChanged(object sender, EventArgs e)
        {
            ActualizeazaSumaRON();
        }

        private void btnSalveaza_Click_1(object sender, EventArgs e)
        {
            if (!Valideaza()) return;

            var valuta = cmbValuta.SelectedItem as Valuta;
            _tranzactie.ValutaId = valuta.Id;
            _tranzactie.SumaValuta = numSumaValuta.Value;
            _tranzactie.CursUtilizat = _cursActual;
            _tranzactie.SumaRON = numSumaValuta.Value * _cursActual;
            _tranzactie.Tip = (TipTranzactie)cmbTip.SelectedItem;
            _tranzactie.DataTranzactie = dtpDataTranzactie.Value;

            if (_esteEditare)
                _tranzactieRepository.Update(_tranzactie);
            else
                _tranzactieRepository.Add(_tranzactie);

            DialogResult = DialogResult.OK;
        }

        private bool Valideaza()
        {
            epTranzactie.Clear();
            bool esteValid = true;

            if (cmbValuta.SelectedItem == null)
            {
                epTranzactie.SetError(cmbValuta, "Selectează o valută");
                esteValid = false;
            }
            if (_cursActual <= 0)
            {
                epTranzactie.SetError(cmbValuta, "Nu există un curs valutar definit pentru această valută");
                esteValid = false;
            }
            if (numSumaValuta.Value <= 0)
            {
                epTranzactie.SetError(numSumaValuta, "Suma trebuie să fie mai mare decât 0");
                esteValid = false;
            }

            return esteValid;
        }


    }
}