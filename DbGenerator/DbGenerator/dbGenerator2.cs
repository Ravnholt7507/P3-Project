/*using MySql.Data.MySqlClient;
using System;

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
            
            cmd.CommandText = "DROP TABLE IF EXISTS categories";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE categories (id INTEGER primary key auto_increment, category text)";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS types";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE types (id INTEGER primary key auto_increment, type text, category TEXT, FOREIGN KEY (category) REFERENCES categories(id))";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS products";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "CREATE TABLE products (prod_id INTEGER primary key auto_increment, prod_name text, type INT, price int, description text, material text, produced text, transparency text, FOREIGN KEY (type) REFERENCES types(id))";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS colours";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE colours (id INT NOT NULL, colour TEXT, img TEXT, kpi INT, sold INT, FOREIGN KEY (id) REFERENCES products(prod_id))";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS sizes";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE sizes (id INT NOT NULL, size text, stock int, FOREIGN KEY (id) REFERENCES colours(id))";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "DROP TABLE IF EXISTS orders";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "CREATE TABLE orders (id INTEGER PRIMARY KEY AUTO_INCREMENT, customer_name TEXT)";
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}*/