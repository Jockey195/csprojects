using CakesAdvanced.Models;

namespace CakesAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var store = new Store("Кондитерская");
            store.Open();
        }
    }
}
