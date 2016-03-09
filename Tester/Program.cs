using Every;
using System;
using System.Threading;

namespace Tester
{
    class Program
    {
        class Test
        {
            public string Message { get; set; }
        }

        static void Main(string[] args)
        {
            Action task = () => Console.WriteLine($"Event happened at '{DateTime.Now.ToLongDateString()}'");

            var job = Eve.ry().Day.At(16, 0).Do(task);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
