using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
//==========================================================
// Student Number : S10262480
// Student Name : Leong Kai Jie
// Partner Name : Ethan Goh Junjia
//==========================================================
namespace T02_Group12_PRG2Assignment
{
    abstract class IceCream
    {
        public string Option { get; set; }
        public int Scoops { get; set; }
        public List<Flavour> Flavours = new List<Flavour>();

        public List<Topping> Toppings = new List<Topping>();

        public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavours;
            Toppings = toppings;
        }
        public abstract void CalculatePrice(double baseprice);


        public override string ToString()
        {
            return $"IceCream Option: {Option}\nScoops: {Scoops}";
        }

    }
}
