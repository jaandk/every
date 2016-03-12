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

            var job = Ever.y(3).rd(Mon.day).OfTheMonth.At(15, 00).In("Rotterdam");

            var job2 = Ever.y().Second.Do(task);

            //Console.WriteLine(job.Next);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
