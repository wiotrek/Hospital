using Library;
using Library.Database;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var manage = new ManageUI();

            manage.Introduce();
            manage.LoginToSystem();
            manage.MainLoop();

        }
    }
}
