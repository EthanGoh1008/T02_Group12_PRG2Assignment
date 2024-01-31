using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_Group12_PRG2Assignment
{
    class Waffle : IceCream
    {
        private string WaffleFlavour;

        public Waffle(string option, int scoops, List<Flavour> flavours, List<Topping> toppings ,string waffleFlavour) : base(option, scoops, flavours, toppings)
        {
            WaffleFlavour = waffleFlavour;
        }
        /*ask user for waffleflavour by option 1,2,3 
        use if user say yes to add a waffleflavour.
        option 1 = Red velvet
        Option 2 = Charcoal
        option 3 = Pandan Waffle

        */
        public override void CalculatePrice(double baseprice)
        {
            // Call the base class CalculatePrice() to get the base price
            double basePrice = 7.00;
            if (WaffleFlavour != null)
            {
                baseprice += 3;
            }
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
            string waffleInfo = string.IsNullOrEmpty(WaffleFlavour) ? "Original Waffle" : $"{WaffleFlavour} Waffle";
            return $"{base.ToString()}\nWaffle Type: {waffleInfo}";
        }
    }
}
