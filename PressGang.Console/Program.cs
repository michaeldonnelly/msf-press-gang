using System;

namespace PressGang.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Core.Data.Initialize.ResourceLocations();
            System.Console.WriteLine("Hello World!");
        }
    }
}
