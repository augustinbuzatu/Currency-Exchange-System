using System;
using System.Windows.Forms;
using CasaSchimbValutar.Forms;

namespace CasaSchimbValutar.Forms
{
    public partial class AplicatieCursValutar : Form
    {
        public AplicatieCursValutar()
        {
            InitializeComponent();
        }

        private void mniValute_Click_1(object sender, EventArgs e)
        {
            DeschideFormSingleton<FormValute>();
        }

        private void mniCursuriValutare_Click_1(object sender, EventArgs e)
        {
            DeschideFormSingleton<FormCursuriValutare>();
        }

        private void mniTranzactii_Click_1(object sender, EventArgs e)
        {
            DeschideFormSingleton<FormTranzactii>();
        }

        private void mniIesire_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DeschideFormSingleton<T>() where T : Form, new()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is T)
                {
                    form.BringToFront();
                    return;
                }
            }

            T formNou = new T();
            formNou.Show();
        }


    }
}