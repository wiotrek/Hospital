using Library;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    public class ManageUI
    {
        public Manage Manage1 { get; set; } = new Manage();
        protected List<string> optionsList = new List<string>
        {
                $"1 - Pokaz liste {Professions.Doctor.ProffesionsToPolishString()}.",
                "2 - Pokaz harmonogram.",
                "0 - Wyjscie z aplikacji."
        };

        private void Introduce()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("| Witaj w systemie szpitala |");
            Console.WriteLine("=============================");
        }

        private void LoginToSystem()
        {
            var logging = new LoggingUI();
            var userDate = logging.CheckUserLoginPassword().ToTuple();
            Manage1.TryLogging(userDate.Item1, userDate.Item2, true);
        }

        /// <summary>
        /// Glowna petla programu, dziala dopoki funkcja choiceoperation nie zwroci int 0
        /// </summary>
        public void MainLoop()
        {
            this.Introduce();
            this.LoginToSystem();

            var exitMainLoop = -1;
            var extractText = new ExtractTextManageUI();

            while (exitMainLoop != 0)
            {
                exitMainLoop = extractText.ChoiceOperation();

                if (exitMainLoop != 0)
                {
                    Console.WriteLine("Zakonczyc dana opcje? \n");
                    Console.WriteLine("Nacisnij dowolny klawisz.");
                    Console.ReadLine();
                }
            }
        }
    }
}
