using System;
using MySql.Data.MySqlClient;
using Project.Pages;

namespace Project.CSharpFiles
{
    public class DbCall
    {
        private readonly string _cs = @"server=localhost;userid=root;password=Password;database=ClothingStore";

        //ændre i til barcode
        public string[] CartCall(int i)
        {
            string[] array = new string[2];
            using var con = new MySqlConnection(_cs);
            con.Open();
            string sql = $@"SELECT name, price, stock FROM articles WHERE id = '{i}'";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                array[0] = name;
                string price = rdr.GetString(1);
                array[1] = price;
                string stock = rdr.GetString(2);
                array[2] = stock;
            }
            con.Close();
            return array;
        }
        
        //ændre i til barcode
        public string[] SpecificArticleCall(string i)
        {
            string[] array = new string[15];
            using var con = new MySqlConnection(_cs);
            con.Open();
            string sql = $@"SELECT  name, description, colour, size, price, stock, transparency, category, type, img_link, barcode FROM articles WHERE barcode = '{i}'";
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
                string barcode = rdr.GetString(10);
                array[10] = barcode;
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

            
            using var con = new MySqlConnection(_cs);
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

        public string[] CategoryCall(string category)
        {
            string[] array = new string[2];
            using var con = new MySqlConnection(_cs);
            con.Open();
            string sql = $@"SELECT name, price, img_link FROM articles WHERE category = '{category}' ORDER BY kpi DESC LIMIT 10";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                array[0] = name;
                string price = rdr.GetString(1);
                array[1] = price;
                string imglink = rdr.GetString(2);
                array[2] = imglink;
            }
            con.Close();
            return array;
        }

        public string[] TypeCall(string category, string type)
        {
            string[] array = new string[2];
            using var con = new MySqlConnection(_cs);
            con.Open();
            string sql = $@"SELECT name, price, img_link  FROM articles WHERE category = '{category}' and type = '{type}'";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                array[0] = name;
                string price = rdr.GetString(1);
                array[1] = price;
                string imglink = rdr.GetString(2);
                array[2] = imglink;
            }
            con.Close();
            return array;
        }

        public string InsertIntoDb(int insertType, params object[] args)
        {
            string sql = "";
            //Catergory
            if (insertType == 1)
            { 
                sql = $@"insert into categories(name) values({args[0]})";
            }
            //Type
            else if (insertType == 2)
            {
                sql = $@"insert into type(name) values({args[0]})";
            }
            //Article
            else if (insertType == 3)
            {
                sql = $@"INSERT INTO articles(name, description, colour, size, price, stock, transparency, category, type, img_link)
                                          values({args[0]},{args[1]},{args[2]},{args[3]},{args[4]},{args[5]},{args[6]},{args[7]},{args[8]},{args[9]})";
            }
            // string name, string description, string colour, string size, int price, int stock, string transparency, string category, string type, string imgLink
            using var con = new MySqlConnection(_cs);
            con.Open();
            using var cmd = new MySqlCommand(sql, con);
            return "Inserted";
        }

        public string UpdateDb(int updateType, params object[] args)
        {
            string sql = "";
            //Category
            if (updateType == 1)
            { 
                sql = $@"update category set name = '{args[1]}' where name = '{args[0]}'";
            }
            //Type
            else if (updateType == 2)
            {
                sql = $@"update type set name = '{args[1]}' where name = '{args[0]}'";
            }
            //Article
            else if (updateType == 3)
            {
                sql = $@"update articles set name = '{args[1]}', description = '{args[2]}', colour = '{args[3]}', size = '{args[4]}', price = {args[5]},
                         stock = {args[6]}, transparency = '{args[7]}', category = '{args[8]}', type = '{args[9]}'  where barcode = '{args[0]}'";
            }
            
            using var con = new MySqlConnection(_cs);
            con.Open();
            using var cmd = new MySqlCommand(sql, con);
            return "Updated";
        }

        public string DeleteInDb(int deleteType, string saveArticles, params object[] args)
        {
            string sql = "";
            string sql2 = "";
            if (deleteType == 1)
            {
                if (saveArticles == "Yes")
                {
                    sql = $@"delete from categories where name = '{args[0]}'";
                    sql2 = $@"update articles set category = 'Uncategorized' where category = '{args[0]}'";
                }
                else if (saveArticles == "No")
                {
                    sql = $@"delete from categories where name = '{args[0]}'";
                    sql2 = $@"delete from articles where name = '{args[0]}'";
                }
            }
            else if (deleteType == 2)
            {
                sql = $@"delete from types where name = '{args[0]}'";
            }
            else if (deleteType == 3)
            {
                if (saveArticles == "Yes")
                {
                    sql = $@"update articles set category = 'Uncategorized' where barcode = '{args[0]}'";
                }
                else if (saveArticles == "No")
                {
                    sql2 = $@"delete from articles where barcode = '{args[0]}'";
                }
            }
            using var con = new MySqlConnection(_cs);
            con.Open();
            using var cmd = new MySqlCommand(sql, con);
            if (saveArticles == "Yes" || saveArticles == "No" )
            {
                using var cmd2 = new MySqlCommand(sql2, con);
            }
            return "Deleted";
        }

        public string AddOrderDb(string name, string adress, string country, string zipcode, string tlf, string[] items, int total)
        {
            string itemStr = "";
            foreach (var item in items)
            {
                itemStr += item+",";
            }
            
            using var con = new MySqlConnection(_cs);
            con.Open();
            string sql = $@"insert into orders (name, adress, country, zipcode, tlf, items, total) values('{name}','{adress}','{country}','{zipcode}','{tlf}','{itemStr}',{total} )";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            con.Close();
            return "Order Saved to DB";
        }

        public string CancelOrderDb()
        {
            return "Order Cancelled";
        }
    }
}
