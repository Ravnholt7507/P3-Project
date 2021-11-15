using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using Org.BouncyCastle.Cms;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"server=localhost;userid=root;password=Password;database=ClothingStore";

            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "DROP TABLE IF EXISTS Orders";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE Orders (id INTEGER primary key auto_increment, name text, ordernum int, items text, adress text, country text, zipcode text, tlf text, total int)";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS categories";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE categories (id INTEGER primary key auto_increment, name text)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "DROP TABLE IF EXISTS types";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE types (id INTEGER primary key auto_increment, name text)";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS articles";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE articles (id INTEGER primary key auto_increment, name text, description text,
            colour text, size text, price int, stock int, transparency text, category text, type text, amm_sold int, img_link text, kpi int, barcode text)";
            cmd.ExecuteNonQuery();

            string[] categories = { "Kvinder", "Børn" };

                for (int i = 0; i < categories.Length; i++)
            {
                string category = categories[i];
                cmd.CommandText = string.Format("INSERT INTO categories(name) VALUES('{0}')", category);
                cmd.ExecuteNonQuery();
            }

            string[] types = { "Trøjer", "Bukser", "T-shirts", "Strømper", "Jakker" };
            for (int i = 0; i < types.Length; i++)
            {
                string type = types[i];
                cmd.CommandText = string.Format("INSERT INTO types(name) VALUES('{0}')", type);
                cmd.ExecuteNonQuery();
            }

            string[] colours = { "Lilla", "Blå", "Grå", "Rød", "Grøn", "Lyserød", "Hvid", "Sort"};
            string[] sizes = { "X-Small", "Small", "Medium", "Large", "X-Large" };
            string description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas tempus enim interdum ultricies iaculis. Phasellus tincidunt nec risus eu suscipit.";
            string transparency =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas tempus enim interdum ultricies iaculis. Phasellus tincidunt nec risus eu suscipit.";

            for (int i = 0; i < 100; i++)
            {
                Random rd = new Random();
                int randStock = rd.Next(0, 50);
                int randPrice = rd.Next(100, 1000);
                int randCat = rd.Next(0, 2);
                int randType = rd.Next(0, 5);
                int randSold = rd.Next(0, 20);
                int randColour = rd.Next(0, 8);
                int randSize = rd.Next(0, 5);
                int randKpi = rd.Next(0, 101);

                string kvinde = "kvinde";
                string barne = "barne";
                string seleceted;

                if (randCat == 0)
                {
                    seleceted = kvinde;
                }
                else
                {
                    seleceted = barne;
                }

                string name = colours[randColour] + " " + seleceted + types[randType];
                int id = i;

                string imglink = "Images/bedøvet vuf.png";
                
                cmd.CommandText = string.Format(@"INSERT INTO articles(name, description, colour, size, price, stock, transparency, category, type, amm_sold, img_link, kpi) 
                    VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')",
                    name, description, colours[randColour], sizes[randSize], randPrice, randStock, transparency, categories[randCat], types[randType], randSold, imglink, randKpi);
                cmd.ExecuteNonQuery();
            }
            
            string sql = "SELECT name, type, price FROM articles WHERE id = 1";
            using var cmd2 = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd2.ExecuteReader();

            int n = 0;
            string[] test = {""};
            while (rdr.Read())
            {
                string _name = rdr.GetString(0);
                string _type = rdr.GetString(1);
                int _price = rdr.GetInt32(2);
            }
        }
    }
}
        
    
