using System;

namespace CasaSchimbValutar.Models
{
    public class CursValutar
    {
        public int Id { get; set; }
        public int ValutaId { get; set; }
        public string CodValuta { get; set; }
        public DateTime DataCurs { get; set; }
        public decimal CursLaRON { get; set; }
    }
}