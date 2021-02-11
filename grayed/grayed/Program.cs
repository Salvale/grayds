using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grayed
{
    class Program
    { //Declare global variables
        static class global
        {
            public static List<int> grades = new List<int>();
            public static System.Random random = new System.Random();
            public static bool maindraw = false;
        }
        static void Main()
        { //Get random list
            for (int i = 0; i < 50; i++)
            {
                int rando = global.random.Next(101);
                global.grades.Add(rando);
            } //If this function was called from draw, it goes back to draw 
            if (global.maindraw)
            {
                DrawEm();
            }
            Detect();
            Console.ReadLine();

        }
        static void Detect()
        { // write the menu text
            Console.WriteLine("Welcome to student grade analyzer");
            Console.WriteLine("1: Display all grades");
            Console.WriteLine("2: Randomize grades");
            Console.WriteLine("3: Display stats");
            Console.WriteLine("4: Count honours");
            Console.WriteLine("5. Remove failing grades");
            Console.WriteLine("6. Exit");
            int command = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            //get and analyze input
            if (command == 1)
            {
                //call function to write student grades
                DrawEm();
            } else if (command == 2)
            {
                //clear array and call main to generate new values
                global.grades.Clear();
                global.maindraw = true;
                Main();
            } else if (command == 3)
            {
                //get highest and lowest list values
                Console.WriteLine("The highest grade is: " + global.grades.Max());
                Console.WriteLine("The lowest grade is: " + global.grades.Min());
                int avg = 0;
                for (int i = 0; i < global.grades.Count; i++)
                {
                    //add all grades together
                    avg += global.grades[i];
                }
                //divide average value by total amount of values, getting the average
                int average = avg / global.grades.Count;
                Console.WriteLine("The average grade = " + average);
            } else if (command == 4)
            {
                //count all honours students
                int onours = 0;
                for (int i = global.grades.Count - 1; i > 0; i--)
                {
                    if (global.grades[i] > 79)
                    {
                        onours++;
                    }
                }
                Console.WriteLine(onours + "students with honours");
            } else if (command == 5)
            {
                //loop through list backwards and remove all failed grades
                for (int i = global.grades.Count - 1; i > 0; i--)
                {
                    if (global.grades[i] < 50)
                    {
                        global.grades.Remove(global.grades[i]);
                    }
                }
                Console.WriteLine("failures removed");
            } else if (command == 6)
            {
                //byebye
                System.Environment.Exit(0);
            } else
            {
                //in the case that the input is not a valid number
                Console.WriteLine("bad prompt buddyo");
            }
            Detect();
        }
        static void DrawEm()
        {
            //loop through grades and assign student numbers
            for (int f = 1; f < global.grades.Count() + 1; f++)
            {
                Console.Write("Student " + f + ": ");
                Console.WriteLine(global.grades[f - 1]);
            }
        }

    }
}
