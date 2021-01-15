using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class MenuUI : ManageUI
    {
        /// <summary>
        /// lista do wyswietlania odpowiednich mozliwosci
        /// </summary>
        private readonly List<string> optionsList4Admin = new List<string>
        {
                "1 - Pokaz liste.",
                "2 - Pokaz harmonogram.",
                "3 - Dodaj nowego uzytkownika",
                "4 - Usun uzytkownika",
                "0 - Wyjscie z aplikacji."
        };
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

            if (Manage1.IsAdministrator())
                optionsList4Admin.ForEach(x => Console.WriteLine(x));
            else
                optionsList.ForEach(x => Console.WriteLine(x));

            var isTrueChoice = int.TryParse(Console.ReadLine(), out int choice);

            if (isTrueChoice && (choice < optionsList4Admin.Count))
                return choice;
            else
                Console.WriteLine("zly klawisz");

            return -1;
        }
    }
}
