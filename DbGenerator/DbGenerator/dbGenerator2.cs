using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbGenerator
{
    static class DbGenerator2
    {
        private static void Main()
        {
            const string cs = @"server=localhost;userid=root;password=Password;database=ClothingStore";
            
            using var con = new MySqlConnection(cs);
            con.Open();
            
            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SET FOREIGN_KEY_CHECKS=0";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "DROP TABLE IF EXISTS categories";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "CREATE TABLE categories (id INTEGER PRIMARY KEY AUTO_INCREMENT, category VARCHAR(200) UNIQUE NOT NULL )";
            cmd.ExecuteNonQuery();
            
            string[] categories = { "Kvinder", "Drenge", "Piger" };
            string[] categoryNames = { "Kvinde", "Drenge", "Pige" };

            foreach (var category in categories)
            {
                cmd.CommandText = $"INSERT INTO categories(category) VALUES('{category}')";
                cmd.ExecuteNonQuery();
            }
  
            
            
            cmd.CommandText = "DROP TABLE IF EXISTS types";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "CREATE TABLE types (id INTEGER PRIMARY KEY AUTO_INCREMENT, type VARCHAR(200) UNIQUE NOT NULL, kvinder INT DEFAULT 1, drenge INT DEFAULT 1, Piger INT DEFAULT 1)";
            cmd.ExecuteNonQuery();
            
            string[] types = { "Trøjer", "Bukser", "T-shirts", "Strømper", "Jakker", "Jeans", "Sportstøj", "Shorts", "Undertøj", "Nattøj", "Badetøj" };
            string[] typeNames =
            {
                "trøje", "bukser", "t-shirt", "strømper", "jakke", "jeans", "sportstøj", "shorts", "undertøj", "nattøj",
                "badetøj"
            };
            
            foreach (var type in types)
            {
                cmd.CommandText = $@"INSERT INTO types(type) VALUES('{type}')";
                cmd.ExecuteNonQuery();
            }
            
            

            cmd.CommandText = "DROP TABLE IF EXISTS products";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "CREATE TABLE products (prod_id INTEGER PRIMARY KEY AUTO_INCREMENT, prod_name TEXT, category VARCHAR(200), type VARCHAR(200), price INT, description TEXT, material TEXT, produced TEXT, transparency TEXT, views INT DEFAULT 0, week_1 INT DEFAULT 0, week_2 INT DEFAULT 0, week_3 INT DEFAULT 0, week_4 INT DEFAULT 0, investment INT, FOREIGN KEY (category) REFERENCES categories(category), FOREIGN KEY (type) REFERENCES types(type))";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS colours";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE colours (colour_id INTEGER PRIMARY KEY AUTO_INCREMENT, prod_id INT, colour TEXT, img TEXT, kpi INT, sold INT, FOREIGN KEY (prod_id) REFERENCES products(prod_id))";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS sizes";
            cmd.ExecuteNonQuery();
            
             cmd.CommandText = "CREATE TABLE sizes (colour_id INT, prod_id INT NOT NULL, size TEXT, stock INT, FOREIGN KEY (prod_id) REFERENCES products(prod_id), FOREIGN KEY (colour_id) REFERENCES colours(colour_id))";
            cmd.ExecuteNonQuery();

            
            
            string[] colours = { "Lilla", "Blå", "Grå", "Rød", "Grøn", "Lyserød", "Hvid", "Sort", "Beige", "Turkis", "Gul", "Orange", "Flerfarvet" };
            string[] Secondarycolours = { "Lilla", "Blå", "Grå", "Røde", "Grønne", "Lyserøde", "Hvide", "Sorte", "Beige", "Turkis", "Gule", "Orange", "Flerfarvede" };
            string[] tertiarycolours = { "Lilla", "Blåt", "Gråt", "Rødt", "Grønt", "Lyserødt", "Hvidt", "Sort", "Beige", "Turkis", "Gult", "Orange", "Flerfarvet" };

            string[] sizes = { "X-Small", "Small", "Medium", "Large", "X-Large" };
            string description = "Lorem ipsum dolor sit amet, consectetur.";
            string transparency =  "222&23&342&22&22";
            string[] material = {"Bomuld", "Uld", "Denim", "Silke", "Velour", "Hamp", "Nylon", "Polyester", "Acetat", "Elastan", "Læder"};
            string[] produced = {"Danmark", "Beirut", "Kina", "Tyrkiet", "Taiwain", "Indien", "Ungarn", "Afrika", "Nordkorea", "kazakhstan", "Honduras" };

            List<string> images = new List<string>();
            images.Add("Images/ClothesPlaceholders/lilla trøje.tiff");
            images.Add("Images/ClothesPlaceholders/blå bukser.tiff");
            images.Add("Images/ClothesPlaceholders/grå t-shirt.tiff");
            images.Add("Images/ClothesPlaceholders/røde strømper.tiff");
            images.Add("Images/ClothesPlaceholders/grøn jakke.tiff");
            images.Add("Images/ClothesPlaceholders/pink jeans.tiff");
            images.Add("Images/ClothesPlaceholders/hvidt sportstøj.tiff");
            images.Add("Images/ClothesPlaceholders/sorte shorts.tiff");
            images.Add("Images/ClothesPlaceholders/orange undertøj.tiff");
            images.Add("Images/ClothesPlaceholders/turkis nattøj.tiff");
            images.Add("Images/ClothesPlaceholders/gult badetøj.tiff");
            
            Random rd = new Random();

            int itemAmm = 500;
            
            for (int i = 0; i < itemAmm; i++)
            {
                int randCatnum = rd.Next(0, 3);
                int randTypenum = rd.Next(0, 11);
                string randCat = categories[randCatnum];
                string randType = types[randTypenum];
                int randPrice = rd.Next(100, 1000);
                string randMat = material[rd.Next(0, 11)];
                string randProduced = produced[rd.Next(0, 11)];
                string randProdName = typeNames[randTypenum];
                string img = images[randTypenum];
                int views = rd.Next(0, 500);

                
                cmd.CommandText = $@"INSERT INTO products (prod_name, Category, type, price, description, material, produced, transparency, views) VALUES ('{randProdName}', '{randCat}', '{randType}', '{randPrice}', '{description}', '{randMat}', '{randProduced}', '{transparency}', '{views}')";
                cmd.ExecuteNonQuery();

                int randColourAmm = rd.Next(1, 5);
                int[] prevColours = new int[5];
                
                // 0, 2, 4
                // 1, 3, 5, 7,
                // 6,8 ,9,10
                
                for (int j = 0; j < randColourAmm; j++)
                {
                    int randColourIndex;
                    do
                    {
                        randColourIndex = rd.Next(0, 13);  
                    } while (prevColours.Contains(randColourIndex));

                    string randColour = "";
                    if (randTypenum == 0 || randTypenum == 2 || randTypenum == 4)
                    {
                        randColour = colours[randColourIndex];
                    }
                    else if (randTypenum == 1 || randTypenum == 3 || randTypenum == 5 || randTypenum == 7)
                    {
                        randColour = Secondarycolours[randColourIndex];
                    }
                    else if (randTypenum == 6 || randTypenum == 8 || randTypenum == 9 || randTypenum == 10)
                    {
                        randColour = tertiarycolours[randColourIndex];
                    }

                    prevColours[j] = randColourIndex; 
                    
                    int randKpi = rd.Next(0, 101);
                    int randSold = rd.Next(0, 20);

                    cmd.CommandText =
                        string.Format(
                            @"INSERT INTO colours (prod_id, colour, img, kpi, sold) VALUES ((SELECT MAX(prod_id) FROM products), '{0}', '{1}', '{2}', '{3}')", randColour, img, randKpi, randSold);
                    cmd.ExecuteNonQuery();    
                    
                    int randSizeAmm = rd.Next(1, 5);
                    string[] prevSizes = new string[5];
                
                    for (int y = 0; y < randSizeAmm; y++)
                    {
                        string randSize;
                        do
                        { 
                            randSize = sizes[rd.Next(0, 5)];                        
                        } while (prevSizes.Contains(randSize));
                        prevSizes[y] = randSize;
                        int randStock = rd.Next(0, 15);
                
                        cmd.CommandText =
                            string.Format(
                                @"INSERT INTO sizes (colour_id, prod_id, size, stock) VALUES ((SELECT MAX(colour_id) FROM colours), (SELECT MAX(prod_id) FROM colours), '{0}', '{1}')", randSize, randStock);
                        cmd.ExecuteNonQuery();                    
                    }
                }

            }

            cmd.CommandText = "DROP TABLE IF EXISTS orders";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "CREATE TABLE orders (id INTEGER PRIMARY KEY AUTO_INCREMENT, firstname TEXT, lastname TEXT, phonenumber TEXT, email TEXT, city TEXT, street TEXT, zipcode INT, country TEXT, ordered_items TEXT, status TEXT)";
            cmd.ExecuteNonQuery();

            string[] firstnames = { "Jens", "Mikkel", "Patrick", "Nathan", "Rune", "Esben", "Benjamin", "Raymond", "Andreas", "Simone", "Lene", "Lis", "Marianne", "Dorthe", "Pernille"};
            string[] lastnames = { "Jensen", "Larsen", "Pedersen", "Hansen", "Thorsen", "Mikkelsen", "Pedersen"};
            string[] status = { "Pending", "Fulfilled", "Canelled", "Returned" };

            for (int i = 0; i < 75; i++)
            {
                string randFirstName = firstnames[rd.Next(0, 14)];
                string randLastName = lastnames[rd.Next(0, 6)];
                string phonenumber = "+45" + rd.Next(10000000,99999999);
                string email = randFirstName + randLastName + "@hotmail.com";
                string city = "random fucking city";
                string street = "random fucking adress 123";
                int zipcode = rd.Next(1000, 9999);
                string country = "Danmark";
                string currentStatus = status[rd.Next(0,3)];

                string order = "";
                
                for (int j = 0; j < rd.Next(1,3); j++)
                {
                    int itemId = rd.Next(0, itemAmm);
                    string colour = colours[rd.Next(0,13)];
                    string size = sizes[rd.Next(0, 5)];

                    order += itemId +" "+ colour +" "+ size + ", ";
                }
                cmd.CommandText = $@"INSERT INTO orders (firstname, lastname, phonenumber, email, city, street, zipcode, country, ordered_items, status) VALUES ('{randFirstName}', '{randLastName}', '{phonenumber}', '{email}', '{city}', '{street}', '{zipcode}', '{country}', '{order}', '{currentStatus}')";
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = "DROP TABLE IF EXISTS login";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE login (id INTEGER PRIMARY KEY AUTO_INCREMENT, username TEXT, hashed_password TEXT, access_token TEXT)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = string.Format("INSERT INTO login (username, hashed_password, access_token) VALUES ('AdminLogin1', '{0}', '{1}')", EasyEncryption.SHA.ComputeSHA256Hash("AdminPassword1"), EasyEncryption.SHA.ComputeSHA256Hash(DateTime.Now.ToString()));
            cmd.ExecuteNonQuery();

            cmd.CommandText = "ALTER TABLE types ALTER COLUMN kvinder SET DEFAULT 0";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "ALTER TABLE types ALTER COLUMN Piger SET DEFAULT 0";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "ALTER TABLE types ALTER COLUMN drenge SET DEFAULT 0";
            cmd.ExecuteNonQuery();

            string[] monthsArr =
            {
                "Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", "August", "Septemper", "Oktober",
                "November", "December"
            };

            string appString = "";
            DateTime date = DateTime.Now;
            string year = date.Year.ToString();
            string months = date.Month.ToString();
            int month = date.Month;
            
            // foreach (var month in monthsArr)
            // {
            //     DateTime date = DateTime.Now;
            //     string year = date.Year.ToString();
            //     string months = date.Month.ToString();
            //     appString = appString + month + "_" + year + " " + "TEXT,";
            // }
            
            appString = appString + "1_" + monthsArr[month-1] + "_" + year + " " + "TEXT";

            cmd.CommandText = "DROP TABLE IF EXISTS kpi";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = string.Format("CREATE TABLE kpi (prod_id INT, {0}, FOREIGN KEY (prod_id) REFERENCES products(prod_id))", appString);
            cmd.ExecuteNonQuery();

            for (int i = 1; i < itemAmm+1; i++)
            {
                cmd.CommandText = string.Format("INSERT INTO kpi (prod_id, 1_Januar_2022) VALUES ({0}, '0')", i);
                cmd.ExecuteNonQuery();
            }
            
            cmd.CommandText = "SET FOREIGN_KEY_CHECKS=1";
            cmd.ExecuteNonQuery();
            
            con.Close();
        }
    }
}