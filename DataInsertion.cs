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

            await using (var cmd = db.CreateCommand(@"
            INSERT INTO hotel (name, distance_to_beach, distance_to_centrum) VALUES
            ('Seaside Paradise', 50, 5),
            ('City Center Oasis', 20, 0),
            ('Tranquil Retreat', 100, 10),
            ('Coastal View', 10, 15),
            ('Urban Escape', 30, 2)"))
        {
            await cmd.ExecuteNonQueryAsync();
        };
        
        
        
        await using (var cmd = db.CreateCommand(@"
INSERT INTO room (number, size, available, hotel_id) VALUES 
(1, 'S', true, 1), (2, 'M', true, 1), (3, 'L', true, 1), 
(4, 'S', true, 1), (5, 'M', true, 1), (6, 'L', true, 1), 
(7, 'S', true, 1), (8, 'M', true, 1), (9, 'L', true, 1), 
(10, 'S', true, 1), (11, 'M', true, 1), (12, 'L', true, 1), 
(13, 'S', true, 1), (14, 'M', true, 1), (15, 'L', true, 1), 
(16, 'S', true, 1), (17, 'M', true, 1), (18, 'L', true, 1), 
(19, 'S', true, 1), (20, 'M', true, 1), (21, 'L', true, 1), 
(22, 'S', true, 1), (23, 'M', true, 1), (24, 'L', true, 1), 
(25, 'S', true, 1), (26, 'M', true, 1), (27, 'L', true, 1), 
(28, 'S', true, 1), (29, 'M', true, 1), (30, 'L', true, 1),
(1, 'S', true, 2), (2, 'M', true, 2), (3, 'L', true, 2), 
(4, 'S', true, 2), (5, 'M', true, 2), (6, 'L', true, 2), 
(7, 'S', true, 2), (8, 'M', true, 2), (9, 'L', true, 2), 
(10, 'S', true, 2), (11, 'M', true, 2), (12, 'L', true, 2), 
(13, 'S', true, 2), (14, 'M', true, 2), (15, 'L', true, 2), 
(16, 'S', true, 2), (17, 'M', true, 2), (18, 'L', true, 2), 
(19, 'S', true, 2), (20, 'M', true, 2), (21, 'L', true, 2), 
(22, 'S', true, 2), (23, 'M', true, 2), (24, 'L', true, 2), 
(25, 'S', true, 2), (26, 'M', true, 2), (27, 'L', true, 2), 
(28, 'S', true, 2), (29, 'M', true, 2), (30, 'L', true, 2),
(1, 'S', true, 3), (2, 'M', true, 3), (3, 'L', true, 3), 
(4, 'S', true, 3), (5, 'M', true, 3), (6, 'L', true, 3), 
(7, 'S', true, 3), (8, 'M', true, 3), (9, 'L', true, 3), 
(10, 'S', true, 3), (11, 'M', true, 3), (12, 'L', true, 3), 
(13, 'S', true, 3), (14, 'M', true, 3), (15, 'L', true, 3), 
(16, 'S', true, 3), (17, 'M', true, 3), (18, 'L', true, 3), 
(19, 'S', true, 3), (20, 'M', true, 3), (21, 'L', true, 3), 
(22, 'S', true, 3), (23, 'M', true, 3), (24, 'L', true, 3), 
(25, 'S', true, 3), (26, 'M', true, 3), (27, 'L', true, 3), 
(28, 'S', true, 3), (29, 'M', true, 3), (30, 'L', true, 3),
(1, 'S', true, 4), (2, 'M', true, 4), (3, 'L', true, 4), 
(4, 'S', true, 4), (5, 'M', true, 4), (6, 'L', true, 4), 
(7, 'S', true, 4), (8, 'M', true, 4), (9, 'L', true, 4), 
(10, 'S', true, 4), (11, 'M', true, 4), (12, 'L', true, 4), 
(13, 'S', true, 4), (14, 'M', true, 4), (15, 'L', true, 4), 
(16, 'S', true, 4), (17, 'M', true, 4), (18, 'L', true, 4), 
(19, 'S', true, 4), (20, 'M', true, 4), (21, 'L', true, 4), 
(22, 'S', true, 4), (23, 'M', true, 4), (24, 'L', true, 4), 
(25, 'S', true, 4), (26, 'M', true, 4), (27, 'L', true, 4), 
(28, 'S', true, 4), (29, 'M', true, 4), (30, 'L', true, 4),
(1, 'S', true, 5), (2, 'M', true, 5), (3, 'L', true, 5), 
(4, 'S', true, 5), (5, 'M', true, 5), (6, 'L', true, 5), 
(7, 'S', true, 5), (8, 'M', true, 5), (9, 'L', true, 5), 
(10, 'S', true, 5), (11, 'M', true, 5), (12, 'L', true, 5), 
(13, 'S', true, 5), (14, 'M', true, 5), (15, 'L', true, 5), 
(16, 'S', true, 5), (17, 'M', true, 5), (18, 'L', true, 5), 
(19, 'S', true, 5), (20, 'M', true, 5), (21, 'L', true, 5), 
(22, 'S', true, 5), (23, 'M', true, 5), (24, 'L', true, 5), 
(25, 'S', true, 5), (26, 'M', true, 5), (27, 'L', true, 5), 
(28, 'S', true, 5), (29, 'M', true, 5), (30, 'L', true, 5);

"))
        {
            await cmd.ExecuteNonQueryAsync();
        };


        /*
                await using (var cmd = db.CreateCommand(@"
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (1, 'Ashien', 'D''Alesco', 'adalesco0@accuweather.com', '+967 (893) 162-9630', '8/19/1959');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (2, 'Roxane', 'Ryle', 'rryle1@tripod.com', '+86 (179) 855-6611', '9/30/2005');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (3, 'Alexandrina', 'Frohock', 'afrohock2@amazon.com', '+420 (471) 999-2230', '12/12/1954');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (4, 'Chev', 'Underwood', 'cunderwood3@shareasale.com', '+850 (298) 565-4346', '8/2/1946');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (5, 'Manda', 'Fearnall', 'mfearnall4@moonfruit.com', '+63 (422) 819-9737', '11/22/1960');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (6, 'Gena', 'Le Galle', 'glegalle5@state.tx.us', '+86 (567) 288-9269', '2/2/1986');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (7, 'Reeta', 'Jakoviljevic', 'rjakoviljevic6@dedecms.com', '+63 (488) 750-3674', '11/25/1989');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (8, 'Bryan', 'Worsnop', 'bworsnop7@exblog.jp', '+81 (596) 556-5125', '8/19/1979');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (9, 'Lucky', 'Mityushin', 'lmityushin8@comsenz.com', '+86 (899) 505-3737', '11/7/1998');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (10, 'Bryon', 'Jessop', 'bjessop9@intel.com', '+375 (733) 500-8107', '5/6/2001');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (11, 'Chevalier', 'Averall', 'caveralla@wix.com', '+7 (472) 835-1551', '9/18/1955');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (12, 'Sonja', 'Hendrick', 'shendrickb@google.com', '+359 (120) 974-6230', '3/31/1970');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (13, 'Drusilla', 'Wragg', 'dwraggc@wikia.com', '+351 (276) 399-3442', '12/9/1945');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (14, 'Federico', 'Absalom', 'fabsalomd@github.com', '+359 (133) 813-5447', '2/24/1947');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (15, 'Donielle', 'Roose', 'droosee@woothemes.com', '+1 (615) 750-0811', '3/10/1994');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (16, 'Shepard', 'Blundel', 'sblundelf@amazon.co.uk', '+57 (744) 581-1852', '9/6/1947');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (17, 'Melitta', 'Flewan', 'mflewang@google.co.jp', '+33 (331) 877-6669', '11/28/1982');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (18, 'Greer', 'Packham', 'gpackhamh@nhs.uk', '+81 (167) 373-8079', '8/7/1987');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (19, 'Sherie', 'Wilby', 'swilbyi@auda.org.au', '+231 (249) 994-6077', '7/13/1989');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (20, 'Kinsley', 'Meo', 'kmeoj@jugem.jp', '+64 (402) 294-5040', '5/27/1976');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (21, 'Magnum', 'Callf', 'mcallfk@sourceforge.net', '+66 (801) 600-9322', '5/2/1995');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (22, 'Mathias', 'Gomme', 'mgommel@ifeng.com', '+62 (944) 743-9784', '5/25/1954');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (23, 'Gretel', 'Moncreiffe', 'gmoncreiffem@sitemeter.com', '+353 (886) 314-4610', '7/5/1954');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (24, 'Carita', 'Licence', 'clicencen@disqus.com', '+358 (134) 897-6898', '9/26/1984');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (25, 'Irvin', 'Sauven', 'isauveno@icq.com', '+507 (901) 820-9597', '10/19/1947');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (26, 'Kora', 'Bysshe', 'kbysshep@storify.com', '+358 (126) 519-4276', '10/17/1983');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (27, 'Julie', 'Cunnah', 'jcunnahq@arizona.edu', '+1 (518) 391-6178', '12/12/1993');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (28, 'Felicdad', 'Audibert', 'faudibertr@woothemes.com', '+380 (482) 973-6817', '5/10/1995');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (29, 'Townsend', 'Puddle', 'tpuddles@illinois.edu', '+374 (361) 882-8855', '2/19/1952');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (30, 'Lillian', 'Szubert', 'lszubertt@friendfeed.com', '+351 (986) 272-0695', '6/19/1984');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (31, 'Jena', 'Tollerfield', 'jtollerfieldu@gnu.org', '+94 (742) 224-9261', '5/29/1975');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (32, 'Kelcey', 'Munroe', 'kmunroev@indiegogo.com', '+7 (452) 878-5275', '6/9/1953');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (33, 'Cull', 'Delyth', 'cdelythw@ebay.co.uk', '+1 (813) 380-0832', '6/23/1955');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (34, 'Hailey', 'Cudiff', 'hcudiffx@oakley.com', '+62 (558) 359-3774', '4/12/1963');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (35, 'Cyb', 'Lethem', 'clethemy@t.co', '+55 (761) 304-6784', '6/19/1995');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (36, 'Reynold', 'Rigate', 'rrigatez@msu.edu', '+225 (594) 271-5170', '1/17/1974');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (37, 'Sela', 'MacDiarmond', 'smacdiarmond10@amazon.com', '+86 (502) 488-5985', '7/8/2003');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (38, 'Hortensia', 'Kassman', 'hkassman11@blogger.com', '+503 (534) 707-7125', '4/9/1963');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (39, 'Bartholemy', 'Derry', 'bderry12@themeforest.net', '+62 (166) 141-9376', '5/10/1978');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (40, 'Carney', 'McFarlan', 'cmcfarlan13@yandex.ru', '+58 (717) 164-4065', '12/18/1946');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (41, 'Alfonso', 'Whitley', 'awhitley14@slideshare.net', '+27 (875) 174-3897', '4/6/1987');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (42, 'Axe', 'Dalglish', 'adalglish15@wsj.com', '+66 (890) 120-8788', '6/8/1990');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (43, 'Connie', 'Valentinetti', 'cvalentinetti16@army.mil', '+62 (569) 518-8300', '5/2/1948');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (44, 'Hilda', 'Blindermann', 'hblindermann17@gnu.org', '+254 (495) 639-1630', '11/15/2005');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (45, 'Morrie', 'Keough', 'mkeough18@linkedin.com', '+92 (253) 425-6634', '7/16/1955');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (46, 'Mattias', 'Rooksby', 'mrooksby19@pinterest.com', '+351 (475) 594-7283', '1/3/1971');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (47, 'Michal', 'Dorro', 'mdorro1a@squarespace.com', '+86 (115) 852-9077', '7/23/1976');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (48, 'Allistir', 'Jelk', 'ajelk1b@netscape.com', '+62 (758) 266-0535', '4/3/2003');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (49, 'Bond', 'Shackle', 'bshackle1c@marriott.com', '+86 (540) 812-2160', '2/9/1948');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (50, 'Melania', 'Pandie', 'mpandie1d@google.it', '+51 (689) 823-4139', '2/24/1981');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (51, 'Wilone', 'Lilleman', 'wlilleman1e@free.fr', '+351 (840) 716-9055', '8/11/1977');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (52, 'Roddie', 'Piquard', 'rpiquard1f@cbc.ca', '+1 (274) 332-3158', '8/16/1988');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (53, 'Sofia', 'Fulk', 'sfulk1g@goo.ne.jp', '+967 (471) 358-9626', '9/26/2005');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (54, 'Yelena', 'Rolingson', 'yrolingson1h@google.com', '+57 (300) 502-2761', '1/25/1952');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (55, 'Doll', 'Cornick', 'dcornick1i@cloudflare.com', '+1 (311) 257-0902', '6/18/1988');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (56, 'Quentin', 'Turbayne', 'qturbayne1j@marriott.com', '+44 (375) 960-5768', '2/7/1985');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (57, 'Dari', 'Dunkerly', 'ddunkerly1k@ow.ly', '+58 (369) 829-2255', '12/29/1986');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (58, 'Clyve', 'Snowsill', 'csnowsill1l@quantcast.com', '+63 (759) 894-6797', '8/22/1972');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (59, 'Lothario', 'McIlraith', 'lmcilraith1m@businessweek.com', '+62 (211) 973-7944', '8/21/1960');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (60, 'Briano', 'McNalley', 'bmcnalley1n@photobucket.com', '+86 (739) 121-8597', '11/27/1959');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (61, 'Conroy', 'Royden', 'croyden1o@hexun.com', '+46 (408) 914-8854', '3/30/2005');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (62, 'Darleen', 'Rigmand', 'drigmand1p@webmd.com', '+66 (131) 993-5052', '4/16/1990');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (63, 'Alica', 'Flaune', 'aflaune1q@cargocollective.com', '+86 (962) 797-4570', '12/30/1977');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (64, 'Guillaume', 'Jonsson', 'gjonsson1r@mozilla.org', '+55 (245) 304-7513', '6/3/1966');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (65, 'Rhona', 'Milvarnie', 'rmilvarnie1s@addtoany.com', '+62 (139) 837-9575', '6/17/1993');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (66, 'Pavia', 'Jagg', 'pjagg1t@gnu.org', '+7 (715) 821-6210', '1/15/1986');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (67, 'Natal', 'Tither', 'ntither1u@cdc.gov', '+55 (105) 965-7882', '4/17/1977');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (68, 'Julina', 'McKinlay', 'jmckinlay1v@soundcloud.com', '+81 (716) 542-1083', '10/2/1996');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (69, 'Evan', 'Stammers', 'estammers1w@etsy.com', '+976 (344) 427-2875', '4/24/1958');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (70, 'Monah', 'Fuge', 'mfuge1x@businessweek.com', '+233 (179) 465-1941', '5/11/1950');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (71, 'Laney', 'Feighney', 'lfeighney1y@bigcartel.com', '+55 (303) 824-5897', '1/1/1952');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (72, 'Ax', 'Spark', 'aspark1z@bigcartel.com', '+63 (399) 752-2479', '10/23/1981');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (73, 'Lauretta', 'Basey', 'lbasey20@census.gov', '+225 (647) 832-6242', '3/18/2005');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (74, 'Crin', 'Kitchin', 'ckitchin21@squarespace.com', '+33 (230) 552-5801', '8/13/1950');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (75, 'Lorry', 'Gladebeck', 'lgladebeck22@uol.com.br', '+54 (158) 540-4532', '3/24/1979');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (76, 'Natal', 'Leser', 'nleser23@umich.edu', '+46 (146) 557-1529', '4/27/1977');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (77, 'Nataniel', 'Trunchion', 'ntrunchion24@is.gd', '+62 (964) 733-0123', '6/9/1970');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (78, 'Albertine', 'Bowne', 'abowne25@toplist.cz', '+375 (648) 209-4952', '5/29/1949');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (79, 'Wilie', 'Pickton', 'wpickton26@nps.gov', '+33 (217) 973-8278', '8/12/1991');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (80, 'Del', 'Hurrell', 'dhurrell27@a8.net', '+47 (912) 415-5805', '6/18/2003');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (81, 'Roselin', 'Kirk', 'rkirk28@imgur.com', '+55 (832) 422-3958', '6/16/1959');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (82, 'Julita', 'Kalisch', 'jkalisch29@deliciousdays.com', '+33 (553) 588-4628', '4/24/1994');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (83, 'Alonso', 'Linforth', 'alinforth2a@house.gov', '+1 (561) 820-6795', '10/1/1978');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (84, 'August', 'Hetterich', 'ahetterich2b@woothemes.com', '+62 (871) 700-8401', '8/28/1951');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (85, 'Urson', 'DeSousa', 'udesousa2c@goo.gl', '+1 (206) 714-7283', '9/28/1991');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (86, 'Hubey', 'Kellie', 'hkellie2d@economist.com', '+254 (583) 380-9561', '8/7/1986');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (87, 'Dexter', 'Hunte', 'dhunte2e@buzzfeed.com', '+86 (863) 954-4644', '2/20/1961');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (88, 'Othilie', 'Pagel', 'opagel2f@bluehost.com', '+81 (726) 600-4787', '8/20/1975');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (89, 'Simone', 'Anniwell', 'sanniwell2g@va.gov', '+86 (366) 307-3728', '12/11/1972');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (90, 'Alick', 'Hawkes', 'ahawkes2h@independent.co.uk', '+33 (375) 111-8503', '8/1/1982');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (91, 'Dorette', 'Twittey', 'dtwittey2i@cmu.edu', '+351 (835) 886-1218', '7/1/1961');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (92, 'Eleni', 'Ascough', 'eascough2j@freewebs.com', '+261 (157) 217-2287', '6/30/1985');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (93, 'Germaine', 'Schultz', 'gschultz2k@pen.io', '+7 (889) 424-6424', '8/29/1958');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (94, 'Annalee', 'Brine', 'abrine2l@usgs.gov', '+46 (330) 444-5786', '1/23/1982');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (95, 'Giffard', 'Bodle', 'gbodle2m@theglobeandmail.com', '+33 (876) 215-9117', '9/5/1956');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (96, 'Alberta', 'Vanderson', 'avanderson2n@symantec.com', '+7 (700) 560-9960', '11/14/1976');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (97, 'Ingeborg', 'Pawden', 'ipawden2o@symantec.com', '+353 (694) 146-3453', '9/14/1981');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (98, 'Conrade', 'cornhill', 'ccornhill2p@wp.com', '+298 (241) 795-9659', '10/29/1961');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (99, 'Roma', 'Rekes', 'rrekes2q@google.it', '+84 (904) 210-1514', '12/7/1985');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (100, 'Maggee', 'Musker', 'mmusker2r@macromedia.com', '+48 (509) 897-6350', '3/18/2001');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (101, 'Delphine', 'Whelband', 'dwhelband2s@msn.com', '+7 (956) 973-3362', '7/14/1951');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (102, 'Rosalie', 'Evans', 'revans2t@bravesites.com', '+33 (595) 878-0613', '12/24/1962');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (103, 'Thaxter', 'Caville', 'tcaville2u@mapquest.com', '+86 (300) 102-3831', '7/22/1978');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (104, 'Adele', 'Sinderland', 'asinderland2v@bravesites.com', '+234 (985) 847-6886', '1/19/1962');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (105, 'Chiquia', 'Abdie', 'cabdie2w@skyrock.com', '+30 (500) 722-7728', '8/14/1989');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (106, 'Merola', 'Cranham', 'mcranham2x@netvibes.com', '+48 (123) 850-4522', '12/9/2004');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (107, 'Atlanta', 'Trye', 'atrye2y@printfriendly.com', '+62 (854) 641-7147', '12/22/1983');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (108, 'Teena', 'Van der Hoven', 'tvanderhoven2z@fastcompany.com', '+595 (730) 921-2349', '12/20/1999');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (109, 'Keefe', 'Hedney', 'khedney30@so-net.ne.jp', '+7 (645) 939-8335', '8/18/1990');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (110, 'Wenona', 'Littefair', 'wlittefair31@abc.net.au', '+86 (852) 359-9029', '11/9/1987');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (111, 'Queenie', 'Sidebottom', 'qsidebottom32@prlog.org', '+86 (790) 798-5867', '1/5/1996');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (112, 'Renata', 'Castanone', 'rcastanone33@answers.com', '+63 (416) 491-8633', '10/8/1948');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (113, 'Filippa', 'Merill', 'fmerill34@diigo.com', '+86 (913) 215-0102', '1/17/1973');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (114, 'Sig', 'Feehely', 'sfeehely35@wisc.edu', '+62 (774) 369-5352', '9/1/1976');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (115, 'Cynthie', 'Blundan', 'cblundan36@jalbum.net', '+86 (352) 181-8043', '5/27/1987');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (116, 'Stevie', 'Landells', 'slandells37@mapy.cz', '+30 (953) 651-2047', '3/19/1975');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (117, 'Llewellyn', 'Calvie', 'lcalvie38@tinyurl.com', '+63 (414) 585-5190', '11/17/1979');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (118, 'Marin', 'Grainger', 'mgrainger39@bloglines.com', '+52 (902) 336-9600', '10/21/1995');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (119, 'Rosanne', 'MacElane', 'rmacelane3a@apple.com', '+1 (520) 267-2812', '10/17/1998');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (120, 'Enrika', 'Blase', 'eblase3b@amazon.co.uk', '+504 (199) 815-2943', '10/13/1982');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (121, 'Ely', 'Latchford', 'elatchford3c@rediff.com', '+86 (579) 235-8108', '12/14/1989');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (122, 'Gianna', 'Leathard', 'gleathard3d@wix.com', '+1 (502) 644-8741', '5/17/1963');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (123, 'Seth', 'Macauley', 'smacauley3e@arizona.edu', '+86 (279) 393-8595', '1/20/2002');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (124, 'Cherice', 'Boice', 'cboice3f@flickr.com', '+86 (173) 182-7948', '4/30/1978');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (125, 'Jennilee', 'MacCleay', 'jmaccleay3g@infoseek.co.jp', '+1 (847) 574-8089', '3/18/1999');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (126, 'Henrietta', 'Quenell', 'hquenell3h@gmpg.org', '+386 (820) 452-3386', '5/29/1995');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (127, 'Binky', 'Frarey', 'bfrarey3i@tmall.com', '+62 (685) 313-9335', '1/31/1945');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (128, 'Elvis', 'Carabine', 'ecarabine3j@vimeo.com', '+420 (811) 897-1910', '8/7/1946');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (129, 'Dolph', 'Cordel', 'dcordel3k@paypal.com', '+351 (586) 256-1424', '5/7/1981');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (130, 'Bertie', 'Secretan', 'bsecretan3l@icio.us', '+86 (557) 605-8616', '9/21/1971');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (131, 'Ramsey', 'Robb', 'rrobb3m@ezinearticles.com', '+81 (116) 400-8858', '6/10/1975');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (132, 'Simon', 'Kliemke', 'skliemke3n@forbes.com', '+380 (462) 244-3161', '1/20/1988');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (133, 'Tatiania', 'Bitcheno', 'tbitcheno3o@elegantthemes.com', '+234 (397) 780-3988', '2/26/1959');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (134, 'Worthington', 'Ive', 'wive3p@ebay.co.uk', '+351 (296) 684-5396', '5/18/1989');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (135, 'Tamera', 'Plesing', 'tplesing3q@clickbank.net', '+593 (523) 705-9958', '8/15/1979');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (136, 'Durand', 'McGeoch', 'dmcgeoch3r@liveinternet.ru', '+234 (819) 116-3654', '9/30/1965');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (137, 'Farlie', 'Dawby', 'fdawby3s@nih.gov', '+33 (427) 748-4938', '1/16/1989');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (138, 'William', 'Manchett', 'wmanchett3t@fema.gov', '+55 (181) 962-6633', '7/27/1945');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (139, 'Saunder', 'Jezard', 'sjezard3u@feedburner.com', '+1 (404) 404-7647', '4/29/1964');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (140, 'Pascale', 'Burless', 'pburless3v@abc.net.au', '+63 (200) 157-8542', '7/15/1947');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (141, 'Uriah', 'Lumsdall', 'ulumsdall3w@joomla.org', '+63 (182) 995-3621', '7/28/2002');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (142, 'Gran', 'Castenda', 'gcastenda3x@live.com', '+86 (646) 940-3097', '4/26/1981');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (143, 'Maddy', 'Loache', 'mloache3y@dailymail.co.uk', '+48 (612) 974-2943', '3/31/1955');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (144, 'Torie', 'Limming', 'tlimming3z@google.es', '+86 (433) 191-4273', '2/15/1958');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (145, 'Dare', 'Stener', 'dstener40@storify.com', '+86 (345) 592-5464', '4/17/1966');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (146, 'Karolina', 'Gheorghe', 'kgheorghe41@dropbox.com', '+380 (137) 200-4976', '4/2/1955');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (147, 'Erroll', 'Barden', 'ebarden42@barnesandnoble.com', '+351 (390) 393-3148', '12/13/1967');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (148, 'Vinnie', 'Di Biagio', 'vdibiagio43@cnbc.com', '+86 (802) 966-4204', '2/10/1945');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (149, 'Claire', 'Luxford', 'cluxford44@dagondesign.com', '+380 (369) 865-7652', '12/1/2005');
        insert into customer (id, name, surname, email, phone_number, date_of_birth) values (150, 'Francklyn', 'Acklands', 'facklands45@psu.edu', '+81 (733) 214-6253', '1/7/1993');

                insert into addons (label)
                values ('extra_bed'),
               ('half_board'),
               ('all_inclusive');


        "))
                {
                    await cmd.ExecuteNonQueryAsync();
                }*/


    }



}