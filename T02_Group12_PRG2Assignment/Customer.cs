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
        public List<Order> OrderHistory { get; set; }
        public PointCard Rewards { get; set; }
        public Customer(string name, int memberId, DateTime dob)
        {
            Name = name;
            MemberId = memberId;
            Dob = dob;
        }

        public Order MakeOrder()
        {
            Order newOrder = new Order(OrderQueue.GetNextOrderId(), DateTime.Now);
            CurrentOrder = newOrder;
            return newOrder;
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
