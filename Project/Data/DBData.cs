using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace Project.Data
{
    public class DbData
    {
        void Data()
        {
            //your MySQL connection string
            string connStr = "server=localhost;user=dat2c2-4;database=dat2c2_4;port=3306;password=t95oqnsuoqLpR27r";

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string t = "";
                //SQL Query to execute
                string sql = "select UserLoginId, UserType from Users;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<CustomType> data = new List<CustomType>();

                //read the data
                while (rdr.Read())
                {
                    data.Add(new CustomType(rdr[0].ToString(),rdr[1].ToString()));
                }
                rdr.Close();
                
                foreach (var item in data)
                {
                    Console.WriteLine(item.Id + " " + item.Type);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            conn.Close();
            Console.WriteLine("Connection Closed. Press any key to exit...");
            Console.Read();
        }
    }
}

