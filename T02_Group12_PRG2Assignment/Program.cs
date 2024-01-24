using T02_Group12_PRG2Assignment;

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

string choice;
while (true)
{
    DisplayMenu();
    Console.WriteLine("Enter your option:");
    choice = Console.ReadLine();
    if (choice == "0") break;
    else if (choice == "1")
    {

    }
    else if (choice == "2")
    {

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