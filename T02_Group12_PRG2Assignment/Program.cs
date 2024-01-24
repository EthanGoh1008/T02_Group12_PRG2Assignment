using T02_Group12_PRG2Assignment;
List<Customer> CusList = new List<Customer>();
List<Order> OrdList = new List<Order>();
List<Order> GoldOrdList = new List<Order>();


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
void DisplayOrd()
{

    Console.WriteLine($"{"ID",-20}{"Time Received",-10}");
    Console.WriteLine(new string('-', 45));

    foreach (var order in OrdList)
    {
        Console.WriteLine($"{order.Id,-20}{order.TimeRecieved,-10}");
        //Console.WriteLine(customer.Rewards.Tier);
        Console.WriteLine();
    }
}
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
            customer.Rewards = new PointCard(point, punch, memstatus);
        }
    }
}

void ListOrder()
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

            Order order1 = new Order(id,timeRec);
            OrdList.Add(order1);


        }
    }

}
string choice;
while (true)
{
    DisplayMenu();
    ListOrder();
    AddCus();
    Console.Write("Enter your option:");
    choice = Console.ReadLine();
    if (choice == "0") break;
    else if (choice == "1")
    {
        DisplayCus();
    }
    else if (choice == "2")
    {
        DisplayOrd();   
    }
    else if (choice == "3")
    {

    }
    else if (choice == "4")
    {

    }
    else if (choice == "5")
    {

    }
    else if (choice == "6")
    {

    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}