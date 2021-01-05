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
                Imie = "Marek",
                Nazwisko = "Tomaszesski",
                Pesel = "123456789",
                Login = "Mareczek123",
                Haslo = "maro321",
                Posada = Professions.Nurse,
                Specjalizacja = Specializations.Brak
            };

            var list = new List<Person>
            {
                osoba
            };

            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(FileName, json);
        }
    }
}
