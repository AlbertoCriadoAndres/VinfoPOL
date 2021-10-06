using System;
using System.Collections.Generic;
using static TwitterLibrary.Twitter;
using static TwitterLibrary.Utils;

namespace TwitterProgram
{
    /// <summary>
    /// The main class.
    /// </summary>
    class Program
    {

        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Declare variables
            List<User> users;
            bool endApp;

            // Initilize variables
            users = InitializeData();
            endApp = false;

            // Display title as VinfoPOL's Twitter
            Console.WriteLine("VinfoPOL's Twitter\r");
            Console.WriteLine("------------------------");

            while (!endApp)
            {
                // Declare variables
                string result;
                User user; // User to work
                string action;

                // Ask the user to choose a user to work
                user = UserSelectionWizard("\nChoose a user from the following list to start:", users);

                // Ask the user to choose an action
                Console.WriteLine("\nChoose an action from the following list:");
                Console.WriteLine("\tp - Post");
                Console.WriteLine("\tf - Follow");
                Console.WriteLine("\tw - Wall");
                Console.Write("Your action? ");

                action = Console.ReadLine().ToLower().Trim();

                try
                {
                    result = DoAction(action, user, users);

                    Console.WriteLine("Result:");
                    Console.WriteLine("------------------------\n");
                    Console.WriteLine("\t" + result + "\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");

                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }

    }
}