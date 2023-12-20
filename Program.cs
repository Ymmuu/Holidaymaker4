using Holidaymaker4;
using Npgsql;
using System.Threading.Channels;

bool menu = true;


Table create = new Table();
create.CreateTable();


while (menu)
{
    Console.WriteLine("==== Menu ====");
    Console.WriteLine("1. Add booking");
    Console.WriteLine("2. Remove booking");
    Console.WriteLine("3. Exit");
    Console.WriteLine("=============");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Booking booking = new Booking();
            await booking.AddCustomer();
            await booking.AddBooking();
            break;
        case "2":
            Booking booking1 = new Booking();
            await booking1.RemoveBooking();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("Bye :)");
            menu = false;

            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

}