using MySql.Data.MySqlClient;
using System;
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
            foreach (var type in types)
            {
                cmd.CommandText = $@"INSERT INTO types(type) VALUES('{type}')";
                cmd.ExecuteNonQuery();
            }
            
            

            cmd.CommandText = "DROP TABLE IF EXISTS products";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "CREATE TABLE products (prod_id INTEGER PRIMARY KEY AUTO_INCREMENT, prod_name TEXT, category VARCHAR(200), type VARCHAR(200), price INT, description TEXT, material TEXT, produced TEXT, transparency TEXT, FOREIGN KEY (category) REFERENCES categories(category), FOREIGN KEY (type) REFERENCES types(type))";
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
            string[] sizes = { "X-Small", "Small", "Medium", "Large", "X-Large" };
            string description = "Lorem ipsum dolor sit amet, consectetur.";
            string transparency =  "Lorem ipsum dolor sit amet";
            string[] material = {"Bomuld", "Uld", "Denim", "Silke", "Velour", "Hamp", "Nylon", "Polyester", "Acetat", "Elastan", "Læder"};
            string[] produced = {"Danmark", "Beirut", "Kina", "Tyrkiet", "Taiwain", "Indien", "Ungarn", "Afrika", "Nordkorea", "kazakhstan", "Honduras" };
            string img = "Images/bedøvet vuf.png";


            Random rd = new Random();
            
            for (int i = 0; i < 1000; i++)
            {
                string randCat = categories[rd.Next(0, 3)];
                string randType = types[rd.Next(0, 11)];
                int randPrice = rd.Next(100, 1000);
                string randMat = material[rd.Next(0, 11)];
                string randProduced = produced[rd.Next(0, 11)];
                string randProdName = randCat + " " + randType;
                
                cmd.CommandText = $@"INSERT INTO products (prod_name, Category, type, price, description, material, produced, transparency) VALUES ('{randProdName}', '{randCat}', '{randType}', '{randPrice}', '{description}', '{randMat}', '{randProduced}', '{transparency}')";
                cmd.ExecuteNonQuery();

                int randColourAmm = rd.Next(1, 5);
                int[] prevColours = new int[5];
                
                for (int j = 0; j < randColourAmm; j++)
                {
                    int randColourIndex;
                    do
                    {
                        randColourIndex = rd.Next(0, 13);  
                    } while (prevColours.Contains(randColourIndex));

                    string randColour = colours[randColourIndex];
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
            
            cmd.CommandText = "CREATE TABLE orders (id INTEGER PRIMARY KEY AUTO_INCREMENT, firstname TEXT, lastname TEXT, phonenumber TEXT, email TEXT, adress TEXT, zipcode INT, country TEXT, ordered_items TEXT)";
            cmd.ExecuteNonQuery();

            string[] firstnames = { "Jens", "Mikkel", "Patrick", "Nathan", "Rune", "Esben", "Benjamin", "Raymond", "Andreas", "Simone", "Lene", "Lis", "Marianne", "Dorthe", "Pernille"};
            string[] lastnames = { "Jensen", "Larsen", "Pedersen", "Hansen", "Thorsen", "Mikkelsen", "Pedersen"};
            for (int i = 0; i < 25; i++)
            {
                string randFirstName = firstnames[rd.Next(0, 14)];
                string randLastName = lastnames[rd.Next(0, 6)];
                string phonenumber = "+45" + rd.Next(10000000,99999999);
                string email = randFirstName + randLastName + "@hotmail.com";
                string adress = "random fucking adress 123";
                int zipcode = rd.Next(1000, 9999);
                string country = "Danmark";

                string order = "";
                
                for (int j = 0; j < rd.Next(1,3); j++)
                {
                    int itemId = rd.Next(0, 1000);
                    string colour = colours[rd.Next(0,13)];
                    string size = sizes[rd.Next(0, 5)];

                    order += itemId +" "+ colour +" "+ size + ", ";
                }
                cmd.CommandText = $@"INSERT INTO orders (firstname, lastname, phonenumber, email, adress, zipcode, country, ordered_items) VALUES ('{randFirstName}', '{randLastName}', '{phonenumber}', '{email}', '{adress}', '{zipcode}', '{country}', '{order}')";
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = "DROP TABLE IF EXISTS login";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE login (id INTEGER PRIMARY KEY AUTO_INCREMENT, login_id TEXT, password TEXT, hashed_password TEXT)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO login (login_id, password) VALUES ('AdminLogin1', 'AdminPassword1')";

            cmd.CommandText = "SET FOREIGN_KEY_CHECKS=1";
            cmd.ExecuteNonQuery();
            
            con.Close();
        }
    }
}