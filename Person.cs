using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _20241128_TextSerializationDemo
{
    public class Person 
    {
        private short _key;

        public Person()
        {
                
        }

        public Person(short key)
        {
            _key = key;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2}), [Key = {3}]", Id, Name, Age, _key);
        }
    }
}
