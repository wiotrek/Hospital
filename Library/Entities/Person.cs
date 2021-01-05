namespace Library
{
    public class Person : IPerson
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public Professions Posada { get; set; }
        public Specializations Specjalizacja { get; set; }
    }
}
