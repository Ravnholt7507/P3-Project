using System;
using MySql.Data.MySqlClient;
using Project.Pages;

namespace Project.Data
{
    public class DbCall
    {
        private readonly string cs = @"server=localhost;userid=root;password=Password;database=ClothingStore";

        public string[] CartCall(int i)
        {
            string[] array = new string[2];
            using var con = new MySqlConnection(cs);
            con.Open();
            string sql = $@"SELECT name, price FROM articles WHERE id = '{i}'";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
                
            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                array[0] = name;
                string price = rdr.GetString(1);
                array[1] = price;
            }
            con.Close();
            return array;
        }

        public string[] SpecificArticleCall(int i)
        {
            string[] array = new string[15];
            using var con = new MySqlConnection(cs);
            con.Open();
            string sql = $@"SELECT  name, description, colour, size, price, stock, transparency, category, type, img_link FROM articles WHERE id = '{i}'";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
                
            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                array[0] = name;
                string description = rdr.GetString(1);
                array[1] = description;
                string colour = rdr.GetString(2);
                array[2] = colour;
                string size = rdr.GetString(3);
                array[3] = size;
                string price = rdr.GetString(4);
                array[4] = price;
                string stock = rdr.GetString(5);
                array[5] = stock;
                string transparency = rdr.GetString(6);
                array[6] = transparency;
                string category = rdr.GetString(7);
                array[7] = category;
                string type = rdr.GetString(8);
                array[8] = type;
                string imagelink = rdr.GetString(9);
                array[9] = imagelink;
            }
            con.Close();
            return array;
        }

        public string[] SearchCall(params object[] args)
        {
            string[] searchArray = new string[10];
            for (int i = 0; i < args.Length; i++)
            {
                searchArray[i] = args[i].ToString();
            }

            ItemAttributes attributes = new ItemAttributes();
            
            string[] array = new string[4];
            for (int j = 0; j < searchArray.Length; j++)
            {
                if (array[0] == null && searchArray[j] != null)
                {
                    for (int k = 0; k < attributes.Colours.Length; k++)
                    {
                        bool attribute = attributes.Colours[k]
                            .Contains(searchArray[j], StringComparison.OrdinalIgnoreCase);
                        if (attribute)
                        {
                            array[0] = attributes.Colours[k];
                            k = attributes.Colours.Length;
                        }
                    }
                }

                if (array[1] == null && searchArray[j] != null)
                {
                    for (int k = 0; k < attributes.Sizes.Length; k++)
                    {
                        bool attribute = attributes.Sizes[k]
                            .Contains(searchArray[j], StringComparison.OrdinalIgnoreCase);
                        if (attribute)
                        {
                            array[1] = attributes.Sizes[k];
                            k = attributes.Sizes.Length;
                        }
                    }
                }

                if (array[2] == null && searchArray[j] != null)
                {
                    for (int k = 0; k < attributes.Category.Length; k++)
                    {
                        bool attribute = attributes.Category[k]
                            .Contains(searchArray[j], StringComparison.OrdinalIgnoreCase);
                        if (attribute)
                        {
                            array[2] = attributes.Category[k];
                            k = attributes.Category.Length;
                        }
                    }
                }

                if (array[3] == null && searchArray[j] != null)
                {
                    for (int k = 0; k < attributes.Type.Length; k++)
                    {
                        bool attribute = attributes.Type[k]
                            .Contains(searchArray[j], StringComparison.OrdinalIgnoreCase);
                        if (attribute)
                        {
                            array[3] = attributes.Type[j];
                            k = attributes.Type.Length;
                        }
                    }
                }
            }

            
            using var con = new MySqlConnection(cs);
            con.Open();
            string sql = $@"select name from articles where colour like '%{array[0]}%' and size like '%{array[1]}%' and category like '%{array[2]}%' and type like '%{array[3]}%'";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();

            string[] itemArray = new string[1];
            
            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                itemArray[0] = name;
            }
            con.Close();
            return array;
        }
    }
}