using Every;
using System;
using System.Threading;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Action task = () => Console.WriteLine($"Event happened at '{DateTime.Now}'");

            var job = Ever.y(3, DayOfWeek.Friday).OfTheMonth.At(15, 0).Do(task);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
