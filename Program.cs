using Holidaymaker4;
using idcgrupp4;
using Npgsql;
using System.Threading.Channels;

bool menu = true;


Table create = new Table();
create.CreateTable();
DataInsertion insertion = new DataInsertion();
//await insertion.InsertData();



while (menu)
{
    Console.WriteLine("==== Menu ====");
    Console.WriteLine("1. Add booking");
    Console.WriteLine("2. Remove booking");
    Console.WriteLine("3. Alter booking");
    Console.WriteLine("4. Exit");
    Console.WriteLine("=============");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Booking booking = new Booking();
            booking.AddCustomer();
            booking.AddBooking();

            break;
        case "2":
            Booking booking1 = new Booking();
            booking1.RemoveBooking();
            break;
        case "3":
            Console.WriteLine("Search hotels");
            Addon addons = new Addon();
            addons.CreateView();
            Console.ReadKey();
            break;
        case "4":
            Console.Clear();
            Console.WriteLine("Bye :)");
            menu = false;

            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

}