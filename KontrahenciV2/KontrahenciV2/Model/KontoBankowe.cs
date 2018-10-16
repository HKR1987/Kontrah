using System;

namespace KontrahenciV2.Model
{
    public class KontoBankowe
    {
        public int IdKontrahenta { get; set; }
        public string Nazwa { get; set; }
        public string Numer { get; set; }

        public KontoBankowe(string nazwa, string numer)
        {
            
            Nazwa = nazwa;
            Numer = numer;
        }
        public KontoBankowe(int idKontrahenta, string nazwa, string numer) : this(nazwa, numer)
        {
            IdKontrahenta = IdKontrahenta;
        }
    }
}
