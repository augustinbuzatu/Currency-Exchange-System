using System;
using System.Windows.Forms;
using CasaSchimbValutar.Models;
using CasaSchimbValutar.Repositories;

namespace CasaSchimbValutar.Forms
{
    public partial class FormCursValutar : Form
    {
        private readonly CursValutarRepository _cursRepository = new CursValutarRepository();
        private readonly ValutaRepository _valutaRepository = new ValutaRepository();
        private readonly CursValutar _curs;
        private readonly bool _esteEditare;

        public FormCursValutar(CursValutar curs = null)
        {
            InitializeComponent();

            cmbValuta.DataSource = _valutaRepository.GetAll();
            cmbValuta.DisplayMember = "Cod";
            cmbValuta.ValueMember = "Id";


            if (curs != null)
            {
                _esteEditare = true;
                _curs = curs;
                Text = "Editează curs valutar";
                cmbValuta.SelectedValue = curs.ValutaId;
                dtpDataCurs.Value = curs.DataCurs;
                numCursLaRON.Value = curs.CursLaRON;
            }
            else
            {
                _esteEditare = false;
                _curs = new CursValutar();
                Text = "Adaugă curs valutar";
            }
        }

        private void btnSalveaza_Click_1(object sender, EventArgs e)
        {
            if (!Valideaza()) return;

            var valutaSelectata = cmbValuta.SelectedItem as Valuta;
            _curs.ValutaId = valutaSelectata.Id;
            _curs.DataCurs = dtpDataCurs.Value.Date;
            _curs.CursLaRON = numCursLaRON.Value;

            if (_esteEditare)
                _cursRepository.Update(_curs);
            else
                _cursRepository.Add(_curs);

            DialogResult = DialogResult.OK;
        }

        private bool Valideaza()
        {
            epCurs.Clear();
            bool esteValid = true;

            if (cmbValuta.SelectedItem == null)
            {
                epCurs.SetError(cmbValuta, "Selectează o valută");
                esteValid = false;
            }
            if (numCursLaRON.Value <= 0)
            {
                epCurs.SetError(numCursLaRON, "Cursul trebuie să fie mai mare decât 0");
                esteValid = false;
            }

            return esteValid;
        }

  
    }
}