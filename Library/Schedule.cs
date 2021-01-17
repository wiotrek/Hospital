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
            var docLaryngolog = this.GetDoctor(laryngolog, 1);
            var docKardiolog = this.GetDoctor(kardiolog, 2);
            var docUrolog = this.GetDoctor(urolog, 3);

            var listNurses = this.GetNurse(nurses);
            //var nurse1 = nurses[0];
            //var nurse2 = nurses[1];
            //var nurse3 = nurses[2];
            //var nurse4 = nurses[3];
            //var nurse5 = nurses[4];



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


        public Person GetNurse(List<int> nurses)
        {
            var list = new List<Person>();
            var listReadyPerson = new List<Person>();
            list = People
                .Where(x => x.Posada == Professions.Nurse)
                .ToList();

            for (int i = 0; i < 5; i++)
            {
                
            }
            return list;
        }
    }
}
