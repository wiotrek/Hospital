using Library.Database;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Schedule : Manage
    {
        public List<Day> ListOfDays { get; private set; }

        /// <summary>
        /// pobiera adresy id uzytkownikow, z konkretnych list ( to nie jest jedna lista wszystkich,
        /// sa one rozdzielone w rozny sposob)
        /// nastepnie tworzy poszczegolne osoby
        /// </summary>
        public void AddDayToList(int laryngolog, int kardiolog, int urolog,
            List<int> nurses, int admin)
        {
            var laryngologClassPerson = this.GetDoctor(laryngolog, 1);
            var kardiologClassPerson = this.GetDoctor(kardiolog, 2);
            var urologClassPerson = this.GetDoctor(urolog, 3);

            var listNursesClassPerson = this.GetNurse(nurses);

            var nurse1 = listNursesClassPerson[0];
            var nurse2 = listNursesClassPerson[1];
            var nurse3 = listNursesClassPerson[2];
            var nurse4 = listNursesClassPerson[3];
            var nurse5 = listNursesClassPerson[4];

            var adminClassPerson = this.GetAdmin(admin);

            var day = new Day
            {
                Doctor = laryngologClassPerson,
                Doctor2 = kardiologClassPerson,
                Doctor3 = urologClassPerson,
                Nurse1 = nurse1,
                Nurse2 = nurse2,
                Nurse3 = nurse3,
                Nurse4 = nurse4,
                Nurse5 = nurse5,
                Admin = adminClassPerson
            };

            this.ListOfDays.Add(day);

            var db = new JsonDatabaseSchedule();
            db.UpdateDatabase(ListOfDays);
        }

        /// <returns>Pobiera gotowy juz id z listy samych lekarzy ze specjalizacji,
        /// i zwraca gotowa osobe ktora mozemy dodac do dnia</returns>
        public Person GetDoctor(int id, int specialization)
        {
            var list = new List<Person>();
            var specializationToEnum = (Specializations)specialization;
            list = People.Where(x => x.Specjalizacja == specializationToEnum).ToList();
            return list[id];
        }

        /// <summary>
        /// przyjmuje tablice intow z numerami id nurses,
        /// na ich podstawie w przeskalowanej liscie, dla konktretnie proffession nurse,
        /// dodaje element Person do nowej listy, i element z tej listy ktorej szukal
        /// robi to 5 raz
        /// </summary>
        /// <returns>Zwraca liste 5 elementow klasy Person</returns>
        public List<Person> GetNurse(List<int> nurses)
        {
            var list = new List<Person>();
            var listReadyPerson = new List<Person>();
            list = People
                .Where(x => x.Posada == Professions.Nurse)
                .ToList();

            for (int i = 0; i < 5; i++)
            {
                // dodaje z listy wyskalowanych elementow czyli elemntow nurse
                // element o id z tablicy nurse
                listReadyPerson.Add(list[nurses[i]]);
                list.RemoveAt(nurses[i]);
            }
            return list;
        }

        public Person GetAdmin(int id)
        {
            var list = new List<Person>();

            list = People
                .Where(x => x.Posada == Professions.Administrator)
                .ToList();

            return list[id];
        }
    }
}
