using System;

namespace CasaSchimbValutar.Models
{
    public enum TipTranzactie
    {
        Cumparare,
        Vanzare
    }

    public class Tranzactie
    {
        public int Id { get; set; }
        public int ValutaId { get; set; }
        public string CodValuta { get; set; }
        public decimal SumaValuta { get; set; }
        public decimal CursUtilizat { get; set; }
        public decimal SumaRON { get; set; }
        public TipTranzactie Tip { get; set; }
        public DateTime DataTranzactie { get; set; }
    }
}