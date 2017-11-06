using System;
using System.Collections.Generic;
using System.Text;

namespace ReaderDemo
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public override string ToString()
        {
            var person = $"{this.FirstName} {this.LastName} is a {this.JobTitle}";
            return person;
        }
    }
}
