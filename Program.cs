using System;
using TreesLesson.Properties;

namespace TreesLesson
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Tree<int> numbers = new Tree<int>(12);
            numbers.Insert(35);
            numbers.Insert(48);
            numbers.Insert(22);
            numbers.Insert(9);
            numbers.Insert(13);
            numbers.Insert(33);
            numbers.Insert(47);
            numbers.Insert(29);
            numbers.Insert(50);
            numbers.Insert(60);


            Console.WriteLine(numbers.Left.Value);
            Console.WriteLine(numbers.Right.Value);
            Console.WriteLine(numbers.Height());
            numbers.PrintLevels();
            Tree<int> result = numbers.PreOrderSearch(29);
            Console.WriteLine("\nResult: " + result.Value);
            Console.WriteLine("Found {0} at depth {1}", result.Value, result.Depth());
        }
    }
}