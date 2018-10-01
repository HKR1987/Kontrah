using System;

namespace KontrahenciV2.Model
{
    public class KontoBankowe
    {
        string Nazwa { get; set; }
        string Numer { get; set; }

        public KontoBankowe(string nazwa, string numer)
        {
            Nazwa = nazwa;
            Numer = numer;
        }    
    }
}
