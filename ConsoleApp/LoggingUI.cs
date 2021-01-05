using Library;
using System;

namespace ConsoleApp
{
    public class LoggingUI : ManageUI
    {

        /// <summary>
        /// Prosi uzytkownika o dane do logowania, nastepnie je sprawdza.
        /// z tego powodu ze jest to klasa dziedziczaca Manage1 jest niewidoczny w klasie ManageUI
        /// </summary>
        /// <returns>zwraca login i haslo</returns>
        public (string, string) CheckUserLoginPassword()
        {
            Console.WriteLine("Zaloguj sie \n");
            var isSuccess = false;
            var login = default(string);
            var pass = default(string);

            while (!isSuccess)
            {
                Console.WriteLine("Podaj login:");
                login = Console.ReadLine();

                Console.WriteLine("Podaj haslo:");
                pass = Console.ReadLine();

                isSuccess = Manage1.TryLogging(login, pass, false);
                if (!isSuccess)
                {
                    Console.Clear();
                    Console.WriteLine("Login lub haslo jest niepoprawne");
                }
            }
            return (login, pass);
        }
    }
}
