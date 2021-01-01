using System.Linq;

namespace Library
{
    public class Logging : Manage
    {
        public Person User { get; set; }

        public void GetPerson(string login, string password)
        {
            var CurrentUser = People
                .Where(x => x.Login == login && x.Password == password)
                .Select(x => new Person
                {
                    Imie = x.Imie,
                    Nazwisko = x.Nazwisko,
                    Profession = x.Profession,
                    Login = x.Login,
                    Password = x.Password
                });

            if (CurrentUser != null)
                this.User = (Person)CurrentUser;

            throw new GetPersonIsWrong();
        }

    }
}
