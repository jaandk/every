using Every;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<Task> job = 

            Ever.y().Second.Do(async () =>
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(5000);
                    Console.WriteLine($"Boem {DateTime.Now.ToString("HH:mm:ss")}");
                });
            }, false);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
