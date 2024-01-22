using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace T02_Group12_PRG2Assignment
{
    public class Topping
    {
        private string Name;

        public Topping(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Topping: {Name}";
        }
    }
}
