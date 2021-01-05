using System.Linq;

namespace Library
{
    public class Logging : Manage
    {
        /// <summary>
        /// sprawdza czy istnieje uzytkownik z podanym loginem i haslem,
        /// klasa dziedziczy z Manage aby mogla otrzymac People List<Person>
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>pierwsza osobe ktora ma taki login i haslo, lub null</returns>
        public Person GetPerson(string login, string password)
        {
            var User = People
                .Where(x => x.Login == login && x.Haslo == password).FirstOrDefault();

            return User;
        }

    }
}
