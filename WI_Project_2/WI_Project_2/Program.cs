using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WI_Project_2.Controller;

namespace WI_Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = args.Length > 0 ? args[0] : "friendships.txt";

            var people = FriendshipController.LoadPeople(fileName);

            foreach(var person in people)
            {
                Console.WriteLine(person.Name + " has " + person.Friends.Count + " friends.");
            }

            Console.WriteLine(fileName);
            Console.Read();
        }
    }
}
