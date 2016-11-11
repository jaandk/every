using Every;
using System;
using System.Threading;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Ever.y().Day.At(15, 00).Utc().Do(() => Console.WriteLine("test"));

            JobManager.Current.JobExceptionOccurred += Current_JobExceptionOccurred;

            Action job = () =>
            {
                throw new Exception("test");
            };

            Once.After(4).Seconds.Do(job);

            Ever.y(2).Seconds.Do(() => Console.WriteLine("hoi"));

            Thread.Sleep(Timeout.Infinite);
        }

        private static void Current_JobExceptionOccurred(Exception exception)
        {
            Console.WriteLine("lol exception");
        }
    }
}
