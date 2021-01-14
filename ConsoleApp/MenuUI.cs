using Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class MenuUI : ManageUI
    {
        /// <summary>
        /// lista do wyswietlania odpowiednich mozliwosci
        /// </summary>
        private List<string> optionsList = new List<string>
        {
                "1 - Pokaz liste.",
                "2 - Pokaz harmonogram.",
                "0 - Wyjscie z aplikacji."
        };

        /// <summary>
        /// glowne menu aplikacji
        /// </summary>
        /// <returns>Zwraca inta wyboru (jesli bedzie 0 glowna petla bedzie konczyla dzialanie)</returns>
        public int ChoiceOperation()
        {
            Console.Clear();
            Console.WriteLine("Wybierz, co chcesz zrobic:");
            optionsList.ForEach(x => Console.WriteLine(x));
            var isTrueChoice = int.TryParse(Console.ReadLine(), out int choice);

            if (isTrueChoice && (choice < optionsList.Count))
            {
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("wybrales wyjscie");
                        return 0;
                    case 1:
                        this.ShowListEmployess();
                        return 1;
                    case 2:
                        Console.WriteLine("harmonogram");
                        return 2;
                    default:
                        return -1;
                }
            }
            else
                Console.WriteLine("zly klawisz");
            return -1;
        }


        /// <summary>
        /// z manage pobiera liste w stringu i ja wyswietla
        /// </summary>
        private void ShowListEmployess()
        {
            Console.Clear();
            var whichProffessionList = Manage1.GetPosition();
            Console.WriteLine($"Wyswietlana lista [{whichProffessionList}] \n");

            var list = Manage1.ShowList4UserProffessions();
            foreach (var x in list.Select((value, index) => new { value, index }))
            {
                Console.WriteLine($"{x.index+1}. {x.value}");
            }
            Console.WriteLine("\n");
        }

    }
}
