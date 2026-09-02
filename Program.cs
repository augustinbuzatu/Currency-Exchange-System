using System;
using System.Windows.Forms;
using CasaSchimbValutar.Forms;

namespace CasaSchimbValutar
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AplicatieCursValutar());
        }
    }
}