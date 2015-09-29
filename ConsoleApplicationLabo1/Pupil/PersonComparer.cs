using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo1
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person p1, Person p2)
        {
            if (p1.Name.Equals(p2.Name) && p1.Age == p2.Age)
                return true;

            return false;
        }
        public int GetHashCode(Person p)
        {
            return (int)Math.Pow(p.Name.GetHashCode(),p.Age);
        }
    }
}
