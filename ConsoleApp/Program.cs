using Library.Database;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var manage = new ManageUI();
            manage.MainLoop();

            //jesli chcemy dodac nowe dane mozemy skorzystac z tej funkcji
            //var e = new ExampleDate();
            //e.AddRandomDate();
        }
    }
}
