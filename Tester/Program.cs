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

            var job = Ever.y().Second.From(23, 00).To(01, 00).In(-09, 00).Do(task);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
