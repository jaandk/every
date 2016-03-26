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

            var job = Ever.y(1).st(Thurs.day).OfTheMonth.Do(task);
            job.Execute();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
