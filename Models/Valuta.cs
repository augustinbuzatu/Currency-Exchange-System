namespace CasaSchimbValutar.Models
{
    public class Valuta
    {
        public int Id { get; set; }
        public string Cod { get; set; }
        public string Nume { get; set; }
        public string Simbol { get; set; }

        public override string ToString()
        {
            return $"{Cod} - {Nume}";
        }
    }
}