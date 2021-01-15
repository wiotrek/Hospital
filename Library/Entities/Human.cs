namespace Library
{
    public abstract class Human
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }

        public override string ToString()
        {
            return $"Witam, jestem {Imie} {Nazwisko}";
        }
    }
}
