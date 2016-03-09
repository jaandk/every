using Every;
using System;
using System.Threading;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<Job> task = (job) => Console.WriteLine($"Event happened at '{DateTime.Now}'");

            Eve.ry(15).Seconds().Do(task);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
