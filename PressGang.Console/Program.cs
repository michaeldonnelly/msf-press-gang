using System;

namespace PressGang.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PressGang.Core.Data.Initialize.ResourceLocations();
            System.Console.WriteLine("Hello World!");
        }
    }
}
