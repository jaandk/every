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

            //Eve.ry().Second().Do(task);
            //Eve.ry(5).Seconds().Do(task);

            //Eve.ry().Day().Do(task);
            //Eve.ry().Day().At(0, 38, 0).Do(task);

            Eve.ry(DayOfWeek.Monday, DayOfWeek.Friday).Do(task);
            Eve.ry(DayOfWeek.Saturday, DayOfWeek.Sunday).At(14, 30, 0).Do(task);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
