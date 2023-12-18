using Npgsql;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Table
{


    public async Task CreateTable()
    {
        string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

        await using var db = NpgsqlDataSource.Create(dbUri);



      
       /*

        // Drop the tables with CASCADE
        await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS room CASCADE"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

        await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS booking CASCADE"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

        await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS customer CASCADE"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

        await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS hotels_to_addons CASCADE"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

        await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS addons CASCADE"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

        await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS hotel CASCADE"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

        */

        await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS customer (id SERIAL PRIMARY KEY, name VARCHAR, surname VARCHAR, email VARCHAR, phone_number VARCHAR, date_of_birth DATE)"))
        {
            await cmd.ExecuteNonQueryAsync();
        }


        await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS booking (id SERIAL PRIMARY KEY, customer INT references customer(id), check_in DATE, check_out DATE, amount_of_people INT, extra_amenities TEXT, is_deleted BOOL)"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

        await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS hotel (number SERIAL PRIMARY KEY, name VARCHAR, distance_To_Beach INT, distance_To_Centrum INT)"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

        await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS room (number INT, size VARCHAR, available BOOL, hotel_number INT, PRIMARY KEY (number, hotel_number))"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

        
        


        await using (var cmd = db.CreateCommand("ALTER TABLE hotel ADD CONSTRAINT hotel_number UNIQUE (number)"))
        {
            await cmd.ExecuteNonQueryAsync();
        }


        await using (var cmd = db.CreateCommand("ALTER TABLE room ADD CONSTRAINT fk_room_hotel FOREIGN KEY (hotel_number) REFERENCES hotel(number)"))
        {
            await cmd.ExecuteNonQueryAsync();
        }
        await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS addons (id SERIAL PRIMARY KEY, label TEXT UNIQUE)"))
        {
            await cmd.ExecuteNonQueryAsync();
        }


        await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS hotels_to_addons (id SERIAL PRIMARY KEY, hotel_number INT REFERENCES hotel(number), addon_id INT REFERENCES addons(id), price DECIMAL, UNIQUE (hotel_number, addon_id))"))

        await using (var cmd = db.CreateCommand("ALTER TABLE booking ADD CONSTRAINT fk_booking_room FOREIGN KEY (room_number) REFERENCES room(number)"))

        {
            await cmd.ExecuteNonQueryAsync();
        }

        await using (var cmd = db.CreateCommand("ALTER TABLE booking ADD CONSTRAINT fk_booking_hotel FOREIGN KEY (hotel_number) REFERENCES hotel(number)"))
        {
            await cmd.ExecuteNonQueryAsync();
        }

    }
}
