using MySql.Data.MySqlClient;
using System;

namespace ConsoleApplication1
{
    static class Program
    {
        private static void Main()
        {
            const string cs = @"server=localhost;userid=root;password=Password;database=ClothingStore";

            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;

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
            
            cmd.CommandText = @"CREATE TABLE articles (id INTEGER primary key auto_increment, name text, category text, type text, colour text, size text, price int, description text, materiale text, produceret text, transparency text, img_link text, barcode text, stock int,  amm_sold int, kpi int )";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS Orders";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE Orders (ordernumber INTEGER primary key auto_increment, name text, items text, adress text, country text, zipcode text, tlf text, total int)";
            cmd.ExecuteNonQuery();

            string[] categories = { "Kvinder", "Drenge", "Piger" };

                for (int i = 0; i < categories.Length; i++)
            {
                string category = categories[i];
                cmd.CommandText = string.Format("INSERT INTO categories(name) VALUES('{0}')", category);
                cmd.ExecuteNonQuery();
            }

            string[] types = { "Trøjer", "Bukser", "T-shirts", "Strømper", "Jakker", "Jeans", "Sportstøj", "Shorts", "Undertøj", "Nattøj", "Badetøj" };
            for (int i = 0; i < types.Length; i++)
            {
                string type = types[i];
                cmd.CommandText = string.Format("INSERT INTO types(name) VALUES('{0}')", type);
                cmd.ExecuteNonQuery();
            }

            string[] colours = { "Lilla", "Blå", "Grå", "Rød", "Grøn", "Lyserød", "Hvid", "Sort", "Beige", "Turkis", "Gul", "Orange", "Flerfarvet" };
            string[] sizes = { "X-Small", "Small", "Medium", "Large", "X-Large" };
            string description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            string transparency =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            string[] materiale = {"Bomuld", "Uld", "Denim", "Silke", "Velour", "Hamp", "Nylon", "Polyester", "Acetat", "Elastan", "Læder"};
            string[] produceret = {"Danmark", "Beirut", "Kina", "Tyrkiet", "Taiwain", "Indien", "Ungarn", "Afrika", "Nordkorea", "kazakhstan", "Honduras" };

            for (int i = 0; i < 1000; i++)
            {
                Random rd = new Random();
                int randStock = rd.Next(0, 50);
                int randPrice = rd.Next(100, 1000);
                int randCat = rd.Next(0, 3);
                int randType = rd.Next(0, 11);
                int randSold = rd.Next(0, 20);
                int randColour = rd.Next(0, 13);
                int randSize = rd.Next(0, 5);
                int randKpi = rd.Next(0, 101);
                int randmat = rd.Next(0, 11);
                int randprod = rd.Next(0, 11);

                string kvinde = "kvinde";
                string drenge = "drenge";
                string pige = "pige";
                string seleceted;

                if (randCat == 0)
                {
                    seleceted = kvinde;
                }
                else if (randCat == 1)
                {
                    seleceted = drenge;
                }
                else
                {
                    seleceted = pige;
                }

                string name = colours[randColour] + " " + seleceted + types[randType];

                string imglink = "Images/bedøvet vuf.png";
                
                string randCatStr = randCat.ToString();
                if (randCat < 10)
                {
                    randCatStr = randCatStr.Insert(0, "0");
                }

                string randTypeStr = randType.ToString();
                if (randType < 10)
                {
                    randTypeStr = randTypeStr.Insert(0, "0");
                }

                string randColourStr = randColour.ToString();
                if (randColour < 10)
                {
                    randColourStr = randColourStr.Insert(0, "0");
                }

                string randSizeStr = randSize.ToString();
                
                string randMatStr = randmat.ToString();
                if (randmat < 10)
                {
                    randMatStr = randMatStr.Insert(0, "0");
                }
                
                string randProdStr = randprod.ToString();
                if (randprod < 10)
                {
                    randProdStr = randProdStr.Insert(0, "0");
                }
                
                int variableBarcodePart = 0;
                
                string barcodePlaceholder;
                if (variableBarcodePart < 10)
                {
                    barcodePlaceholder = "0000";
                }
                else if (variableBarcodePart < 100)
                {
                    barcodePlaceholder = "000";
                }
                else if (variableBarcodePart < 1000)
                {
                    barcodePlaceholder = "00";
                }
                else if (variableBarcodePart < 10000)
                {
                    barcodePlaceholder = "0";
                }
                else
                {
                    barcodePlaceholder = "";
                }

                string barcode = "";
                
                bool foundbarcode = true;

                while (foundbarcode == true)
                {
                    barcode = randCatStr + randTypeStr + randColourStr + randSizeStr + randMatStr + randProdStr + barcodePlaceholder + variableBarcodePart;
                    // kategori - type   - farve - størelse - materiale - produceret - variabel 
                    //    00    -  00  -    00   -    0     -   00      -    00   -     00000

                    string sql = $@"SELECT barcode FROM articles WHERE barcode = '{barcode}'";
                    using var cmd2 = new MySqlCommand(sql, con);
                    using MySqlDataReader rdr = cmd2.ExecuteReader();

                    string exists = "";
                    
                    while (rdr.Read())
                    {
                        exists = rdr.GetString(0);
                        Console.WriteLine(exists);
                    }
                    variableBarcodePart++;

                    if (exists == "")
                    {
                        foundbarcode = false;
                    }
                }
                cmd.CommandText = string.Format(@"INSERT INTO articles(name, category , type , colour , size , price , description , materiale , produceret , transparency , img_link , barcode , stock ,  amm_sold , kpi ) 
                    VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')",
                    name, categories[randCat], types[randType], colours[randColour], sizes[randSize], randPrice, description, materiale[randmat], produceret[randprod], transparency, imglink, barcode, randStock, randSold, randKpi);
                cmd.ExecuteNonQuery();

            }
            con.Close();
        }
    }
} 

    
