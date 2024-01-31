//==========================================================
// Student Number : S10262480
// Student Name : Leong Kai Jie
// Partner Name : Ethan Goh Junjia
//==========================================================
namespace T02_Group12_PRG2Assignment
{
    class Order
    {
        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime TimeFulfilled { get; set; }
        public List<IceCream> IceCreamList { get; set; } = new List<IceCream>();
        public Order() { }
        public Order(int id, DateTime timereceived)
        {
            Id = id;
            TimeReceived = timereceived;
            IceCreamList = new List<IceCream>();
        }

        public void ModifyIceCream(int index)
        {
            string GetToppingNameByIndex(int index)
            {
                switch (index)
                {
                    case 1: return "Sprinkles";
                    case 2: return "Mochi";
                    case 3: return "Sago";
                    case 4: return "Oreos";
                    default: return string.Empty;
                }
            }

            string GetWaffleFlavorByChoice(int choice)
            {
                switch (choice)
                {
                    case 1: return "Red velvet";
                    case 2: return "Charcoal";
                    case 3: return "Pandan";
                    default: return string.Empty;
                }
            }
            Dictionary<string, bool> premiumFlavor = new Dictionary<string, bool>
    {
        { "Vanilla", false },
        { "Chocolate", false },
        { "Strawberry", false },
        { "Durian", true },
        { "Ube", true },
        { "Sea salt", true }
    };

            if (index >= 0 && index < IceCreamList.Count)
            {
                IceCream iceCreamToModify = IceCreamList[index];

                // Display the current details of the ice cream
                Console.WriteLine($"Current details of Ice Cream at index {index}: {iceCreamToModify}");

                Console.WriteLine("Which property would you like to modify?");
                Console.WriteLine("[1] Option");
                Console.WriteLine("[2] Scoops");
                Console.WriteLine("[3] Flavour");
                Console.WriteLine("[4] Topping");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());





                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Available ice cream options: ");
                        Console.WriteLine("[1] Cup");
                        Console.WriteLine("[2] Cone");
                        Console.WriteLine("[3] Waffle");
                        Console.Write("Enter new option: ");
                        int option = Convert.ToInt32(Console.ReadLine());
                        if (option == 1)
                        {
                            iceCreamToModify.Option = "Cup";
                        }
                        else if (option == 2)
                        {
                            iceCreamToModify.Option = "Cone";
                        }
                        else if (option == 3)
                        {
                            iceCreamToModify.Option = "Waffle";
                        }
                        break;

                    case 2:
                        iceCreamToModify.Flavours.Clear();
                        Console.Write("Enter the number of scoops (1-3): ");
                        int scoops = Convert.ToInt32(Console.ReadLine());
                        iceCreamToModify.Scoops = scoops;
                        List<Flavour> flavours = new List<Flavour>();
                        Console.WriteLine("Available flavors:");
                        foreach (var flavor in premiumFlavor.Keys)
                        {
                            Console.WriteLine($"- {flavor}");
                        }

                        for (int i = 0; i < scoops; i++)
                        {
                            Console.Write($"Enter flavor for scoop #{i + 1}: ");
                            string flavorChoice = Console.ReadLine();
                            bool isPremium = premiumFlavor.TryGetValue(flavorChoice, out bool isPremiumFlavor);

                            flavours.Add(new Flavour(flavorChoice, isPremiumFlavor, 1));
                        }
                        break;

                    case 3:
                        List<Flavour> flavourss = new List<Flavour>();

                        iceCreamToModify.Flavours.Clear();
                        scoops = iceCreamToModify.Scoops;
                        Console.WriteLine("Available flavors:");
                        foreach (var flavor in premiumFlavor.Keys)
                        {
                            Console.WriteLine($"- {flavor}");
                        }

                        for (int i = 0; i < scoops; i++)
                        {
                            Console.Write($"Enter flavor for scoop #{i + 1}: ");
                            string flavorChoice = Console.ReadLine();
                            bool isPremium = premiumFlavor.TryGetValue(flavorChoice, out bool isPremiumFlavor);

                            flavourss.Add(new Flavour(flavorChoice, isPremiumFlavor, 1));
                        }
                        break;

                    case 4:
                        iceCreamToModify.Toppings.Clear();
                        List<Topping> toppingss = new List<Topping>();

                        Console.WriteLine("Available toppings:");
                        Console.WriteLine("[1] Sprinkles");
                        Console.WriteLine("[2] Mochi");
                        Console.WriteLine("[3] Sago");
                        Console.WriteLine("[4] Oreos");

                        Console.Write("Enter toppings (comma-separated, e.g., 1,2): ");
                        string toppingsChoice = Console.ReadLine();
                        string[] selectedToppings = toppingsChoice.Split(',');

                        foreach (var toppingIndex in selectedToppings)
                        {
                            int index = Convert.ToInt32(toppingIndex);
                            string toppingName = GetToppingNameByIndex(index);
                            toppingss.Add(new Topping(toppingName));
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Ice cream not modified.");
                        return;
                }

                Console.WriteLine("Ice cream modified successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index for modifying ice cream.");
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
            return $"Order: {Id}, Time Received: {TimeReceived}, Time Fulfilled: {TimeFulfilled}";
        }

    }


}
