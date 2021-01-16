using Library;
using System;
using System.Linq;
using System.Threading;

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
            Console.WriteLine("Nacisnij dowolny klawisz, aby sie zalogowac.");
            Console.ReadLine();
            Console.Clear();
        }

        public void Greeting()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine(Manage1.Introduce());

            var sometext = "";
            for (int i = 0; i < 5; i++)
            {
                sometext += "-------";
                Console.Write(sometext);
                Thread.Sleep(500);
            }
            Thread.Sleep(3000);
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
            this.Greeting();

            //Nalezy podac obiekt manage1 do dziedzacej klasy aby utrzymac dostep do juz wypelnionych informacji
            var menu1 = new MenuUI { Manage1 = this.Manage1 };
            var adminTools = new AdminTools { Manage1 = this.Manage1 };

            var choice = -1;
            while (choice != 0)
            {
                // otwiera MenuUi z wypisanymi proponowanymi podpowiedziami
                choice = menu1.ChoiceOperation();
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        this.ShowListEmployess();
                        break;
                    case 2:
                        Console.WriteLine("harmonogram");
                        break;
                    case 3:
                        if (Manage1.IsAdministrator())
                            adminTools.AddNewUser();
                        else
                            Console.WriteLine("Blad, sprobuj jeszcze raz");
                        break;
                    case 4:
                        if (Manage1.IsAdministrator())
                            adminTools.DeleteUser();
                        else
                            Console.WriteLine("Blad, sprobuj jeszcze raz");
                        break; 
                    default:
                        break;
                }

                if (choice != 0)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Nacisnij dowolny klawisz, aby sie zakonczyc.");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// z manage pobiera liste w stringu i ja wyswietla
        /// </summary>
        protected void ShowListEmployess()
        {
            Console.Clear();
            var whichProffessionList = Manage1.GetPosition();
            Console.WriteLine($"Wyswietlana lista dla [{whichProffessionList}] \n");

            var list = Manage1.ShowList4UserProffessions();
            foreach (var x in list.Select((value, index) => new { value, index }))
            {
                Console.WriteLine($"{x.index + 1}. {x.value}");
            }
        }

    }
}
