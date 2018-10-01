namespace KontrahenciV2.Model
{
    internal class DowodOsobisty
    {
        string Seria { get; set; }
        string Numer { get; set; }
        string WydanyPrzez { get; set; }
        string DataWydania { get; set; }
        string Pesel { get; set; }

        public DowodOsobisty(string seria, string numer, string wydanyPrzez, string dataWydania, string pesel)
        {
            Seria = seria;
            Numer = numer;
            WydanyPrzez = wydanyPrzez;
            DataWydania = dataWydania;
            Pesel = pesel;
        }
    }
}
