using T02_Group12_PRG2Assignment;
using System.IO;
using System;
List<Customer> CusList = new List<Customer>();
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

void AddCus()
{
    string orderfile = "customers.csv";
    using (StreamReader sr = new StreamReader(orderfile))
    {
        string headerLine = sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string dataRow = sr.ReadLine();
            string[] fields = dataRow.Split(',');

            string name = fields[0];
            int memid = int.Parse(fields[1]);
            DateTime db = DateTime.Parse(fields[2]);

            Customer customer = new Customer(name,memid,db);

            CusList.Add(customer);
        }
    }
}

void DisplayCus()
{
    foreach (var customer in CusList)
    {
        Console.WriteLine($"Name: {customer.Name}");
        Console.WriteLine($"Member ID: {customer.MemberId}");
        Console.WriteLine($"Date of Birth: {customer.Dob.ToShortDateString()}");
    }
}

void ListOrder()
{
    int header = 14;
    string orderfile = "customers.csv";
        using (StreamReader sr = new StreamReader(orderfile))
        {
            string headerLine = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string dataRow = sr.ReadLine();
                Console.WriteLine(dataRow);
            }
        }

}
string choice;
while (true)
{
    DisplayMenu();
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
        ListOrder();
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