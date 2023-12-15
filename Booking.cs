using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
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

        


        Console.WriteLine("Added you as a customer, welcome!");

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
        string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

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

        string insertQuery = "INSERT INTO customer(check_in, check_out, amount_of_people) VALUES ($1, $2, $3, $4, $5)";

        await using (var cmd = db.CreateCommand(insertQuery))
        {
            cmd.Parameters.AddWithValue(checkIn);
            cmd.Parameters.AddWithValue(checkOut);
            cmd.Parameters.AddWithValue(amountOfPeople);
            

            await cmd.ExecuteNonQueryAsync();
        }

        await using (var cmd = db.CreateCommand())
        {
            const string query = "SELECT hotel_name FROM hotel";
        }
    }


    }



