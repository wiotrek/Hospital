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

            //var db = new JsonDatabase();

            //db.AddRandomDate();
        }
    }
}
