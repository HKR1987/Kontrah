namespace KontrahenciV2.Model
{
    public class Kontrahent : Element
    {
        public string Nazwa { get; set; }
        public string NazwaSkrocona { get; set; }
        public string Nip { get; set; }
        public string Regon { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public FormaZaplaty FormaZaplaty { get; set; }
        public int TerminZaplaty { get; set; }
        public Adres AdresSiedziby;
        public Adres AdresKorespondencyjny;
        public KontoBankowe KontoBankowe;
    }
}
