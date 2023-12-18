using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Holidaymaker4;

internal class Addon
{
    public async Task CreateView()
    {
        string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

        await using var db = NpgsqlDataSource.Create(dbUri);

        await using (var cmd = db.CreateCommand(@"create view hotel_addons as 
            select name, label, price from hotels_to_addons         
            join hotels using (hotel_id)      
            join addons using (addon_id);
            select name, from hotel_addons where label = 'extra_bed'
            intersect 
            select name
            from hotel_addons 
            where label = 'all_inclusive';"))
        {
            await cmd.ExecuteReaderAsync();
        }

    }
}
