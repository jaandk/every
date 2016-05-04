using Every;
using System;
using System.Threading;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Action job = () =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"Boem {DateTime.Now.ToString("HH:mm:ss")}");
            };

            Ever.y().Second.Do(job, false);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
