using MySql.Data.MySqlClient;
using Project.Pages;

namespace Project.Data
{
    public class DbCall
    {
        public string[] CartCall(int i)
        {
            string[] array = new string[2];
            string cs = @"server=localhost;userid=root;password=Password;database=ClothingStore";
            using var con = new MySqlConnection(cs);
            con.Open();
            string sql = $@"SELECT name, price FROM articles WHERE id = '{i}'";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
                
            while (rdr.Read())
            {
                string _name = rdr.GetString(0);
                array[0] = _name;
                string _price = rdr.GetString(1);
                array[1] = _price;
            }
            con.Close();
            return array;
        }

        public string[] SpecificArticleCall(int i)
        {
            string[] array = new string[15];
            string cs = @"server=localhost;userid=root;password=Password;database=ClothingStore";
            using var con = new MySqlConnection(cs);
            con.Open();
            string sql = $@"SELECT  name, description, colour, size, price, stock, transparency, category, type, img_link FROM articles WHERE id = '{i}'";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
                
            while (rdr.Read())
            {
                string _name = rdr.GetString(0);
                array[0] = _name;
                string _description = rdr.GetString(1);
                array[1] = _description;
                string _colour = rdr.GetString(2);
                array[2] = _colour;
                string _size = rdr.GetString(3);
                array[3] = _size;
                string _price = rdr.GetString(4);
                array[4] = _price;
                string _stock = rdr.GetString(5);
                array[5] = _stock;
                string _transparency = rdr.GetString(6);
                array[6] = _transparency;
                string _category = rdr.GetString(7);
                array[7] = _category;
                string _type = rdr.GetString(8);
                array[8] = _type;
                string _imagelink = rdr.GetString(9);
                array[9] = _imagelink;
            }
            con.Close();
            return array;
        }

        public string[] SearchCall(int i)
        {
            string[] array = new string[15];
            string cs = @"server=localhost;userid=root;password=Password;database=ClothingStore";
            using var con = new MySqlConnection(cs);
            con.Open();
            string sql = $@"SELECT name, price FROM articles WHERE id = '{i}'";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
                
            while (rdr.Read())
            {
                string _name = rdr.GetString(0);
                array[0] = _name;
                string _price = rdr.GetString(1);
                array[1] = _price;
            }
            con.Close();
            return array;
        }
    }
}