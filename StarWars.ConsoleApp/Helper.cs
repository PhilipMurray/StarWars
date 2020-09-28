using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.ConsoleApp
{
    public static class Helper
    {
        public static int ReadMegalightInput()
        {
            bool inputSuccess = false;
            int megalights = 0;
            while (!inputSuccess)
            {
                Console.WriteLine("Please enter the distance in megalights you want to travel:");
                var input = Console.ReadLine();

                if (int.TryParse(input, out megalights))
                {
                    inputSuccess = true;
                }
                else
                {
                    Console.WriteLine("INVALID INPUT: please enter a number.");
                }
            }

            return megalights;
        }

        public static void PrintTitle()
        {
            var title = @"
     _______.___________.    ___      .______      
    /       |           |   /   \     |   _  \     
   |   (----`---|  |----`  /  ^  \    |  |_)  |    
    \   \       |  |      /  /_\  \   |      /     
.----)   |      |  |     /  _____  \  |  |\  \----.
|_______/       |__|    /__/     \__\ | _| `._____|
                                                   
____    __    ____  ___      .______          _______.
\   \  /  \  /   / /   \     |   _  \        /       |
 \   \/    \/   / /  ^  \    |  |_)  |      |   (----`
  \            / /  /_\  \   |      /        \   \    
   \    /\    / /  _____  \  |  |\  \----.----)   |   
    \__/  \__/ /__/     \__\ | _| `._____|_______/   ";


            Console.WriteLine(title);
        }

        public static void WriteTableHeader(string column1, string column2)
        {
            Console.WriteLine(new string('_', 63));
            Console.WriteLine($"|{column1,-30}|{column2,-30}|");
        }

        public static void WriteTableRow(string key, string value)
        {
            Console.WriteLine(new string('_', 63));
            Console.WriteLine($"|{key,-30}|{value,-30}|");
        }
    }
}
