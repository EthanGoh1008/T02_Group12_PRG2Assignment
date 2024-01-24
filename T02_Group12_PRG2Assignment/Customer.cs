using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_Group12_PRG2Assignment
{
    class Customer
    {
        public string Name { get; set; }
        public int MemberId { get; set; }
        public DateTime Dob { get; set; }
        public Order CurrentOrder { get; set; }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
        public PointCard Rewards { get; set; }
        public Customer() { }
        public Customer(string name, int memberId, DateTime dob)
        {
            Name = name;
            MemberId = memberId;
            Dob = dob;
        }

        public void MakeOrder(Order mo)
        {
            OrderHistory.Add(mo);
        }
        public bool IsBirthday()
        {
            DateTime today = DateTime.Now;
            return today.Day == Dob.Day && today.Month == Dob.Month;
        }
        public override string ToString()
        {
            return $"Customer: {Name}, MemberId: {MemberId}, Birthday: {Dob.ToShortDateString()}, Rewards: {Rewards}";
        }

    }
}
