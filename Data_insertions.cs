
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


public class DataInsertion
{
    public async Task InsertData()
    {
        string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

        await using var db = NpgsqlDataSource.Create(dbUri);




        /*
                await using (var cmd = db.CreateCommand(@"
        INSERT INTO hotel (name, distance_to_beach, distance_to_centrum) VALUES
            ('Seaside Paradise', 50, 5),
            ('City Center Oasis', 20, 0),
            ('Tranquil Retreat', 100, 10),
            ('Coastal View', 10, 15),
            ('Urban Escape', 30, 2);
        */


        await using (var cmd = db.CreateCommand(@"
insert into room (size, available, hotel_number) values ('S', false, 3);
insert into room (size, available, hotel_number) values ('3XL', false, 3);
insert into room (size, available, hotel_number) values ('L', false, 3);
insert into room (size, available, hotel_number) values ('2XL', false, 4);
insert into room (size, available, hotel_number) values ('M', true, 1);
insert into room (size, available, hotel_number) values ('3XL', false, 2);
insert into room (size, available, hotel_number) values ('3XL', false, 4);
insert into room (size, available, hotel_number) values ('S', true, 5);
insert into room (size, available, hotel_number) values ('L', false, 3);
insert into room (size, available, hotel_number) values ('XS', true, 5);
insert into room (size, available, hotel_number) values ('M', false, 1);
insert into room (size, available, hotel_number) values ('XL', true, 1);
insert into room (size, available, hotel_number) values ('XL', false, 2);
insert into room (size, available, hotel_number) values ('XS', false, 1);
insert into room (size, available, hotel_number) values ('M', true, 4);
insert into room (size, available, hotel_number) values ('L', false, 3);
insert into room (size, available, hotel_number) values ('S', true, 2);
insert into room (size, available, hotel_number) values ('XL', true, 4);
insert into room (size, available, hotel_number) values ('XL', true, 3);
insert into room (size, available, hotel_number) values ('XL', true, 2);
insert into room (size, available, hotel_number) values ('XL', false, 4);
insert into room (size, available, hotel_number) values ('L', true, 1);
insert into room (size, available, hotel_number) values ('XS', false, 2);
insert into room (size, available, hotel_number) values ('L', true, 5);
insert into room (size, available, hotel_number) values ('2XL', true, 5);
insert into room (size, available, hotel_number) values ('XL', false, 2);
insert into room (size, available, hotel_number) values ('M', true, 1);
insert into room (size, available, hotel_number) values ('2XL', true, 2);
insert into room (size, available, hotel_number) values ('2XL', false, 5);
insert into room (size, available, hotel_number) values ('S', false, 5);
insert into room (size, available, hotel_number) values ('2XL', true, 5);
insert into room (size, available, hotel_number) values ('M', false, 4);
insert into room (size, available, hotel_number) values ('L', true, 4);
insert into room (size, available, hotel_number) values ('M', true, 4);
insert into room (size, available, hotel_number) values ('L', true, 1);
insert into room (size, available, hotel_number) values ('XS', false, 3);
insert into room (size, available, hotel_number) values ('M', false, 1);
insert into room (size, available, hotel_number) values ('S', false, 4);
insert into room (size, available, hotel_number) values ('S', false, 4);
insert into room (size, available, hotel_number) values ('M', true, 2);
insert into room (size, available, hotel_number) values ('L', false, 3);
insert into room (size, available, hotel_number) values ('3XL', true, 4);
insert into room (size, available, hotel_number) values ('XL', false, 3);
insert into room (size, available, hotel_number) values ('S', true, 5);
insert into room (size, available, hotel_number) values ('S', true, 1);
insert into room (size, available, hotel_number) values ('2XL', true, 3);
insert into room (size, available, hotel_number) values ('3XL', true, 1);
insert into room (size, available, hotel_number) values ('XL', true, 2);
insert into room (size, available, hotel_number) values ('3XL', true, 5);
insert into room (size, available, hotel_number) values ('M', true, 5);
insert into room (size, available, hotel_number) values ('M', true, 1);
insert into room (size, available, hotel_number) values ('XS', true, 3);
insert into room (size, available, hotel_number) values ('2XL', false, 5);
insert into room (size, available, hotel_number) values ('2XL', true, 2);
insert into room (size, available, hotel_number) values ('L', true, 1);
insert into room (size, available, hotel_number) values ('M', false, 3);
insert into room (size, available, hotel_number) values ('M', true, 4);
insert into room (size, available, hotel_number) values ('S', true, 3);
insert into room (size, available, hotel_number) values ('XL', true, 4);
insert into room (size, available, hotel_number) values ('S', false, 3);
insert into room (size, available, hotel_number) values ('XS', true, 1);
insert into room (size, available, hotel_number) values ('S', false, 4);
insert into room (size, available, hotel_number) values ('XL', false, 4);
insert into room (size, available, hotel_number) values ('M', false, 4);
insert into room (size, available, hotel_number) values ('S', false, 1);
insert into room (size, available, hotel_number) values ('XL', true, 2);
insert into room (size, available, hotel_number) values ('M', false, 3);
insert into room (size, available, hotel_number) values ('M', true, 2);
insert into room (size, available, hotel_number) values ('XS', false, 4);
insert into room (size, available, hotel_number) values ('XS', false, 1);
insert into room (size, available, hotel_number) values ('2XL', true, 1);
insert into room (size, available, hotel_number) values ('2XL', false, 2);
insert into room (size, available, hotel_number) values ('XS', false, 5);
insert into room (size, available, hotel_number) values ('XS', true, 3);
insert into room (size, available, hotel_number) values ('3XL', true, 2);
insert into room (size, available, hotel_number) values ('XL', true, 2);
insert into room (size, available, hotel_number) values ('XL', true, 3);
insert into room (size, available, hotel_number) values ('L', true, 5);
insert into room (size, available, hotel_number) values ('3XL', true, 4);
insert into room (size, available, hotel_number) values ('2XL', true, 4);
insert into room (size, available, hotel_number) values ('M', false, 1);
insert into room (size, available, hotel_number) values ('L', false, 5);
insert into room (size, available, hotel_number) values ('XL', true, 3);
insert into room (size, available, hotel_number) values ('2XL', false, 4);
insert into room (size, available, hotel_number) values ('M', true, 3);
insert into room (size, available, hotel_number) values ('S', false, 1);
insert into room (size, available, hotel_number) values ('XL', false, 3);
insert into room (size, available, hotel_number) values ('2XL', true, 2);
insert into room (size, available, hotel_number) values ('M', true, 4);
insert into room (size, available, hotel_number) values ('XS', true, 2);
insert into room (size, available, hotel_number) values ('M', false, 5);
insert into room (size, available, hotel_number) values ('S', true, 3);
insert into room (size, available, hotel_number) values ('S', false, 5);
insert into room (size, available, hotel_number) values ('XS', true, 3);
insert into room (size, available, hotel_number) values ('S', true, 1);
insert into room (size, available, hotel_number) values ('XS', true, 1);
insert into room (size, available, hotel_number) values ('XS', false, 5);
insert into room (size, available, hotel_number) values ('S', false, 2);
insert into room (size, available, hotel_number) values ('2XL', false, 5);
insert into room (size, available, hotel_number) values ('3XL', false, 3);
insert into room (size, available, hotel_number) values ('XS', false, 1);
insert into room (size, available, hotel_number) values ('2XL', true, 3);
insert into room (size, available, hotel_number) values ('XS', false, 5);
insert into room (size, available, hotel_number) values ('3XL', false, 3);
insert into room (size, available, hotel_number) values ('2XL', false, 5);
insert into room (size, available, hotel_number) values ('XL', true, 4);
insert into room (size, available, hotel_number) values ('XS', false, 2);
insert into room (size, available, hotel_number) values ('S', false, 1);
insert into room (size, available, hotel_number) values ('XS', false, 4);
insert into room (size, available, hotel_number) values ('2XL', false, 2);
insert into room (size, available, hotel_number) values ('L', false, 2);
insert into room (size, available, hotel_number) values ('M', false, 1);
insert into room (size, available, hotel_number) values ('3XL', true, 3);
insert into room (size, available, hotel_number) values ('S', true, 1);
insert into room (size, available, hotel_number) values ('XL', true, 2);
insert into room (size, available, hotel_number) values ('L', true, 3);
insert into room (size, available, hotel_number) values ('XS', false, 4);
insert into room (size, available, hotel_number) values ('3XL', true, 4);
insert into room (size, available, hotel_number) values ('XS', true, 1);
insert into room (size, available, hotel_number) values ('M', false, 2);
insert into room (size, available, hotel_number) values ('L', true, 1);
insert into room (size, available, hotel_number) values ('XL', false, 1);
insert into room (size, available, hotel_number) values ('S', false, 2);
insert into room (size, available, hotel_number) values ('XL', false, 2);
insert into room (size, available, hotel_number) values ('L', false, 2);
insert into room (size, available, hotel_number) values ('XL', false, 2);
insert into room (size, available, hotel_number) values ('3XL', true, 3);
insert into room (size, available, hotel_number) values ('M', true, 3);
insert into room (size, available, hotel_number) values ('3XL', true, 5);
insert into room (size, available, hotel_number) values ('S', false, 1);
insert into room (size, available, hotel_number) values ('S', false, 2);
insert into room (size, available, hotel_number) values ('XL', false, 3);
insert into room (size, available, hotel_number) values ('XS', false, 1);
insert into room (size, available, hotel_number) values ('S', false, 3);
insert into room (size, available, hotel_number) values ('M', true, 4);
insert into room (size, available, hotel_number) values ('XS', false, 1);
insert into room (size, available, hotel_number) values ('M', true, 1);
insert into room (size, available, hotel_number) values ('XS', true, 1);
insert into room (size, available, hotel_number) values ('XS', false, 5);
insert into room (size, available, hotel_number) values ('2XL', false, 3);
insert into room (size, available, hotel_number) values ('S', false, 1);
insert into room (size, available, hotel_number) values ('2XL', true, 2);
insert into room (size, available, hotel_number) values ('XS', true, 2);
insert into room (size, available, hotel_number) values ('L', true, 3);
insert into room (size, available, hotel_number) values ('3XL', true, 5);
insert into room (size, available, hotel_number) values ('3XL', true, 5);
insert into room (size, available, hotel_number) values ('S', true, 5);
insert into room (size, available, hotel_number) values ('2XL', false, 2);
insert into room (size, available, hotel_number) values ('S', false, 2);
insert into room (size, available, hotel_number) values ('M', true, 4);
"))
        {
            await cmd.ExecuteNonQueryAsync();
        };


    }
}


