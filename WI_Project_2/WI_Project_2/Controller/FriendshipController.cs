using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WI_Project_2.Model;

namespace WI_Project_2.Controller
{
    public static class FriendshipController
    {
        public static List<Person> LoadPeople (string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var people = new List<Person>();
            var friendList = new List<string>(); 

            for(var i = 0; i<lines.Length; i+=5)
            {
                var name = lines[i].Substring(lines[i].IndexOf(' ') + 1);
                people.Add(new Person(name));
                friendList.Add(lines[i + 1]);
            }

            for(var i = 0; i<friendList.Count; i++)
            {
                var person = people[i];
                var friendNames = friendList[i].Substring(friendList[i].IndexOf('\t') + 1).Split('\t');
                foreach(var friendName in friendNames)
                {
                    var friend = people.First(p => p.Name == friendName);
                    person.Friends.Add(friend);
                }
            }


            return people;
        }

        public static List<List<Person>> GetCliques (List<Person> people, Person startPerson)
        {
            List<List<Person>> cliques = new List<List<Person>>();

            Stack<List<Person>> cliqueStack = new Stack<List<Person>> ();
            cliqueStack.Push(new List<Person> { startPerson });

            List<List<Person>> processed = new List<List<Person>>();

            while(cliqueStack.Peek() != null)
            {
                var C = cliqueStack.Pop();
                processed.Add(C);

                foreach(var friend in C.Last().Friends)
                {
                    var potentialClique = C.Union(new List<Person> { friend }).ToList();
                    if (IsClique(potentialClique))
                    {
                        cliqueStack.Push(potentialClique);
                    }
                }
            }

            return processed.OrderByDescending(c=>c.Count).ToList();
        }

        public static bool IsClique(List<Person> people)
        {
            return people.TrueForAll(p => p.Friends.Intersect(people).Count() == people.Count - 1);
        }
    }
}
