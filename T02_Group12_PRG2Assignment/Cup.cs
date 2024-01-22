using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_Group12_PRG2Assignment
{
    public class Cup : IceCream
    {
        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings) { }

        public new double CalculatePrice()
        {
            double basePrice = base.CalculatePrice();

            if (Option.ToLower() == "waffle")
            {
                basePrice += 3.00;
            }

            return basePrice;
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
