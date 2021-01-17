using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library.Database
{
    public class JsonDatabase : IJsonDatabase<Person>
    {
        public string FileName { get; set; } = "JsonDatabase.txt";

        public List<Person> GetData()
        {
            if (!File.Exists(FileName))
                throw new FileDoesntExist();

            var dbFile = File.ReadAllText(FileName);
            var dbJson = JsonConvert.DeserializeObject<List<Person>>(dbFile);

            return dbJson;
        }
        
        public void UpdateDatabase(List<Person> people)
        {
            var json = JsonConvert.SerializeObject(people);
            File.WriteAllText(FileName, json);
        }

        public void AddRandomDate()
        {
            //var doctor = new Person
            //{
            //    Imie = this.choiceName(),
            //    Nazwisko = this.choiceSurName(),
            //    Login = 
            //}

        }

        private string createPesel()
        {
            var rand = new Random();
            var text = "";
            for (int i = 0; i < 11; i++)
                text += rand.Next(10).ToString();

            return text;
        }
        private string choiceName()
        {
            var names = new List<string>
            {
                "Ela", "Maria", "Joanna", "Jadwiga", "Beata", "Natalia",
                "Kinga", "Jola", "Krystyna", "Jowita", "Daria", "Martyna",
                "Kinga", "Wieslawa", "Ilona", "Stefania", "Wojtek", "Krystian",
                "Bartek", "Piotr", "Grzegorz", "Kuba",
                "Sebastian", "Przemyslaw", "Czarek", "Hernyk", "Mikolaj",
                "Hubert", "Mariusz", "Boleslaw", "Krzysztof", "Wlodzimierz"
            };
            var rand = new Random();
            return names[rand.Next(names.Count)];
        }

        private string choiceSurName()
        {
            var surnames = new List<string>
            {
                "Nowak", "Kowlaski", "Rajczyk", "Cydejko", "Nowaczyk",
                "Kosiniak", "Kalisz", "Nowopolski", "Szczepaniak", "Sikorski",
                "Malysz", "Stoch", "Kubacki", "Saleta", "Kubiak", "Bartman",
                "Stasiak", "Rogacki", "Koscielniak", "Przybysz", "Bartlewicz",
                "Urbaniak", "Saski", "Dolata", "Kamysz", "Wojniewicz"
            };

            var rand = new Random();
            return surnames[rand.Next(surnames.Count)];
        }

        private string createLogin(string name)
        {
            var rand = new Random();
            var login = name + rand.Next(100000);
            return login;
        }
    }
}
