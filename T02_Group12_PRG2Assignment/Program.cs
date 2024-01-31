﻿using System.Runtime.InteropServices;
using T02_Group12_PRG2Assignment;
List<Customer> CusList = new List<Customer>();
List<Order> OrdList = new List<Order>();
Queue<Order> regQueue = new Queue<Order>();
Queue<Order> goldQueue = new Queue<Order>();
List<Order> OrdHistory = new List<Order>();




//function to run first
OrderCSV();
AddCus();


void DisplayMenu()
{
    Console.WriteLine("---------------- M E N U --------------------");
    Console.WriteLine("[1] List all customers");
    Console.WriteLine("[2] List all current orders");
    Console.WriteLine("[3] Register a new customer");
    Console.WriteLine("[4] Create a customer's order");
    Console.WriteLine("[5] Display order details of a customer");
    Console.WriteLine("[6] Modify order details");
    Console.WriteLine("[0] Exit");
    Console.WriteLine("---------------------------------------------");
}

void DisplayCus()
{

    Console.WriteLine($"{"Name",-20}{"Member ID",-10}{"Date of Birth",-15}");
    Console.WriteLine(new string('-', 45));

    foreach (var customer in CusList)
    {
        Console.WriteLine($"{customer.Name,-20}{customer.MemberId,-10}{customer.Dob.ToShortDateString(),-15}");
        //Console.WriteLine(customer.Rewards.Tier);
        Console.WriteLine();
    }
}
void option5Cus()
{

    Console.WriteLine($"{"Name",-20}{"Member ID",-10}{"Date of Birth",-15}");
    Console.WriteLine(new string('-', 45));
    int i = 0;
    foreach (var customer in CusList)
    {
        i++;
        Console.WriteLine($"{i} {customer.Name,-20}{customer.MemberId,-10}{customer.Dob.ToShortDateString(),-15}");
        //Console.WriteLine(customer.Rewards.Tier);
        Console.WriteLine();
    }
}
/*void DisplayOrd()
{

    Console.WriteLine($"{"ID",-20}{"Time Received",-10}");
    Console.WriteLine(new string('-', 45));

    foreach (var order in OrdList)
    {
        Console.WriteLine($"{order.Id,-20}{order.TimeRecieved,-10}");
        //Console.WriteLine(customer.Rewards.Tier);
        Console.WriteLine();
    }
}*/
void AddCus()
{
    string customerfile = "customers.csv";
    using (StreamReader sr = new StreamReader(customerfile))
    {
        string headerLine = sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string dataRow = sr.ReadLine();
            string[] fields = dataRow.Split(',');

            string name = fields[0];
            int memid = int.Parse(fields[1]);
            DateTime db = DateTime.Parse(fields[2]);
            string memstatus = fields[3];
            int point = int.Parse(fields[4]);
            int punch = int.Parse(fields[5]);

            Customer customer = new Customer(name, memid, db);
            CusList.Add(customer);
            customer.Rewards = new PointCard(point, punch);
            customer.Rewards.Tier = memstatus;
        }
    }
}
void Option5()
{
    // Mapping of premium flavors
    Dictionary<string, bool> premiumFlavor = new Dictionary<string, bool>
    {
        { "Vanilla", false },
        { "Chocolate", false },
        { "Strawberry", false },
        { "Durian", true },
        { "Ube", true },
        { "Sea salt", true }
    };
    bool CheckPremium(Dictionary<string, bool> premiumFlavor, string flavor)
    {
        // Check if the flavor is in the premium flavor mapping
        if (premiumFlavor.TryGetValue(flavor, out bool isPremium))
        {
            return isPremium;
        }
        else
        {
            // Default to false if not found in the mapping (adjust as needed)
            return false;
        }
    }
    option5Cus();
    try
    {
        Console.Write("Please select a Customer: ");
        int cus = Convert.ToInt32(Console.ReadLine()) - 1;
        int selectedCus;
        selectedCus = CusList[cus].MemberId;
        Console.WriteLine(CusList[cus]);
        string orderfile = "orders.csv";
        using (StreamReader sr = new StreamReader(orderfile))
        {
            string headerLine = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string dataRow = sr.ReadLine();
                string[] data = dataRow.Split(',');

                int id = int.Parse(data[0]);
                int memid = int.Parse(data[1]);
                DateTime timeRec = DateTime.Parse(data[2]);
                DateTime timeFul = DateTime.Parse(data[3]);
                string option = data[4];
                int scoops = int.Parse(data[5]);
                string dip = data[6];
                string wafflefla = data[7];



                foreach (var item in CusList)
                {
                    if (memid == item.MemberId)
                    {
                        List<Flavour> flavours = new List<Flavour>();
                        for (int i = 8; i < data.Length && i < 11; i++)
                        {
                            string flavor = data[i];
                            if (!string.IsNullOrEmpty(flavor))
                            {
                                bool isPremium = CheckPremium(premiumFlavor, flavor);
                                flavours.Add(new Flavour(flavor, isPremium, 1));
                            }
                        }
                        List<Topping> toppings = new List<Topping>();
                        for (int i = 11; i < data.Length && i < 15; i++)
                        {
                            string topping = data[i];
                            if (!string.IsNullOrEmpty(topping))
                            {
                                toppings.Add(new Topping(topping));
                            }
                        }
                        IceCream iceCream;
                        switch (option)
                        {
                            case "Waffle":
                                iceCream = new Waffle(option, scoops, flavours, toppings, wafflefla);
                                break;
                            case "Cone":
                                iceCream = new Cone(option, scoops, flavours, toppings, bool.Parse(dip));
                                break;
                            case "Cup":
                                iceCream = new Cup(option, scoops, flavours, toppings);
                                break;
                            default:
                                continue;
                        }
                        Order order = new Order(id, timeRec);
                        order.TimeFulfilled = timeFul;
                        order.AddIceCream(iceCream);
                        item.OrderHistory.Add(order);
                    }
                }

            }
            if (CusList[cus].OrderHistory.Count != 0)
            {
                Console.WriteLine("Order History:");

                foreach (var item in CusList[cus].OrderHistory)
                {
                    //print Order
                    Console.Write("***"); //separator between ice creams
                    Console.Write($"Order ID:{item.Id} ");
                    Console.Write($"Time Received:{item.TimeReceived,-22} ");
                    Console.Write($"Time Fulfilled:{item.TimeFulfilled,-22} ");
                    //print IceCream
                    Console.Write("Ice Creams:");
                    foreach (var iceCream in item.IceCreamList)
                    {
                        Console.Write($"{iceCream.Option,-8}");
                        Console.Write("Scoops:");
                        Console.Write($"{iceCream.Scoops,-5}");
                        // Print flavors
                        Console.Write("Flavours: ");
                        foreach (var flavour in iceCream.Flavours)
                        {
                            Console.Write($"{flavour.Name,-2}, ");
                        }

                        // Print toppings
                        foreach (var topping in iceCream.Toppings)
                        {
                            Console.Write($"{topping,-3} ");
                        }

                        Console.Write("***"); //separator between ice creams
                    }

                    Console.WriteLine("\n");
                }

            }
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        foreach(var item in CusList)
        {
            item.OrderHistory.Clear();
        }
    }
}

