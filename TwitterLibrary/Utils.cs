using System;
using System.Collections.Generic;
using System.Linq;
using static TwitterLibrary.Twitter;

namespace TwitterLibrary
{

    /// <summary>
    /// The Utils class.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// InitializeData add the mininal data to work.
        /// </summary>
        /// <returns>Users's list to work.</returns>
        public static List<User> InitializeData()
        {
            return new List<User> {
                new User("Alfonso"),
                new User("Ivan"),
                new User("Alicia"),
            };
        }

        /// <summary>
        /// UserSelectionWizard is a wizard to write message and options, read and control input with minimal logical and return correct value. 
        /// </summary>
        /// <param name="message"><c>message</c> is the main wizard message.</param>
        /// <param name="users"><c>users</c> is the users's list to search users's names, represents a "query".</param>
        /// <param name="excludeUser"><c>excludeUser</c> is the user's name to exclude of the options.</param>
        /// <returns>Selected user.</returns>
        public static User UserSelectionWizard(string message, List<User> users, User excludeUser = null)
        {
            //Declare variable.
            string userInput;

            //White message and options.
            Console.WriteLine(message);
            Console.WriteLine("\t" + string.Join("\n\t", users.Where(user => user.name != excludeUser?.name).Select(user => user.name)));
            Console.Write("Your option? ");

            //Read and control input.
            userInput = Console.ReadLine();

            while (users.Find(user => user.name.ToLower() == userInput.ToLower().Trim() && excludeUser?.name.ToLower().Trim() != userInput.ToLower().Trim()) is null)
            {
                Console.Write("This is not valid input. Please enter an user name: ");
                userInput = Console.ReadLine();
            }

            //Return correct value.
            return users.Find(user => user.name.ToLower() == userInput.ToLower().Trim());
        }

        /// <summary>
        /// DoAction call methods with the necessary to work.
        /// </summary>
        /// <param name="action"><c>user</c> is the identifier of the action.</param>
        /// <param name="user"><c>user</c> is the base user to do the actions.</param>
        /// <param name="users"><c>users</c> is the users's list to work, represents a "query".</param>
        /// <returns>Message with the result</returns>
        public static string DoAction(string action, User user, List<User> users)
        {
            // Switch statement to do the correct action.
            switch (action)
            {
                case "p":
                    Console.Write("Write the message: ");
                    return user.Post(Console.ReadLine());
                case "f":
                    return user.Follow(UserSelectionWizard("\nChoose an user from the following list to follow:", users, user).name);
                case "w":
                    return user.Wall(users);
                default:
                    return "The action '" + action + "' not exists.";
            }

        }

    }
}
