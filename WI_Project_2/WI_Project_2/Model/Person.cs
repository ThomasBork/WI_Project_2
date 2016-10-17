using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_Project_2.Model
{
    public class Person
    {
        public string Name { get; set; }
        public List<Person> Friends { get; set; }
        public Person(string name)
        {
            this.Name = name;
            this.Friends = new List<Person>();
        }

    }
}