void CheckQueue()
{
    Console.WriteLine("Gold Queue: ");
    if (goldQueue.Count != 0)
    {
        foreach (var item in goldQueue)
        {
            Console.WriteLine(item);
        }
    }
    else
    {
        Console.WriteLine("There is nothing inside the queue.");
    }

    Console.WriteLine("\nRegular Queue: ");
    if (regQueue.Count != 0)
    {
        foreach (var item in regQueue)
        {
            Console.WriteLine(item);
        }
    }
    else
    {
        Console.WriteLine("There is nothing inside the queue.");
    }
}

void RegisterNewCustomer()
{
    Console.Write("Enter customer name: ");
    string name = Console.ReadLine();

    Console.Write("Enter customer ID number: ");
    int memberId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter customer date of birth (MM/DD/YYYY): ");
    DateTime dob = DateTime.Parse(Console.ReadLine());

    Customer newCustomer = new Customer(name, memberId, dob);
    newCustomer.Rewards = new PointCard(0, 0); // Assuming initial points and punch card are 0
    CusList.Add(newCustomer);

    // Append the customer information to the customers.csv file
    AppendCustomerToFile(newCustomer);

    Console.WriteLine($"Customer {newCustomer.Name} successfully registered!");
}

void AppendCustomerToFile(Customer customer)
{
    string customerfile = "customers.csv";
    using (StreamWriter sw = new StreamWriter(customerfile, true))
    {
        string customerInfo = $"{customer.Name},{customer.MemberId},{customer.Dob},{customer.Rewards.Tier},{customer.Rewards.Points},{customer.Rewards.PunchCard}";
        sw.WriteLine(customerInfo);
    }
}

void CreateCustomerOrder()
{
    DisplayCus();

    Console.Write("Select a customer (enter the number): ");
    int selectedCustomerIndex = Convert.ToInt32(Console.ReadLine()) - 1;

    Customer selectedCustomer = CusList[selectedCustomerIndex];

    Order newOrder = new Order();

    do
    {
        CreateIceCreamForOrder(newOrder);

        Console.Write("Add another ice cream to the order? (Y/N): ");
    } while (Console.ReadLine().ToUpper() == "Y");

    // Link the new order to the customer's current order
    selectedCustomer.CurrentOrder = newOrder;

    // Append the order to the appropriate queue
    if (selectedCustomer.Rewards.Tier == "Gold")
    {
        goldQueue.Enqueue(newOrder);
    }
    else
    {
        regQueue.Enqueue(newOrder);
    }

    Console.WriteLine("Order has been made successfully!");
}

void CreateIceCreamForOrder(Order order)
{

}

void OrderCSV()
{
    string orderfile = "orders.csv";
    using (StreamReader sr = new StreamReader(orderfile))
    {
        string headerLine = sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string dataRow = sr.ReadLine();
            string[] data = dataRow.Split(',');

            int id = int.Parse(data[0]);
            int memid = int.Parse(data[1]);
            DateTime timeRec = DateTime.Parse(data[2]);
            DateTime timeFul = DateTime.Parse(data[3]);
            string option = data[4];
            int scoops = int.Parse(data[5]);
            string dip = data[6];
            string wafflefla = data[7];
            string fla1 = data[8];
            string fla2 = data[9];
            string fla3 = data[10];
            string top1 = data[11];
            string top2 = data[12];
            string top3 = data[13];
            string top4 = data[14];
            Order order = new Order(id, timeRec);
            OrdList.Add(order);

        }
    }

}

while (true)
{
    string choice;
    DisplayMenu();
    Console.Write("Enter your option:");
    choice = Console.ReadLine();
    if (choice == "0") break;
    else if (choice == "1")
    {
        DisplayCus();
    }
    else if (choice == "2")
    {
        CheckQueue();
    }
    else if (choice == "3")
    {
        RegisterNewCustomer();
    }
    else if (choice == "4")
    {
        CreateCustomerOrder();
    }
    else if (choice == "5")
    {
        Option5();
    }
    else if (choice == "6")
    {

    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}
/*
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
*/