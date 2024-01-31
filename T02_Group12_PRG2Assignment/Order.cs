using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_Group12_PRG2Assignment
{
    class Order
    {
        public int Id {  get; set; }
        public DateTime TimeRecieved {  get; set; }
        public DateTime TimeFulfilled { get; set; }
        public List<IceCream> IceCreamList { get; set; } = new List<IceCream>();
        public Order() { }
        public Order(int id, DateTime timeRecieved)
        {
            Id = id;
            TimeRecieved = timeRecieved;
            IceCreamList = new List<IceCream>();
        }
        
        public void ModifyIceCream(int index, IceCream modifiedIceCream)
        {
            if (index >=0 && index < IceCreamList.Count)
            {
                IceCreamList[index] = modifiedIceCream;
            }
        }

        public void AddIceCream(IceCream iceCream)
        {
            IceCreamList.Add(iceCream);
        }

        public void DeleteIceCream(int index)
        {
            if (index > 0 && index < IceCreamList.Count)
            {
                IceCreamList.RemoveAt(index);
            }
        }

        public double CalculateTotal()
        {
            double total = 0;

            return total;
        }

        public override string ToString()
        {
            return $"Order: {Id}, Time Received: {TimeRecieved}, Time Fulfilled: {TimeFulfilled}, Total: {CalculateTotal()}";
        }

    }

    
}
