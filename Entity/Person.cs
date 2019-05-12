using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Person:BaseEntity
    {
        public string Name { get; set; }
        public string EnglishName { get; set; }

        public string Email { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if(obj is Person)
        //    {
        //        var person = (Person)obj;

        //        return person.Name == Name && person.EnglishName == EnglishName && Email == person.Email;
        //    }
        //    return false;
        //}
    }
}
