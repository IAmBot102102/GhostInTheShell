using System;
using System.Collections.Generic;

namespace GITSSimulation 
{
    class Program 
    {
        public static void QuickCommand() { }
        public static void RepeatedStudy() { }
        public static void SingleSession() 
        {
            GameInstance g = new GameInstance();
        }
        public static void VariableSetMenu() { }

        public static void Main(string[] args) 
        {
            while (true)
            {
                Console.Write("Input Command:");
                int input = Console.Read();
                if (input == -1) { Console.WriteLine("Input something."); return; }
                if (input == 'q') { QuickCommand(); }
                if (input == 'r') { RepeatedStudy(); }
                if (input == 's') { SingleSession(); }
                if (input == 'v') { VariableSetMenu(); }
            }
        }
    }
}