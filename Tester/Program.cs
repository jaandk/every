using Every;
using System;
using System.Threading;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Action job = () => Console.WriteLine("hoi");

            Once.After(2).Seconds.Do(job);
            Once.AfterOne.Second.Do(job);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
