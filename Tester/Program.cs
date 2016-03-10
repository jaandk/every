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

            Ever.y(3).rd(Mon.day).OfTheMonth.Do(task);
            Ever.y(Fri.day).Do(task);(Fri)

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
