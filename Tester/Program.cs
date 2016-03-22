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

            var job = Ever.y().Day.At(16, 00).In("Alaska").Do(task);

            job.

            //Console.WriteLine(job.Next);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
