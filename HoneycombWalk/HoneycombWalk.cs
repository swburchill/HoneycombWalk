using System;
using System.Collections.Generic;

namespace HoneycombWalk
{
   struct Coordinate_t
   {
      int x, y, s;
      public Coordinate_t(int x, int y, int s)
      {
         this.x = x;
         this.y = y;
         this.s = s;
      }
   }

   public class HoneycombWalkProgram
   {
      static Dictionary<Coordinate_t, int> coordinates;

      static HoneycombWalkProgram()
      {
         coordinates = new Dictionary<Coordinate_t, int>();
      }

      public static int getWalk(int x, int y, int step)
      {
         if ((x == 0) && (y == 0) && (step == 0))
         {
            return 1;
         }

         if ((x > step) || (y > step) || (step <= 0))
         {
            return 0;
         }

         Coordinate_t coordinate = new Coordinate_t(x, y, step);
         int result;

         if (coordinates.ContainsKey(coordinate))
         {
            coordinates.TryGetValue(coordinate, out result);
            return result;
         }
         else
         {
            result = (getWalk(x - 1, y - 1, step - 1) + getWalk(x, y - 1, step - 1) + getWalk(x + 1, y, step - 1) + getWalk(x + 1, y + 1, step - 1) + getWalk(x, y + 1, step - 1) + getWalk(x - 1, y, step - 1));
            coordinates.Add(coordinate, result);
            return result;
         }
      }

      public static int numberOfPaths(int steps)
      {
         return getWalk(0, 0, steps);
      }

      static void Main(string[] args)
      {
         // My solution to https://paradox.kattis.com/problems/honey
         Console.WriteLine("This program generates the number of unique walks possible for a given number 'n' of a hex grid object that returns to the origin.");
         Console.WriteLine("Enter an integer n (less than 15) to generate the number of walks or q to exit:");
         string input = Console.ReadLine();
         int n, r;

         while (input != "q")
         {
            if (int.TryParse(input, out n))
            {
               if (n < 15)
               {
                  r = numberOfPaths(n);
                  Console.WriteLine("For " + n + " steps there are " + r + " paths.");
               }
               else
               {
                  Console.WriteLine("Entered interger is too large to calculate result in reasonable time.");
               }
               Console.WriteLine("\nEnter an integer n to generate the Fibonacci numbers or q to exit:");
            }
            else
            {
               Console.WriteLine("Invalid Input. Enter an integer n to generate the number of walks or q to exit:");
            }
            input = Console.ReadLine();
         }
      }
   }
}
