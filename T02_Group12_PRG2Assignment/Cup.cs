using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_Group12_PRG2Assignment
{
    class Cup : IceCream
    {
        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings) { }

        public override void CalculatePrice(double basePrice)
        {
            // Call the base class CalculatePrice() to get the base price
            basePrice = 4.00;

            // Add additional cost for chocolate-dipped cone

            if (Scoops == 1)
            {
            }
            else if (Scoops == 2)
            {
                basePrice += 1.5;
            }
            else if (Scoops == 3)
            {
                basePrice += 2.5;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
