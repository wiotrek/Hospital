﻿using Library.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Manage
    {
        /// <summary>
        /// Glowna lista na ktorej pracuje
        /// </summary>
        public List<Person> People { get; set; }
        /// <summary>
        /// zalogowany uzytkownik
        /// </summary>
        public Person CurrentUser { get; set; }

        public Manage()
        {
            var db = new JsonDatabase();
            this.People = db.GetData();
        }

        public string Introduce()
        {
            return CurrentUser.ToString();
        }

        /// <summary>
        /// posrednik pomiedzy algorytmem do logowania
        /// </summary>
        /// <param name="setCuser">jesli setCuser jest na true to znaczy ze prawidlowo 
        /// pobrany user zostanie przypisany do obiektu</param>
        /// <returns>zwraca prawde lub falsz do wiadomosci czy udalo sie zalogowac</returns>
        public bool TryLogging(string login, string pass, bool setCuser=false)
        {
            var logging = new Logging();
            var isSuccessed = logging.GetPerson(login, pass);

            if (setCuser)
                CurrentUser = isSuccessed;

            return isSuccessed != null;
        }


        /// <returns>Zwraca odmieniona nazwe posady konkretnego usera</returns>
        public string GetPosition()
        {
            return CurrentUser.Posada.ProffesionsToPolishVariantString();
        }

        public bool IsAdministrator()
        {
            return CurrentUser.Posada == Professions.Administrator;
        }

        public bool IsDoctor()
        {
            return CurrentUser.Posada == Professions.Doctor;
        }

        //zwraca liste wspolpracownikow do wyswietlenia
        public List<string> ShowList4UserProffessions()
        {
            var list = new List<string>();

            // jesli uzytkownik jest administratorem to ma podglad na wszystkich uzytkownikow
            if (CurrentUser.Posada == Professions.Administrator)
            {
                People.ForEach(x => list.Add($"{x.Imie} {x.Nazwisko} {x.Posada.ProffesionsToPolishtString()}"));
                return list;
            }

            //Tylko lekarza maja specjalizacje
            if (CurrentUser.Posada == Professions.Doctor)
            {
                People
                    .Where(x => x.Posada == CurrentUser.Posada)
                    .ToList()
                    .ForEach(x => list.Add($"{x.Imie} {x.Nazwisko} {x.Posada.ProffesionsToPolishtString()} {x.Specjalizacja}"));
                return list;
            }

            People
                .Where(x => x.Posada == CurrentUser.Posada)
                .ToList()
                .ForEach(x => list.Add($"{x.Imie} {x.Nazwisko} {x.Posada.ProffesionsToPolishtString()}")
                );

            return list;
        }

        /// <returns>zwraca liste doktorow do wstawienia ich w harmonogram</returns>
        public List<string> ListToAddToScheduleDoctor(int specialization)
        {
            var list = new List<string>();
            var specializationToEnum = (Specializations)specialization;

            People
                .Where(x => x.Specjalizacja == specializationToEnum)
                .ToList()
                .ForEach(x => list.Add($"{x.Imie} {x.Nazwisko} {x.Posada.ProffesionsToPolishtString()} {x.Specjalizacja}"));
            return list;
        }

        /// <returns>zwraca liste pielegniarek do wstawienia ich w harmonogram</returns>
        public List<string> ListToAddToScheduleNurse()
        {
            var list = new List<string>();

            People
                .Where(x => x.Posada == Professions.Nurse)
                .ToList()
                .ForEach(x => list.Add($"{x.Imie} {x.Nazwisko} {x.Posada.ProffesionsToPolishtString()}")
                );
            return list;
        }

        /// <returns>zwraca liste adminow do wstawienia ich w harmonogram</returns>
        public List<string> ListToAddToScheduleAdmin()
        {
            var list = new List<string>();

            People
                .Where(x => x.Posada == Professions.Administrator)
                .ToList()
                .ForEach(x => list.Add($"{x.Imie} {x.Nazwisko} {x.Posada.ProffesionsToPolishtString()}"));
            return list;
        }

        /// <returns>Zwraca liste z nazwami stanowisk</returns>
        public List<string> GetNameProffessions()
        {
            var list = new List<string>();
            foreach (var proffesion in Enum.GetValues(typeof(Professions)))
            {
                list.Add(proffesion.ToString());
            }
            return list;
        }

        /// <returns>Zwraca liste z nazwami specjalizacje (wylacznie dla doktorow)</returns>
        public List<string> GetNameSpecializations()
        {
            var list = new List<string>();
            foreach (var specialization in Enum.GetValues(typeof(Specializations)))
            {
                list.Add(specialization.ToString());
            }
            return list;
        }

        /// <summary>
        /// Pobiera argumenty z ktorych tworzy obiekt Person
        /// </summary>
        /// <returns>Zwraca obiekt Person gotowny do dodania do serializacji</returns>
        public void CreateNewPerson(string login, string pass, string name, string surname, string pesel, 
            int position=0, int specialization=0)
        {
            var newPerson = new Person
            {
                Login = login,
                Haslo = pass,
                Imie = name,
                Nazwisko = surname,
                Pesel = pesel,
                Posada = (Professions)position,
                Specjalizacja = (Specializations)specialization
            };

            this.People.Add(newPerson);

            // zaktualizowanie listy w pliku json
            //pobranie na danych z nowym userem z pliku
            var db = new JsonDatabase();
            db.UpdateDatabase(People);
            this.People = db.GetData();
        }


        /// <summary>
        /// Usuwa osobe z listy po numerze indeksu
        /// </summary>
        /// <param name="id">W funkcji deletePerson param id zostanie zinkrementowany</param>
        public void DeletePerson(int id)
        {
            id--;
            this.People.RemoveAt(id);

            // zaktualizowanie listy w pliku json
            //pobranie na danych z nowym userem z pliku
            var db = new JsonDatabase();
            db.UpdateDatabase(People);
            this.People = db.GetData();
        }

        /// <summary>
        /// Funkcja tworzaca odniesienie do klasy schedule aby stworzyc dzien
        /// </summary>
        public void ScheduleManage (int laryngolog, int kardiolog, int urolog,
            List<int> nurses, int admin)
        {
            var schedule = new Schedule { People = this.People };

            schedule.AddDayToList(laryngolog, kardiolog, urolog,
            nurses, admin);
        }

        public List<string> GetScheduleAllDays()
        {
            var schedule1 = new Schedule();
            var listOfDays = schedule1.ListOfDays;

            var list = new List<string>();

            foreach (var day in listOfDays)
            {
                list.Add("Day");
                list.Add(day.Doctor.ToString());
                list.Add(day.Doctor2.ToString());
                list.Add(day.Doctor3.ToString());
                list.Add(day.Nurse1.ToString());
                list.Add(day.Nurse2.ToString());
                list.Add(day.Nurse3.ToString());
                list.Add(day.Nurse4.ToString());
                list.Add(day.Nurse5.ToString());
                list.Add(day.Admin.ToString());
                list.Add("\n");
            };

            return list;
        }


    }
}
