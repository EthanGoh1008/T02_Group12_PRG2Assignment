using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_Group12_PRG2Assignment
{
    public class Cone : IceCream
    {
        private bool Dipped;

        public Cone(string option, bool dipped, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings)
        {
            Dipped = dipped;
        }

        public new double CalculatePrice()
        {
            // Call the base class CalculatePrice() to get the base price
            double basePrice = base.CalculatePrice();

            // Add additional cost for chocolate-dipped cone
            if (Dipped)
            {
                basePrice += 2.00;
            }

            return basePrice;
        }
        public override string ToString()
        {
            string dippedInfo = Dipped ? "Chocolate-Dipped" : "Regular";
            return $"{base.ToString()}\nCone Type: {dippedInfo}";
        }
    }
}
