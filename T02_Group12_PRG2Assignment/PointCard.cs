using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_Group12_PRG2Assignment
{
    class PointCard
    {
        public int Points { get; set; }
        public int PunchCard {  get; set; }
        public string Tier {  get; set; }

        public PointCard(int points, int punchcard,string status)
        {
            Points = points;
            PunchCard = punchcard;
            Tier = status;
        }
       
        public void AddPoints(int points)
        {
            points += points;
            Tier = CalculateTier();
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

        private string CalculateTier()
        {
            if (Points >= 100)
            {
                return "Gold";
            }
            else if (Points >= 50)
            {
                return "Silver";
            }
            else
            {
                return "Ordinary";
            }
        }

        public override string ToString()
        {
            return $"Points: {Points}\nMembership Tier: {Tier}\nPunch Card: {PunchCard}";
        }
    }

}
