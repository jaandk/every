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

            Ever.y().Hour.Do(task).Execute();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
