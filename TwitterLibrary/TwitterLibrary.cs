using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitterLibrary
{
    /// <summary>
    /// The Twitter class.
    /// </summary>
    public class Twitter
    {

        /// <summary>
        /// Class <c>User</c> generate a user's structure.
        /// </summary>
        public class User
        {
            /// <summary>
            /// Property <c>name</c> represents the user's name.
            /// </summary>
            public string name;

            /// <summary>
            /// Property <c>messages</c> represents a list of user's messages.
            /// </summary>
            public List<Message> messages;

            /// <summary>
            /// Property <c>following</c> represents a list of user's following users.
            /// </summary>
            public List<string> following;

            /// <summary>
            /// This constructor initializes the new User to (<paramref name="name"/>) with an empty list of messages and following.
            /// </summary>
            /// <param name="name"><c>name</c> is the new User's name.</param>
            public User(string name)
            {
                this.name = name;
                messages = new List<Message>();
                following = new List<string>();
            }

            /// <summary>
            /// Post set a message for this user.
            /// </summary>
            /// <param name="message"><c>message</c> is the message's text.</param>
            /// <returns>Confirmation message as <c>string</c>.</returns>
            public string Post(string message)
            {
                Message saveMessage = new Message(message);
                messages.Add(saveMessage);
                return name + " posted ->" + saveMessage.GetMessage();
            }

            /// <summary>
            /// Follow set a following for this user.
            /// </summary>
            /// <param name="user"><c>user</c> is the user to following.</param>
            /// <returns>Confirmation message as <c>string</c>.</returns>
            public string Follow(string user)
            {
                if (!following.Any(f => f.Equals(user)))
                {
                    following.Add(user);
                    return name + " started to follow " + user;
                }
                else
                {
                    return name + " is already following " + user;
                }
            }

            /// <summary>
            /// Wall get the following users's posts.
            /// </summary>
            /// <param name="users"><c>users</c> is the list of users to search posts, represents a "query".</param>
            /// <returns>List of posts as <c>string</c>.</returns>
            public string Wall(List<User> users)
            {
                return string.Join("\n\t", users.Where(user => following.Any(f => f.Equals(user.name))).SelectMany(user => user.messages.Select(m => user.name + ": " + m.GetMessage())));
            }
        }

        /// <summary>
        /// Class <c>Message</c> generate a message's structure.
        /// </summary>
        public class Message
        {
            /// <summary>
            /// Property <c>text</c> represents the message's text.
            /// </summary>
            public string text;

            /// <summary>
            /// Property <c>date</c> represents the message's date.
            /// </summary>
            public DateTime date;

            /// <summary>
            /// This constructor initializes the new Message to (<paramref name="text"/>) with the current date.
            /// </summary>
            /// <param name="text"><c>text</c> is the new Message's text.</param>
            public Message(string text)
            {
                this.text = text;
                date = DateTime.Now;
            }

            /// <summary>
            /// GetMessage get the message's structure.
            /// </summary>
            /// <returns>Message's structure as <c>string</c>.</returns>
            public string GetMessage()
            {
                return " '" + text + "' " + date.ToString();
            }
        }
    }
}
