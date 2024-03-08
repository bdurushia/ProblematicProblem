using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            bool cont;
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            Console.Write("\n\tHello, welcome to the random activity generator!\n\tWould you like to generate a random activity?\n\tType 'Yes' or 'No' : ");
            cont = Continue(Console.ReadLine());

            while (cont)
            {
                Console.Clear();

                Console.Write("\n\tWe are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();

                Console.Write("\n\tWhat is your age? ");
                int userAge = int.Parse(Console.ReadLine());

                Console.Clear();

                Console.Write("\n\tWould you like to see the current list of activities?\n\tType 'Yes' or 'No' : ");
                bool seeList = Continue(Console.ReadLine());

                if (seeList)
                {
                    PrintActivities(activities);
                }

                Console.Write("\n\n\tWould you like to add any activities before we generate one?\n\tType 'Yes' or 'No' : ");
                bool addToList = Continue(Console.ReadLine());

                while (addToList)
                {
                    Console.Write("\n\tWhat would you like to add? : ");

                    activities.Add(Console.ReadLine());

                    Console.Clear();

                    Console.Write("\tActivity added! Success!\n");
                    PrintActivities(activities);
                    
                    Console.Write("\n\n\tWould you like to add more? Type 'Yes' or 'No' : ");
                    addToList = Continue(Console.ReadLine());
                }

                while (cont)
                {
                    Console.Clear();

                    ConnectingToDB();

                    Console.Clear();

                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];

                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"\n\t\tOh no! Looks like you are too young to do {randomActivity}");
                        Thread.Sleep(2000);

                        Console.WriteLine("\n\t\t\tPicking something else!");


                        activities.Remove(randomActivity);

                        Thread.Sleep(2000);
                        ConnectingToDB();

                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    


                    Console.Write($"\n\n\tAh, got it! {userName}, your random activity is: {randomActivity}!\n\n\tIs this ok or do you want to grab another activity?\n\tType 'Keep/Quit' to quit or 'Redo' to generate a new random activity : ");
                    cont = Continue(Console.ReadLine());
                }
            }

            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("\n\n\t\t\tGoodbye! See you next time!\n\n\n");
        }

        public static bool Continue(string answer)
        {
            answer.ToLower();

            return answer == "yes" || answer == "redo" ? true : false;
        }

        public static void PrintActivities(List<string> activities)
        {
            foreach (string activity in activities)
            {
                Console.Write($"\n\t\t{activity},");
                Thread.Sleep(250);
            }
        }

        public static void ConnectingToDB()
        {
            Console.Write("\n\t\t\tConnecting to the database  ");
            Thread.Sleep(300);

            for (int i = 0; i < 4; i++)
            {
                Console.Write(". ");
                Console.Beep();
                Thread.Sleep(300);
            }


            Console.Write("\n\t\t\tChoosing your random activity ");
            Console.Beep();
            Thread.Sleep(300);

            for (int i = 0; i < 3; i++)
            {
                Console.Write(". ");
                Console.Beep();
                Thread.Sleep(300);
            }
        }
    }
}