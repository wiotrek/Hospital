using Library;
using System;

namespace ConsoleApp
{
    public class ManageUI
    {
        public Manage Manage1 { get; set; } = new Manage();

        public void Introduce()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("| Witaj w systemie szpitala |");
            Console.WriteLine("=============================");
        }

        public void LoginToSystem()
        {
            var logging = new LoggingUI();
            var userDate = logging.CheckUserLoginPassword().ToTuple();

            Manage1.TryLogging(userDate.Item1, userDate.Item2, true);
        }

        public void MainLoop()
        {
            var a = Manage1.GetName();
            Console.WriteLine(a);
        }

    }
}
