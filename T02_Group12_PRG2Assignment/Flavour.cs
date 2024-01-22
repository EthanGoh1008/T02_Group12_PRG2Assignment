using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace T02_Group12_PRG2Assignment
{
    public class Flavour
    {
        private string Name;
        private bool IsPremium;
        private int Quantity;

        public Flavour(string name, bool isPremium, int quantity)
        {
            Name = name;
            IsPremium = isPremium;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Flavour: {name}\nPremium: {isPremium}\nQuantity: {quantity}";
        }

    }
}
