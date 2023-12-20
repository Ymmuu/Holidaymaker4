using Npgsql;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
namespace idcgrupp4;

public class Booking
{
    public DateOnly CheckDate()
    {
        string choosenDate = Console.ReadLine();
        DateOnly choosenDateCorrected;
        while (!DateOnly.TryParseExact(choosenDate, "yyyy-mm-dd",
                                                        CultureInfo.InvariantCulture,
                                                        DateTimeStyles.None,
                                                        out choosenDateCorrected))
        {
            Console.WriteLine("Not Valid Format");
            choosenDate = Console.ReadLine();
        }
        return choosenDateCorrected;
    }

    public async Task AddCustomer()
    {
        string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

        await using var db = NpgsqlDataSource.Create(dbUri);



        Console.Clear();
        Console.WriteLine("Write first name: ");
        string firstName = Console.ReadLine();
        while (!Regex.IsMatch(firstName, @"^[a-zA-Z]+$") || firstName.Length < 3 || firstName.Length > 25)
        {
            Console.WriteLine("Invalid input. Please use only letters. Minimum 3 letters, maximum 25");
            firstName = Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Write last name: ");
        string lastName = Console.ReadLine();
        while (!Regex.IsMatch(lastName, @"^[a-zA-Z]+$") || lastName.Length < 3 || lastName.Length > 25)
        {
            Console.WriteLine("Invalid input. Please use only letters. Minimum 3 letters, maximum 25");
            lastName = Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Write email: ");
        string email = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Write phone number: ");
        string phoneNumber = Console.ReadLine();
        while (!Regex.IsMatch(phoneNumber, @"^[0-9]+$") || phoneNumber.Length < 7 || phoneNumber.Length > 15)
        {
            Console.WriteLine("Please enter the correct format.");
            phoneNumber = Console.ReadLine();
        }



        Console.Clear();
        Console.WriteLine("Write your date of birth (YYYY-MM-DD): ");
        //call function tryparse date
        DateOnly dateOfBirth = CheckDate();


        Console.Clear();




        Console.WriteLine("Added " + firstName + " " + lastName + " as a customer, welcome!");
        Console.ReadKey();

        string insertQuery = "INSERT INTO customer(name, surname, email, phone_number, date_of_birth) VALUES ($1, $2, $3, $4, $5)";

        await using (var cmd = db.CreateCommand(insertQuery))
        {
            cmd.Parameters.AddWithValue(firstName);
            cmd.Parameters.AddWithValue(lastName);
            cmd.Parameters.AddWithValue(email);
            cmd.Parameters.AddWithValue(phoneNumber);
            cmd.Parameters.AddWithValue(dateOfBirth);

            await cmd.ExecuteNonQueryAsync();
        }




    }



    public async Task AddBooking()
    {
        string dbUri = "Host =localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

        await using var db = NpgsqlDataSource.Create(dbUri);

        Console.Clear();
        Console.WriteLine("What date do you want to check in?");
        DateOnly checkIn = CheckDate();

        Console.Clear();
        Console.WriteLine("What date do you want to check out?");
        DateOnly checkOut = CheckDate();


        Console.WriteLine("How many people are looking to rent a room?");
        int amountOfPeople;
        string amountOfPeopleString = Console.ReadLine();
        while (!int.TryParse(amountOfPeopleString, out amountOfPeople))
        {
            Console.WriteLine("Invalid format");
            amountOfPeopleString = Console.ReadLine();
        }

        Console.Clear();

        var hotelReader = await db.CreateCommand("SELECT id, name FROM hotel").ExecuteReaderAsync();

        Console.WriteLine();
        while (await hotelReader.ReadAsync())
        {
            Console.WriteLine($"{hotelReader.GetInt32(0)} | {hotelReader.GetString(1)}");
        }
        Console.WriteLine("What hotel do you want?");

        int hotelNumber;
        string hotelNumberString = Console.ReadLine();
        while (!int.TryParse(hotelNumberString, out hotelNumber))
        {
            Console.WriteLine("Invalid format");
            hotelNumberString = Console.ReadLine();
        }

        const string roomReader = "SELECT number, size FROM room WHERE available = true AND hotel_id = $1;";
        var command = db.CreateCommand(roomReader);
        command.Parameters.AddWithValue(hotelNumber);

        var RoomReader = await command.ExecuteReaderAsync();
        Console.WriteLine("Hotel Number | Room Size");
        while (await RoomReader.ReadAsync())
        {
            Console.WriteLine($"{RoomReader.GetInt32(0)} | {RoomReader.GetString(1)}");
        }

        Console.WriteLine("What room number to do you want?");

        int roomNumber;
        string roomNumberString = Console.ReadLine();
        while (!int.TryParse(roomNumberString, out roomNumber))
        {
            Console.WriteLine("Invalid format");
            roomNumberString = Console.ReadLine();
        }


        Console.WriteLine("Add extra ameneties?");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");
        string choice = Console.ReadLine();
        var ameneties = true;
        string extras = string.Empty;
        switch (choice)
        {
            case "1":
                while (ameneties)
                {
                    Console.Clear();
                    Console.WriteLine("1. Pool");
                    Console.WriteLine("2. Kvällsunderhållning");
                    Console.WriteLine("3. Barnklubb");
                    Console.WriteLine("4. Restaurang");
                    Console.WriteLine("5. Extrasäng");
                    Console.WriteLine("6. Halvpension");
                    Console.WriteLine("7. Helpension");
                    Console.WriteLine("8. Klar");
                    string amenetieChoice = Console.ReadLine();
                    // if time make so just 1 extra dosent have ,
                    switch (amenetieChoice)
                    {
                        case "1":
                            extras += "Pool, ";
                            break;

                        case "2":
                            extras += "Kvällsunderhållning, ";
                            break;

                        case "3":
                            extras += "Barnklubb, ";
                            break;

                        case "4":
                            extras += "Restaurang, ";
                            break;

                        case "5":
                            extras += "Extrasäng, ";
                            break;

                        case "6":
                            extras += "Halvpension, ";
                            break;

                        case "7":
                            extras += "Helpension";
                            break;

                        case "8":
                            ameneties = false;
                            break;

                    }
                }
                break;

            case "2":
                break;
        }

        string result = string.Empty;

        const string query = "SELECT MAX(ID) FROM Customer";
        var reader = await db.CreateCommand(query).ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            result += reader.GetInt32(0);

        }
        int latest = int.Parse(result);




        string insertQuery = "INSERT INTO booking(customer, hotel_id, room_number, check_in, check_out, amount_of_people, extra_amenities, is_deleted) VALUES ($1, $2, $3, $4, $5, $6, $7, $8)";

        await using (var cmd = db.CreateCommand(insertQuery))
        {
            cmd.Parameters.AddWithValue(latest);
            cmd.Parameters.AddWithValue(hotelNumber);
            cmd.Parameters.AddWithValue(roomNumber);
            cmd.Parameters.AddWithValue(checkIn);
            cmd.Parameters.AddWithValue(checkOut);
            cmd.Parameters.AddWithValue(amountOfPeople);
            cmd.Parameters.AddWithValue(extras);
            cmd.Parameters.AddWithValue(false);


            await cmd.ExecuteNonQueryAsync();
        }

        string result1 = string.Empty;

        const string query1 = "SELECT * FROM Booking where Customer = (SELECT MAX(Customer) FROM Booking)";
        var reader1 = await db.CreateCommand(query1).ExecuteReaderAsync();

        Console.WriteLine("ID    |CustomerID   |CheckIn     |CheckOut    |Guests  |Extra stuff");
        while (await reader1.ReadAsync())
        {
            string convertedDate1 = reader1.GetDateTime(4).ToShortDateString();
            string convertedDate2 = reader1.GetDateTime(5).ToShortDateString();
            Console.WriteLine($"{reader1.GetInt32(0),-5} | {reader1.GetInt32(1),-11} | {reader1.GetInt32(2),-11} | {convertedDate1,-10} | {convertedDate2,-10} | {reader1.GetInt32(6),-6} | {reader1.GetString(7),-15}");
        }
        Console.WriteLine("Press any button to exit into the main menu.");
        Console.ReadKey();
        Console.Clear();
    }

    public async Task RemoveBooking()
    {
        string dbUri = "Host =localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

        await using var db = NpgsqlDataSource.Create(dbUri);

        Console.WriteLine("Booking ID for customer you want to remove: ");
        int bookingID;
        string bookingIDString = Console.ReadLine();
        while (!int.TryParse(bookingIDString, out bookingID))
        {
            Console.WriteLine("Invalid format");
            bookingIDString = Console.ReadLine();



        }
        const string query1 = "SELECT b.ID, b.room_number, b.customer, b.check_in, b.check_out, b.amount_of_people, b.extra_amenities, c.name AS CustomerName FROM Booking b JOIN Customer c ON b.ID = c.ID WHERE b.ID = $1";
        var command = db.CreateCommand(query1);
        command.Parameters.AddWithValue(bookingID);

        var reader2 = await command.ExecuteReaderAsync();
        Console.Clear();
        Console.WriteLine("ID    |Room Number|Customer Name|Check In Date|Check Out Date|Guests  |Extra Stuff");
        while (await reader2.ReadAsync())
        {
            string convertedDate1 = reader2.GetDateTime(3).ToShortDateString();
            string convertedDate2 = reader2.GetDateTime(4).ToShortDateString();
            Console.WriteLine($"{reader2.GetInt32(0),-5} | {reader2.GetInt32(1), -5} | {reader2.GetString(7),-10}  | {convertedDate1,-11} | {convertedDate2,-12} | {reader2.GetInt32(5),-6} | {reader2.GetString(6),-15}");
        }
        Console.WriteLine("Are you sure you want to delete it? Type yes then enter, otherwise leave empty.");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "yes":
                const string remove = "UPDATE booking SET is_deleted = TRUE WHERE id = $1";
                await using (var cmd = db.CreateCommand(remove))
                {
                    cmd.Parameters.AddWithValue(bookingID);
                    //want to type out the ones name and say its booking was removed
                    await cmd.ExecuteNonQueryAsync();
                    Console.WriteLine("Booking was deleted. Press any button to return to main menu.");
                }
                break;
            default:
                break;
        }
        Console.ReadKey();
        Console.Clear();
    }
}



