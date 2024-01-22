using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_Group12_PRG2Assignment
{
    public class Waffle : IceCream
    {
        private string WaffleFlavour;

        public Waffle(string option, string waffleFlavour, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings)
        {
            WaffleFlavour = waffleFlavour;
        }

        public new double CalculatePrice()
        {
            // Call the base class CalculatePrice() to get the base price
            double basePrice = base.CalculatePrice();

            // Add additional cost for choosing a specific waffle flavor
            if (!string.IsNullOrEmpty(waffleFlavour))
            {
                basePrice += 3.00;
            }

            return basePrice;
        }

        public override string ToString()
        {
            string waffleInfo = string.IsNullOrEmpty(waffleFlavour) ? "Original Waffle" : $"{waffleFlavour} Waffle";
            return $"{base.ToString()}\nWaffle Type: {waffleInfo}";
        }
    }
}
