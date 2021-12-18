using System;
using System.Diagnostics;

namespace PressGang.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = Core.Data.Initialize.System();

            Debug.WriteLine("\n\n");
            Debug.WriteLine(output);
            Debug.WriteLine("\n\n");

            System.Console.WriteLine("Hello World!");
        }
    }
}
