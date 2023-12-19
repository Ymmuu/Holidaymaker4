using Npgsql;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime;
using System.Runtime.CompilerServices;
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
                    Console.WriteLine("2. Evening entertainment");
                    Console.WriteLine("3. Children's club");
                    Console.WriteLine("4. Restaurant");
                    Console.WriteLine("5. Extra bed");
                    Console.WriteLine("6. Half pension");
                    Console.WriteLine("7. Full pension");
                    Console.WriteLine("8. Klar");
                    string amenetieChoice = Console.ReadLine();
                    // if time make so just 1 extra dosent have ,
                    switch (amenetieChoice)
                    {
                        case "1":
                            extras += "Pool, ";
                            break;

                        case "2":
                            extras += "Evening entertainment, ";
                            break;

                        case "3":
                            extras += "Children's club, ";
                            break;

                        case "4":
                            extras += "Restaurant, ";
                            break;

                        case "5":
                            extras += "Extra bed, ";
                            break;

                        case "6":
                            extras += "Half pension, ";
                            break;

                        case "7":
                            extras += "Full pension";
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
        /*
                string LastestCustomer = "INSERT INTO booking(customer) SELECT MAX(ID) FROM Customer";
                await using (var cmd = db.CreateCommand(LastestCustomer))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                Console.WriteLine(checkIn);
                Console.WriteLine(checkOut);
                Console.WriteLine(amountOfPeople);
                Console.WriteLine(extras);
        */
        string result = string.Empty;

        const string query = "SELECT MAX(ID) FROM Customer";
        var reader = await db.CreateCommand(query).ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            result += reader.GetInt32(0);

        }
        int latest = int.Parse(result);

        string insertQuery = "INSERT INTO booking(customer, room_number, check_in, check_out, amount_of_people, extra_amenities, is_deleted) VALUES ($1, $2, $3, $4, $5, $6, $7)";

        await using (var cmd = db.CreateCommand(insertQuery))
        {
            cmd.Parameters.AddWithValue(latest);
            cmd.Parameters.AddWithValue(roomNumber);
            cmd.Parameters.AddWithValue(checkIn);
            cmd.Parameters.AddWithValue(checkOut);
            cmd.Parameters.AddWithValue(amountOfPeople);
            cmd.Parameters.AddWithValue(extras);
            cmd.Parameters.AddWithValue(false);

            await cmd.ExecuteNonQueryAsync();
        }

    }


}