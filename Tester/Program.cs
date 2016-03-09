﻿using Every;
using System;
using System.Threading;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Action task = () => Console.WriteLine($"Event happened at '{DateTime.Now}'");

            var job = Ever.y(3, DayOfWeek.Friday).OfTheMonth.At(15, 0).Do(task);

            // Ever.y(4).th(DayOfWeek.Friday).Do(task);
            // Ever.y().Friday.Do(task);
            // Ever.y().other.Wednesday.At(13, 0).Do(task);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
