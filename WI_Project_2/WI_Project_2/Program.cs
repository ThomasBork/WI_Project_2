using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WI_Project_2.Controller;

namespace WI_Project_2
{
    class Program
    {
        public static Stopwatch sw;

        static void Main(string[] args)
        {
            BayesStuff();
        }

        static void BayesStuff ()
        {
            var fileName = "SentimentTrainingData.txt";
            sw = new Stopwatch();
            sw.Start();
            var reviews = ReviewController.LoadReviews(fileName);
            Console.WriteLine("Loaded: " + sw.Elapsed.TotalSeconds);

            sw.Restart();
            ReviewController.Tokenize(reviews);
            Console.WriteLine("Tokenized: " + sw.Elapsed.TotalSeconds);

            sw.Restart();
            Console.WriteLine("Begin vocabulary");
            try
            {
                var vocabulary = ReviewController.BuildVocabulary(reviews);
                Console.WriteLine("Vocabulary complete: " + sw.Elapsed.TotalSeconds);
                Console.Read();
            }
            catch(Exception e)
            {
                Console.WriteLine("WRONG!");
                Console.Read();
            }
        }

        static void CliqueStuff ()
        {
            var fileName = "friendships.txt";
            var people = FriendshipController.LoadPeople(fileName);

            int a = 0;
            foreach (var clique in FriendshipController.GetCliques(people, people[0]))
            {
                if (a == 3)
                    break;

                string cliqueString = "";
                foreach (var person in clique)
                {
                    cliqueString += person.Name;
                }
                Console.WriteLine(cliqueString);
            }
            Console.Read();

            foreach (var person in people)
            {
                Console.WriteLine(person.Name + " has " + person.Friends.Count + " friends.");
            }

            Console.WriteLine(fileName);
        }
    }
}
