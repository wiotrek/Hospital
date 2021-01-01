using Library;

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
