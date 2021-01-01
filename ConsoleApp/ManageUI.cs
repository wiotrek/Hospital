using Library;
using System;

namespace ConsoleApp
{
    internal class ManageUI
    {
        public void Introduce()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("| Witaj w systemie szpitala |");
            Console.WriteLine("=============================");
        }

        public void LoginToSystem()
        {
            LoggingUI.LoginUserDate();
        }

        public void MainLoop()
        {
            var manage = new Manage();
        }

    }
}
