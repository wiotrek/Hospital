using System;
using System.Linq;

namespace ConsoleApp
{
    public class AdminTools : ManageUI
    {
        /// <summary>
        /// Pobieranie danych do stworzenia nowego uzytkownika 
        /// </summary>
        public void AddNewUser()
        {
            Console.WriteLine("Chcesz dodac nowego uzytkownika? T/N");
            var isContinue = Console.ReadLine();

            if (isContinue == "n" || isContinue == "N")
                return;

            var checkGettingDate = false;
            var login = default(string);
            var pass = default(string);
            var name = default(string);
            var surname = default(string);
            var pesel = default(string);

            while (!checkGettingDate)
            {
                Console.Clear();
                Console.WriteLine("Podaj login");
                login = Console.ReadLine();

                Console.WriteLine("Podaj haslo");
                pass = Console.ReadLine();

                Console.WriteLine("Podaj imie");
                name = Console.ReadLine();

                Console.WriteLine("Podaj nazwisko");
                surname = Console.ReadLine();

                Console.WriteLine("Podaj pesel");
                pesel = Console.ReadLine();

                if (login.Length < 3 || pass.Length < 3 ||
                    name.Length < 3 || surname.Length < 3 || pesel.Length != 11)
                {
                    Console.WriteLine("Jedno z pol ma mniej niz 3 znaki, lub pesel nie ma 11 liczb");
                    Console.WriteLine("Nacisnij dowolny klawisz, aby wprowadzic dane jeszcze raz");
                    Console.ReadLine();
                    checkGettingDate = false;
                }
                else
                    break;
            }

            var choicePosition = this.getPosition();
            var choiceSpecialization = 0;

            if (choicePosition == 2)
                choiceSpecialization = this.getDoctorSpecialization();

            Manage1.CreateNewPerson(login, pass, name, surname, pesel, 
                choicePosition, choiceSpecialization);
        }


        /// <returns>funkcja zwraca wybor stanowiska w int ktory potem przeksztalcimy na enuma</returns>
        private int getPosition()
        {
            var isSuccessChoicePostion = false;
            var choicePostion = default(int);

            while (!isSuccessChoicePostion)
            {
                Console.Clear();
                Console.WriteLine("Wybierz stanowisko: ");
                var listPositions = Manage1.GetNameProffessions();
                foreach (var x in listPositions.Select((value, index) => new { value, index }))
                    Console.WriteLine($"{x.index} - {x.value}");

                isSuccessChoicePostion = int.TryParse(Console.ReadLine(), out choicePostion);
                if (isSuccessChoicePostion && (choicePostion < listPositions.Count))
                    break;

                Console.WriteLine("\n Niepoprawna odpowiedz, wcisnij dowolny przycisk");
                Console.ReadLine();
                isSuccessChoicePostion = false;
            }
            return choicePostion;
        }

        private int getDoctorSpecialization()
        {
            var isSuccessChoicePostion = false;
            var choicePostion = default(int);

            while (!isSuccessChoicePostion)
            {
                Console.Clear();
                Console.WriteLine("Wybierz specjalizacje: ");
                var listSpecialization = Manage1.GetNameSpecializations();
                foreach (var x in listSpecialization.Select((value, index) => new { value, index }))
                    Console.WriteLine($"{x.index} - {x.value}");

                isSuccessChoicePostion = int.TryParse(Console.ReadLine(), out choicePostion);
                if (isSuccessChoicePostion && (choicePostion < listSpecialization.Count))
                    break;

                Console.WriteLine("\n Niepoprawna odpowiedz, wcisnij dowolny przycisk");
                Console.ReadLine();
                isSuccessChoicePostion = false;
            }
            return choicePostion;
        }
    }
}
