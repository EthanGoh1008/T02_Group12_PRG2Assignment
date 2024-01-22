using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace T02_Group12_PRG2Assignment
{
    public class IceCream
    {
        private string Option;
        private string Scoops;
        private List<Flavour> Flavours;
        private List<Topping> Toppings;

        public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavours;
            Toppings = toppings;
        }

        public double CalculatePrice()
        {
            double basePrice = 0.0;

            if (option.ToLower() == "single")
            {
                basePrice = 4.00;
            }
            else if (option.ToLower() == "double")
            {
                basePrice = 5.50;
            }
            else if (option.ToLower() == "triple")
            {
                basePrice = 6.50;
            }

            foreach (var flavour in flavours)
            {
                if (flavour.IsPremium)
                {
                    basePrice += 2.0 * flavour.Quantity;
                }
            }

            basePrice += toppings.Count;

            return basePrice;
        }

        public override string ToString()
        {
            return $"Ice Cream Option: {option}\nScoops: {scoops}\nPrice: {CalculatePrice()}";
        }

    }
}
