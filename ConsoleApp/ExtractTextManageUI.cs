using System;
using System.Linq;

namespace ConsoleApp
{
    public class ExtractTextManageUI : ManageUI
    {
        public int ChoiceOperation()
        {
            Console.Clear();
            Console.WriteLine("Wybierz, co chcesz zrobic:");
            optionsList.ForEach(x => Console.WriteLine(x));
            var isTrueChoice = int.TryParse(Console.ReadLine(), out int choice);

            if (isTrueChoice && choice < optionsList.Count)
            {
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("wybrales wyjscie");
                        return 0;
                    case 1:
                        Console.WriteLine("lista");
                        this.ShowList();
                        return 1;
                    case 2:
                        Console.WriteLine(Manage1.GetPosition()) ;
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

        public void ShowList()
        {
            var EmployessOnThisSamePosition = Manage1.People
                .Where(x => x.Posada == Manage1.CurrentUser.Posada).ToList();

            EmployessOnThisSamePosition.ForEach(x =>
            {
                Console.WriteLine($"{x.Imie} {x.Nazwisko} {x.Pesel}");
            });

        }

    }
}
