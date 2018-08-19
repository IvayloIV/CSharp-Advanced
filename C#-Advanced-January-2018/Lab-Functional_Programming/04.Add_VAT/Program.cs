using System;
using System.Linq;

namespace _04.Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = n => n *= 1.2;
            Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList()
                .ForEach(e => Console.WriteLine($"{(addVat(e)):f2}"));
        }
    }
}