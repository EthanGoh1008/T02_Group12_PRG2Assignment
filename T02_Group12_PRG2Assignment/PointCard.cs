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
    class PointCard
    {
        public int Points { get; set; }
        public int PunchCard {  get; set; }
        public string Tier {  get; set; }

        public PointCard(int points, int punchcard)
        {
            Points = points;
            PunchCard = punchcard;
        }
       
        public void AddPoints(int points)
        {
            points += points;
           // Tier = CalculateTier();
        }

        public void RedeemPoints(int points)
        {
            if (Tier == "Silver" || Tier == "Gold")
            {
                Points -= points;
            }
        }

        public void Punch()
        {
            if (PunchCard < 12)
            {
                Points += 1;
            }
            else
            {
                CheckPunchcard();
            }
        }

        private void CheckPunchcard()
        {
            if (PunchCard == 11)
            {
                PunchCard = 0;
            }
        }

     

        public override string ToString()
        {
            return $"Points: {Points}\nMembership Tier: {Tier}\nPunch Card: {PunchCard}";
        }
    }

}
