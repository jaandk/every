using Every;
using Every.Utilities;
using System;
using System.Threading;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ever.y().Day.At(15, 00).Utc().Do(() => Console.WriteLine("test"));

            JobManager.Current.JobExceptionOccurred += Current_JobExceptionOccurred;

            //Ever.y(2).Seconds.Do(() => Console.WriteLine("hoi"));

            Ever.y(31).thOfTheMonth.At(17).Do(() => Console.WriteLine("biem"));

            Thread.Sleep(Timeout.Infinite);
        }

        private static void Current_JobExceptionOccurred(Exception exception)
        {
            Console.WriteLine("lol exception");
        }
    }
}
