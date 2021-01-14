using Library;
using System;

namespace ConsoleApp
{
    public class ManageUI
    {
        /// <summary>
        /// Glowny obiekt do laczenia sie z backendem
        /// </summary>
        protected Manage Manage1 { get; set; } = new Manage();

        private void Introduce()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("| Witaj w systemie szpitala |");
            Console.WriteLine("=============================");
            Console.WriteLine("\n");
        }

        /// <summary>
        /// funkcja najpierw sprawdza czy dane do logowania sie zgadzaja
        /// a nastepnie loguje uzytkownika
        /// </summary>
        protected void LoginToSystem()
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

            //Nalezy podac obiekt manage1 do dziedzacej klasy aby utrzymac dostep do juz wypelnionych informacji
            var menu1 = new MenuUI
            {
                Manage1 = this.Manage1
            };

            var exitMainLoop = -1;

            while (exitMainLoop != 0)
            {
                exitMainLoop = menu1.ChoiceOperation();


                if (exitMainLoop != 0)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Zakonczyc dana opcje?");
                    Console.WriteLine("Nacisnij dowolny klawisz.");
                    Console.ReadLine();
                }
            }
        }
    }
}
