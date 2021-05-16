using Fundamentals;
using System;

namespace Fundamentals.OutputConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Arrays(3);
            numbers.Insert(10);
            numbers.Insert(20);
            numbers.Insert(30);
            numbers.Insert(40);

            numbers.RemoveAt(index: 3);

            numbers.Print();
            Console.WriteLine("_____________________");

            numbers.Insert(40);
            numbers.Insert(50);

            numbers.RemoveAt(2);

            numbers.Print();

            Console.WriteLine(numbers.IndexOf(item: 40));
            Console.WriteLine(numbers.IndexOf(item: 30));
        }
    }
}
