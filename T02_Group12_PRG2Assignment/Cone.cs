using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//==========================================================
// Student Number : S10262480
// Student Name : Leong Kai Jie
// Partner Name : Ethan Goh Junjia
//==========================================================
namespace T02_Group12_PRG2Assignment
{
    class Cone : IceCream
    {
        private bool Dipped;

        public Cone(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, bool dipped) : base(option, scoops, flavours, toppings)
        {
            Dipped = dipped;
        }

        public override void CalculatePrice(double basePrice)
        {
            // Call the base class CalculatePrice() to get the base price
            basePrice = 4.00;
            if (Dipped)
            {
                basePrice += 2;
            }
            // Add additional cost for chocolate-dipped cone

            if ( Scoops == 1)
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
            string dippedInfo = Dipped ? "Chocolate-Dipped" : "Regular";
            return $"{base.ToString()}\nCone Type: {dippedInfo}";
        }
    }
}
