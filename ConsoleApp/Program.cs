using Library.Database;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (true)
            {
                var manage = new ManageUI();
                manage.MainLoop();
            }else
            {
                var d = new JsonDatabase();
                d.AddExampleDate();
            }
            
        }
    }
}
