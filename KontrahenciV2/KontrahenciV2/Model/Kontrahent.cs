namespace KontrahenciV2.Model
{
    class Kontrahent
    {
        int Id { get; set; }
        public string Nazwa { get; set; }
        public string NazwaSkrocona { get; set; }
        public string Nip { get; private set; }
        public string Regon { get; private set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public Status Status { get; private set; }
        public FormaZaplaty FormaZaplaty { get; private set; }
        public int TerminZaplaty { get; private set; }
        public Adres AdresSiedziby;
        public Adres AdresKorespondencyjny;
    }
}
