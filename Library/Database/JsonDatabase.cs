using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Library.Database
{
    public class JsonDatabase : IJsonDatabase
    {
        public string FileName { get; set; } = "JsonDatabase.txt";
        public bool IsFileExist { get => File.Exists(FileName); set => _ = File.Exists(FileName); }


        public List<Person> GetData()
        {
            if (!IsFileExist)
                throw new FileDoesntExist();

            var dbFile = File.ReadAllText(FileName);
            var dbJson = JsonConvert.DeserializeObject<List<Person>>(dbFile);

            return dbJson;
        }
        
        public void AddExampleDate()
        {
            var osoba = new Person
            {
                Imie = "Krystyna",
                Nazwisko = "Pola",
                Pesel = "323456730",
                Login = "krecha",
                Haslo = "222",
                Posada = Professions.Nurse,
                Specjalizacja = Specializations.Brak
            };
            var osoba2 = new Person
            {
                Imie = "Lena",
                Nazwisko = "Kolnierz",
                Pesel = "423456730",
                Login = "lenka",
                Haslo = "111",
                Posada = Professions.Nurse,
                Specjalizacja = Specializations.Brak
            };
            var osoba3 = new Person
            {
                Imie = "Grzegorz",
                Nazwisko = "Pol",
                Pesel = "423456730",
                Login = "pol",
                Haslo = "123",
                Posada = Professions.Doctor,
                Specjalizacja = Specializations.Laryngolog
            };

            var list = new List<Person>
            {
                osoba,
                osoba2,
                osoba3
            };

            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(FileName, json);
        }
    }
}
