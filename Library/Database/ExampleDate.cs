using System;
using System.Collections.Generic;

namespace Library.Database
{
    public class ExampleDate
    {
        /// <summary>
        /// funkcja majaca na celu wypelnic liste pracownikow szpitala
        /// </summary>
        public void AddRandomDate()
        {
            var rand = new Random();

            var listPeople = new List<Person>();

            for (int i = 0; i < 12; i++)
            {
                var randName = this.choiceName();
                var doctor = new Person
                {
                    Imie = randName,
                    Nazwisko = this.choiceSurName(),
                    Login = this.createLogin(randName),
                    Haslo = this.createPass(),
                    Pesel = this.createPesel(),
                    Posada = Professions.Doctor,
                    Specjalizacja = (Specializations)rand.Next(1, 4)
                };
                listPeople.Add(doctor);
            }

            for (int i = 0; i < 20; i++)
            {
                var randName = this.choiceName();
                var nurse = new Person
                {
                    Imie = randName,
                    Nazwisko = this.choiceSurName(),
                    Login = this.createLogin(randName),
                    Haslo = this.createPass(),
                    Pesel = this.createPesel(),
                    Posada = Professions.Nurse,
                    Specjalizacja = Specializations.Brak
                };
                listPeople.Add(nurse);
            }

            for (int i = 0; i < 4; i++)
            {
                var randName = this.choiceName();
                var admin = new Person
                {
                    Imie = randName,
                    Nazwisko = this.choiceSurName(),
                    Login = this.createLogin(randName),
                    Haslo = this.createPass(),
                    Pesel = this.createPesel(),
                    Posada = Professions.Administrator,
                    Specjalizacja = Specializations.Brak
                };
                listPeople.Add(admin);
            }

            var db = new JsonDatabase();
            db.UpdateDatabase(listPeople);

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
                "Bartek", "Piotr", "Grzegorz", "Kuba", "Geniu", "Iwona", "Patrycja",
                "Sebastian", "Przemyslaw", "Czarek", "Hernyk", "Mikolaj", "Jacek",
                "Hubert", "Mariusz", "Boleslaw", "Krzysztof", "Wlodzimierz", "Cezary"
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
            return login.ToString();
        }

        private string createPass()
        {
            var rand = new Random();
            var charsList = new List<string>
            {
                "d", "a", "k", "l", "w", "p", "c", "1", "3", "0"
            };
            var text = "";
            for (int i = 0; i < 10; i++)
                text += charsList[rand.Next(charsList.Count)];
            return text;
        }
    }
}
