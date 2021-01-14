using Library.Database;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Manage
    {
        public List<Person> People { get; set; }
        public Person CurrentUser { get; set; }

        public Manage()
        {
            var db = new JsonDatabase();
            this.People = db.GetData();
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

        //zwraca liste wspolpracownikow do wyswietlenia
        public List<string> ShowList4UserProffessions()
        {
            var list = new List<string>();

            People
                .Where(x => x.Posada == CurrentUser.Posada)
                .ToList()
                .ForEach(x => list.Add($"{x.Imie} {x.Nazwisko} {x.Posada.ProffesionsToPolishtString()}")
                );

            return list;
        }
    }
}
