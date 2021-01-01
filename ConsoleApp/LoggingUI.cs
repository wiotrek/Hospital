using Library;
using System;

namespace ConsoleApp
{
    public class LoggingUI
    {
        public static void LoginUserDate()
        {
            Console.WriteLine("Zaloguj sie \n");
            
            Console.WriteLine("Podaj login:");
            var login = Console.ReadLine();
            
            Console.WriteLine("Podaj haslo:");
            var pass = Console.ReadLine();

            var tryLogin = new Logging();
            tryLogin.GetPerson(login, pass);

            Console.WriteLine(tryLogin.User.Imie);
        }
    }
}
