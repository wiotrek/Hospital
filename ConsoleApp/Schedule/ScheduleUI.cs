using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class ScheduleUI : ManageUI, ISchedule
    {
        private readonly List<string> optionsList = new List<string>
        {
                "1 - Zobacz caly miesiac.",
                "2 - Zobacz nastepny dzien",
                "0 - Wyjscie z Harmonogramu."
        };

        public void MainSchedule()
        {
            var launch = true;
            while (launch)
            {
                Console.Clear();
                this.optionsList.ForEach(x => Console.WriteLine(x));
                if (Manage1.IsDoctor())
                    Console.WriteLine("3 - Dodaj personel");
                var isSuccessParse = int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 0:
                        launch = false;
                        break;
                    case 1:
                        Console.WriteLine("1");
                        break;
                    case 2:
                        Console.WriteLine("2");
                        break;
                    case 3:
                        this.AddPersonnel();
                        break;
                    default:
                        Console.WriteLine("Niewlasciwy klawisz, nacisnij dowolny przycisk aby powtorzyc");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void AddPersonnel()
        {
            Console.WriteLine("Czy chcesz dodac personel do konkretnego dnia, nacisnij T/N");
            var isExit = Console.ReadLine();

            if (isExit == "N" || isExit == "n")
                return;
            Console.Clear();

            // specjalizacje lekarzy
            // 1 - laryngolog
            // 2 - kardiolog
            // 3 - urolog
            var docLaryngolog = this.AddDoctor(1);
            var docKardiolog = this.AddDoctor(2);
            var docUrolog = this.AddDoctor(3);
            var nurses5list = this.Add5Nurse();
            var admin = this.AddAdmin();

            Manage1.ScheduleManage(docLaryngolog, docKardiolog, docUrolog,
                nurses5list, admin);
        }

        /// <returns>Zwraca numer id (juz z deinkremenotwany) osoby do dodania</returns>
        private int AddDoctor(int specialization)
        {
            var doctors = Manage1.ListToAddToScheduleDoctor(specialization);
            var IsSuccess = false;
            var choice = default(int);
            while (!IsSuccess)
            {
                Console.Clear();
                foreach (var x in doctors.Select((value, index) => new { value, index }))
                    Console.WriteLine($"{x.index + 1}. {x.value}");

                Console.WriteLine("\n");
                Console.WriteLine("Wybierz doktora do tego dnia");
                
                IsSuccess = int.TryParse(Console.ReadLine(), out choice);
                if (IsSuccess && (choice <= doctors.Count()))
                    break;

                IsSuccess = false;
                Console.WriteLine("Wybrales niewlasciwa osobe, nacisnij dowolny klawisz aby kontynuowac");
                Console.ReadLine();
            }
            return choice-1;
        }

        private List<int> Add5Nurse()
        {
            var list = new List<int>();
            var nurses = Manage1.ListToAddToScheduleNurse();

            for (int i = 0; i < 5; i++)
            {
                var IsSuccess = false;
                var choice = default(int);
                while (!IsSuccess)
                {
                    Console.Clear();
                    foreach (var x in nurses.Select((value, index) => new { value, index }))
                        Console.WriteLine($"{x.index + 1}. {x.value}");

                    Console.WriteLine("\n");
                    Console.WriteLine("Wybierz pielegniarke do tego dnia");

                    IsSuccess = int.TryParse(Console.ReadLine(), out choice);
                    if (IsSuccess && (choice <= nurses.Count()))
                        break;

                    IsSuccess = false;
                    Console.WriteLine("Wybrales niewlasciwa osobe, nacisnij dowolny klawisz aby kontynuowac");
                    Console.ReadLine();
                }
                nurses.RemoveAt(choice-1);
                list.Add(choice-1);
            }
            return list;
        }

        private int AddAdmin()
        {
            var admins = Manage1.ListToAddToScheduleAdmin();
            var IsSuccess = false;
            var choice = default(int);
            while (!IsSuccess)
            {
                Console.Clear();
                foreach (var x in admins.Select((value, index) => new { value, index }))
                    Console.WriteLine($"{x.index + 1}. {x.value}");

                Console.WriteLine("\n");
                Console.WriteLine("Wybierz admina do tego dnia");

                IsSuccess = int.TryParse(Console.ReadLine(), out choice);
                if (IsSuccess && (choice <= admins.Count()))
                    break;

                IsSuccess = false;
                Console.WriteLine("Wybrales niewlasciwa osobe, nacisnij dowolny klawisz aby kontynuowac");
                Console.ReadLine();
            }
            return choice - 1;
        }

        public void CheckMonth()
        {
            throw new System.NotImplementedException();
        }

        public void Day()
        {
            throw new System.NotImplementedException();
        }
    }
}
