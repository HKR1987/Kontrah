namespace KontrahenciV2.Model
{
    internal class Adres
    {
        public string Miejscowosc { get; set; }
        public string Ulica { get; set; }
        public string NrDomu { get; set; }
        public string NrMieszkania { get; set; }
        public string KodPocztowy { get; set; }

        public Adres(string miejscowosc, string ulica, string nrDomu, string nrMieszkania, string kodPocztowy)
        {
            Miejscowosc = miejscowosc;
            Ulica = ulica;
            NrDomu = nrDomu;
            NrMieszkania = nrMieszkania;
            KodPocztowy = kodPocztowy;
        }
    }
}
