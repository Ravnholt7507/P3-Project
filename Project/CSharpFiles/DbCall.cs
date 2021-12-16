using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using Project.Pages;
using System.Text;
using System.Security.Cryptography;
using Project.Pages.AdminPage;

namespace Project.CSharpFiles
{
    public class DbCall
    {
        private readonly string _cs = @"server=localhost;userid=root;password=Password;database=ClothingStore";

        public string[][] ProductCalls(string callType, params object[] args)
        {
            string[][] productArray = new string[10][];

            if (callType == "Multiple products")
            {
                using var con = new MySqlConnection(_cs);
                con.Open();
                string sql = "SELECT prod_id, prod_name, price FROM products LIMIT 10;";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                int i = 0;
                while (rdr.Read())
                {
                    string[] array = new string[6];
                    array[0] = rdr.GetString(0);
                    array[1] = rdr.GetString(1);
                    array[2] = rdr.GetString(2);
                    productArray[i] = array;
                    i++;
                }
                rdr.Close();
                for (int j = 0; j < i; j++)
                {
                    string sql2 = $"SELECT colour_id, img FROM colours WHERE prod_id = {productArray[j][0]} ;";
                    using var cmd2 = new MySqlCommand(sql2, con);
                    using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        productArray[j][3] = rdr2.GetString(0);
                        productArray[j][4] = rdr2.GetString(1);
                    }
                    rdr2.Close();
                }

                for (int j = 0; j < i; j++)
                {
                    string sql3 = $"SELECT size FROM sizes WHERE prod_id = {productArray[j][0]} and colour_id = {productArray[j][3]} LIMIT 1";
                    using var cmd3 = new MySqlCommand(sql3, con);
                    using MySqlDataReader rdr3 = cmd3.ExecuteReader();

                    while (rdr3.Read())
                    {
                        productArray[j][5] = rdr3.GetString(0);
                    }
                    rdr3.Close();
                }
            }
            else if (callType == "Specific Product")
            {
                if (args[0].ToString() == "Kald 1")
                {
                    var prodId = args[1];
                    var colourId = args[2];
                    using var con = new MySqlConnection(_cs);
                    con.Open();
                    string sql =
                        $"SELECT prod_name, price, description, material, produced, transparency FROM products WHERE prod_id = {prodId};";
                    using var cmd = new MySqlCommand(sql, con);
                    using MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string[] array = new string[10];
                        array[0] = rdr.GetString(0);
                        array[1] = rdr.GetString(1);
                        array[2] = rdr.GetString(2);
                        array[5] = rdr.GetString(5);
                        productArray[0] = array;
                    }

                    rdr.Close();
                    string sql2 = $"SELECT img FROM colours WHERE prod_id = {prodId} AND colour_id = {colourId};";
                    using var cmd2 = new MySqlCommand(sql2, con);
                    using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        productArray[0][3] = rdr2.GetString(0);
                    }

                    rdr2.Close();
                }
                else if (args[0].ToString() == "Kald 2")
                {
                    var prodId = args[1];
                    int[] colourIds = new int[25];
                    using var con = new MySqlConnection(_cs);
                    con.Open();
                    string sql = $"SELECT colour_id, colour, img FROM colours WHERE prod_id ={prodId};";
                    using var cmd = new MySqlCommand(sql, con);
                    using MySqlDataReader rdr = cmd.ExecuteReader();
                    int i = 0, j = 0;
                    while (rdr.Read())
                    {
                        colourIds[j] = rdr.GetInt32(0);
                        string[] array = new string[10];
                        array[i] = rdr.GetString(0);
                        array[i+1] = rdr.GetString(1);
                        array[i+2] = rdr.GetString(2);
                        productArray[j] = array;
                        i = 0;
                        j++;
                    }
                    rdr.Close();
                    int h = 0;
                    for (int l = 0; l < colourIds.Length; l++)
                    {
                        int k = 3;
                        string sql2 = $"SELECT size, stock FROM sizes WHERE prod_id = {prodId} AND colour_id = {colourIds[l]};";
                        using var cmd2 = new MySqlCommand(sql2, con);
                        using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            productArray[h][k] = rdr2.GetString(0) +"&"+ rdr2.GetString(1);
                            k++;
                        }
                        h++;
                        rdr2.Close();
                    }
                }
            }
            else if (callType == "Cart Call")
            {
                string[] strArray = args[0].ToString().Split();
                var prodId = strArray[1];
                var colourId = strArray[2];
                var size = strArray[3];
                using var con = new MySqlConnection(_cs);
                con.Open();
                string sql = $"SELECT prod_name, price FROM products WHERE prod_id = {prodId};";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string[] array = new string[6];
                    array[0] = rdr.GetString(0);
                    array[1] = rdr.GetString(1);
                    productArray[0] = array;
                }
                rdr.Close();
                string sql2 = $"SELECT colour, img FROM colours WHERE prod_id = {prodId} AND colour_id = {colourId};";
                using var cmd2 = new MySqlCommand(sql2, con);
                using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())  
                {
                    productArray[0][2] = rdr2.GetString(0);
                    productArray[0][3] = rdr2.GetString(1);
                }
                rdr2.Close();
                string sql3 = $"SELECT size, stock FROM sizes WHERE prod_id = {prodId} AND colour_id = {colourId} and size = '{size}'";
                using var cmd3 = new MySqlCommand(sql3, con);
                using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                while (rdr3.Read())
                {
                    productArray[0][4] = rdr3.GetString(0);
                    productArray[0][5] = rdr3.GetString(1);
                }
                rdr3.Close();
            }
            return productArray;
        }

        public void VisitUpdate(int prodId)
        {
            using var con = new MySqlConnection(_cs);
            con.Open();
            string sql = $"UPDATE products SET views = views + 1 WHERE prod_id = {prodId}";
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void PurchaseUpdate(int Prod_Id, int Colour_Id, int Amount)
        {
            using var con = new MySqlConnection(_cs);
            con.Open();
            string sql = $"UPDATE colours SET sold = sold + {Amount} WHERE prod_id = {Prod_Id} AND colour_id = {Colour_Id}";
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = $"UPDATE sizes SET stock = stock - {Amount} WHERE prod_id = {Prod_Id} AND colour_id = {Colour_Id}";
            cmd.ExecuteNonQuery();
            
            con.Close();
        }

        public string[][] AdminPages(string callType, string callSubType, params object[] args)
        {
            string[][] returnArray = new string[25][];

            if (callType == "Get")
            {
                if (callSubType == "Categories")
                {
                    string[] categories = new string[10];
                    using var con = new MySqlConnection(_cs);
                    con.Open();
                    string sql = "SELECT category FROM categories;";
                    using var cmd = new MySqlCommand(sql, con);
                    using MySqlDataReader rdr = cmd.ExecuteReader();
                    int i = 0;
                    while (rdr.Read())
                    {
                        categories[i] = rdr.GetString(0);
                        i++;
                    }
                    rdr.Close();
                    con.Close();
                    returnArray[0] = categories;
                }
                else if (callSubType == "Types")
                {
                    string[] types = new string[25];
                    using var con = new MySqlConnection(_cs);
                    con.Open();
                    string sql = string.Format("SELECT type FROM types WHERE {0} = 1", args[0].ToString());
                    using var cmd = new MySqlCommand(sql, con);
                    using MySqlDataReader rdr = cmd.ExecuteReader();
                    int i = 0;
                    while (rdr.Read())
                    {
                        types[i] = rdr.GetString(0);
                        i++;
                    }
                    rdr.Close();
                    con.Close();
                    returnArray[0] = types;
                }
            }
            else if (callType == "New")
            {
                if (callSubType == "Category")
                {
                    string category = args[0].ToString();
                    using var con = new MySqlConnection(_cs);
                    con.Open();
            
                    using var cmd = new MySqlCommand();
                    cmd.Connection = con;
                    
                    cmd.CommandText = string.Format("INSERT IGNORE INTO categories (category) VALUES ('{0}')", category);
                    cmd.ExecuteNonQuery();
                    
                    // Kan ikke håndtagere duplicate collumns
                    cmd.CommandText = $"ALTER TABLE types ADD {category} INT DEFAULT 0";
                    cmd.ExecuteNonQuery();
                    
                    con.Close();
                }
                else if (callSubType == "Type")
                {
                    string category = args[0].ToString();
                    string type = args[1].ToString();
                    using var con = new MySqlConnection(_cs);
                    con.Open();
            
                    using var cmd = new MySqlCommand();
                    cmd.Connection = con;
                    
                    cmd.CommandText = string.Format("INSERT IGNORE INTO types (type) VALUES ('{0}')", type);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = $"UPDATE types SET {category}=1 WHERE type = '{type}' ";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else if (callSubType == "Product")
                {
                    string prodName = args[0].ToString();
                    string category = args[1].ToString();
                    string type = args[2].ToString();
                    double price = double.Parse(args[3].ToString());
                    string description = args[4].ToString();
                    string material = args[5].ToString();
                    string produced = args[6].ToString();
                    string transparency = args[7].ToString();
                    using var con = new MySqlConnection(_cs);
                    con.Open();
                    using var cmd = new MySqlCommand();
                    cmd.Connection = con;
                    if (args[12].ToString() != "same")
                    {
                        cmd.CommandText =
                            $"INSERT INTO products (prod_name, category, type, price, description, material, produced, transparency) VALUES ('{prodName}', '{category}', '{type}', '{price}', '{description}', '{material}', '{produced}', '{transparency}');";
                        cmd.ExecuteNonQuery();
                    }

                    var colour = args[8];
                    string img = args[9].ToString();
             
                    cmd.CommandText = $"INSERT INTO colours (prod_id, colour, img, kpi, sold) VALUES ((SELECT MAX(prod_id) FROM products), '{colour}', '{img}', 0, 0)";
                    cmd.ExecuteNonQuery();

                    object objSizeArray = args[10];
                    string[] sizeArray = (string[])(objSizeArray);
                    
                    object objStockArray = args[11];
                    int[] stockArray = (int[])(objStockArray);
                    
                    for (int j = 0; j < sizeArray.Length; j++)
                    {
                        cmd.CommandText = string.Format("INSERT INTO sizes (colour_id, prod_id, size, stock) VALUES ((SELECT MAX(colour_id) FROM colours), (SELECT MAX(prod_id) FROM products), '{0}', '{1}')", sizeArray[j], stockArray[j]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            
            else if (callType == "Remove")
            {
                if (callSubType == "Category")
                {
                    string category = args[0].ToString();
                    using var con = new MySqlConnection(_cs);
                    con.Open();
                    string sql = $"DELETE FROM categories WHERE category = '{category}';";
                    using var cmd = new MySqlCommand(sql, con);
                    string sql2 = $"ALTER TABLE types DROP COLUMN {category}";
                    using var cmd2 = new MySqlCommand(sql2, con);
                    con.Close();
                }
                else if (callSubType == "Type")
                {
                    string type = args[0].ToString();
                    using var con = new MySqlConnection(_cs);
                    con.Open();
                    string sql = $"DELETE FROM types WHERE type = '{type}';";
                    using var cmd = new MySqlCommand(sql, con);
                    con.Close();
                }
                else if (callSubType == "Product")
                {
                    string product = args[0].ToString();
                }
            }
            
            return returnArray;
        }

        public void RemoveTypeFromCategory(string category, string type)
        {
            using var con = new MySqlConnection(_cs);
            con.Open();
            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"UPDATE types SET {category} = 0 WHERE type = '{type}'";
            cmd.ExecuteNonQuery();
        }

        public List<Product> SearchCall(params object[] args)
        {
            string[] searchParams = new string[args.Length];
            var inputsplit = args[0].ToString();
            searchParams = inputsplit.ToLower().Split(" ");
            //for (int i = 0; i < args.Length; i++)
            //{
            //    searchParams[i] = inputsplit[i];

            //}


            string[] columns = { "category", "type", "colour", "size" };
            string[] tables = { "categories", "types", "colours", "sizes" };
            int[] columnLengths = new int[4];
            using var con = new MySqlConnection(_cs);
            con.Open();

            for (int i = 0; i < 4; i++)
            {
                string sql = $"SELECT COUNT(DISTINCT {columns[i]}) AS amount FROM {tables[i]}";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    columnLengths[i] = rdr.GetInt32(0);
                }

                rdr.Close();
            }

            string[] categoryArray = new string[columnLengths[0]];
            string[] typeArray = new string[columnLengths[1]];
            string[] colourArray = new string[columnLengths[2]];
            string[] sizeArray = new string[columnLengths[3]];

            for (int i = 0; i < 4; i++)
            {
                int k = 0;
                string sql = $"SELECT DISTINCT {columns[i]} FROM {tables[i]}";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (i == 0)
                    {
                        categoryArray[k] = rdr.GetString(0).ToLower();
                    }
                    else if (i == 1)
                    {
                        typeArray[k] = rdr.GetString(0).ToLower();
                    }
                    else if (i == 2)
                    {
                        colourArray[k] = rdr.GetString(0).ToLower();
                    }
                    else if (i == 3)
                    {
                        sizeArray[k] = rdr.GetString(0).ToLower();
                    }

                    k++;
                }

                rdr.Close();
            }

            bool category = false, type = false, colour = false, size = false;
            string[] searchCategoryArray = new string[columnLengths[0]];
            string[] searchTypeArray = new string[columnLengths[1]];
            string[] searchColourArray = new string[columnLengths[2]];
            string[] searchSizeArray = new string[columnLengths[3]];

            int cat = 0, typ = 0, col = 0, siz = 0;

            for (int i = 0; i < searchParams.Length; i++)
            {
                for (int j = 0; j < categoryArray.Length; j++)
                {
                    if (categoryArray[j].Contains(searchParams[i]))
                    {
                        category = true;
                        searchCategoryArray[cat] = categoryArray[j];
                        cat++;
                    }
                }

                for (int j = 0; j < typeArray.Length; j++)
                {
                    if (typeArray[j].Contains(searchParams[i]))
                    {
                        type = true;
                        searchTypeArray[typ] = typeArray[j];
                        typ++;
                    }
                }

                for (int j = 0; j < colourArray.Length; j++)
                {
                    if (colourArray[j].Contains(searchParams[i]))
                    {
                        colour = true;
                        searchColourArray[col] = colourArray[j];
                        col++;
                    }
                }

                for (int j = 0; j < sizeArray.Length; j++)
                {
                    if (sizeArray[j].Contains(searchParams[i]))
                    {
                        size = true;
                        searchSizeArray[siz] = sizeArray[j];
                        siz++;
                    }
                }
            }

            searchCategoryArray = searchCategoryArray.Where(c => c != null).ToArray();
            searchTypeArray = searchTypeArray.Where(c => c != null).ToArray();
            searchColourArray = searchColourArray.Where(c => c != null).ToArray();
            searchSizeArray = searchSizeArray.Where(c => c != null).ToArray();


            List<Product> foundProducts = new List<Product>();
            int FoundprodId = 0;
            int FoundcolourId = 0;
            string Foundsize = "";

            if (category == true)
            {
                FoundprodId = 0;
                FoundcolourId = 0;
                Foundsize = "";

                for (int i = 0; i < searchCategoryArray.Length; i++)
                {
                    if (type == true)
                    {
                        for (int j = 0; j < searchTypeArray.Length; j++)
                        {
                            string sql =
                                string.Format("SELECT prod_id FROM products WHERE category = '{0}' AND type = '{1}'",
                                    searchCategoryArray[i], searchTypeArray[j]);
                            using var cmd = new MySqlCommand(sql, con);
                            using MySqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                FoundprodId = rdr.GetInt32(0);
                                if (FoundprodId != 0)
                                {
                                    Product newFound = new Product();
                                    newFound.Id = FoundprodId;
                                    foundProducts.Add(newFound);
                                    FoundprodId = 0;
                                }
                            }

                            rdr.Close();
                            if (colour == true)
                            {
                                for (int k = 0; k < searchColourArray.Length; k++)
                                {
                                    foreach (var prod1 in foundProducts)
                                    {
                                        string sql2 =
                                            string.Format("SELECT colour_id FROM colours WHERE prod_id = '{0}' AND colour = '{1}'",
                                                prod1.Id, searchColourArray[k]);
                                        using var cmd2 = new MySqlCommand(sql2, con);
                                        using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                                        while (rdr2.Read())
                                        {
                                            FoundcolourId = rdr2.GetInt32(0);
                                            if (FoundcolourId != 0)
                                            {
                                                prod1.Colour_id = FoundcolourId;
                                                FoundcolourId = 0;
                                            }

                                        }

                                        rdr2.Close();
                                        if (size == true)
                                        {
                                            for (int l = 0; l < searchSizeArray.Length; l++)
                                            {
                                                foreach (var prod2 in foundProducts)
                                                {
                                                    string sql3 = string.Format(
                                                        "SELECT size FROM sizes WHERE prod_id = '{0}' AND colour_id = '{1}'",
                                                        prod2.Id, prod2.Colour_id);
                                                    using var cmd3 = new MySqlCommand(sql3, con);
                                                    using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                                                    while (rdr3.Read())
                                                    {
                                                        Foundsize = rdr3.GetString(0);
                                                        if (Foundsize != "")
                                                        {
                                                            prod2.Size = Foundsize;
                                                            Foundsize = "";
                                                        }
                                                    }
                                                    rdr3.Close();
                                                }
                                            }
                                        }
                                        else if (size == false)
                                        {

                                        }
                                    }
                                }
                            }
                            else if (colour == false)
                            {
                                if (size == true)
                                {
                                    for (int l = 0; l < searchSizeArray.Length; l++)
                                    {
                                        foreach (var prod2 in foundProducts)
                                        {
                                            string sql3 = string.Format("SELECT size FROM sizes WHERE prod_id = '{0}'",
                                                prod2.Id);
                                            using var cmd3 = new MySqlCommand(sql3, con);
                                            using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                                            while (rdr3.Read())
                                            {
                                                Foundsize = rdr3.GetString(0);
                                                if (Foundsize != "")
                                                {
                                                    prod2.Size = Foundsize;
                                                    Foundsize = "";
                                                }
                                            }
                                            rdr3.Close();
                                        }
                                    }
                                }
                                else if (size == false)
                                {
                                }
                            }
                        }
                    }
                    else if (type == false)
                    {
                        if (colour == true)
                        {
                            for (int j = 0; j < searchCategoryArray.Length; j++)
                            {
                                string sql =
                                    string.Format("SELECT prod_id FROM products WHERE category ='{0}'",
                                        searchCategoryArray[i]);
                                using var cmd = new MySqlCommand(sql, con);
                                using MySqlDataReader rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    FoundprodId = rdr.GetInt32(0);
                                    if (FoundprodId != 0)
                                    {
                                        Product newFound = new Product();
                                        newFound.Id = FoundprodId;
                                        foundProducts.Add(newFound);
                                        FoundprodId = 0;
                                    }
                                }
                            }

                            for (int k = 0; k < searchColourArray.Length; k++)
                            {
                                foreach (var prod1 in foundProducts)
                                {
                                    string sql2 =
                                        string.Format("SELECT colour_id FROM colours WHERE prod_id = '{0}' AND colour = '{1}'",
                                            prod1.Id, searchColourArray[k]);
                                    using var cmd2 = new MySqlCommand(sql2, con);
                                    using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                                    while (rdr2.Read())
                                    {
                                        FoundcolourId = rdr2.GetInt32(0);
                                        if (FoundcolourId != 0)
                                        {
                                            prod1.Colour_id = FoundcolourId;
                                            FoundcolourId = 0;
                                        }

                                    }
                                    rdr2.Close();
                                    if (size == true)
                                    {
                                        for (int l = 0; l < searchSizeArray.Length; l++)
                                        {
                                            foreach (var prod2 in foundProducts)
                                            {
                                                string sql3 = string.Format(
                                                    "SELECT size FROM sizes WHERE prod_id = '{0}' AND colour_id = '{1}'",
                                                    prod2.Id, prod2.Colour_id);
                                                using var cmd3 = new MySqlCommand(sql3, con);
                                                using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                                                while (rdr3.Read())
                                                {
                                                    Foundsize = rdr3.GetString(0);
                                                    if (Foundsize != "")
                                                    {
                                                        prod2.Size = Foundsize;
                                                        Foundsize = "";
                                                    }
                                                }
                                                rdr3.Close();
                                            }
                                        }
                                    }
                                    else if (size == false)
                                    {
                                    }
                                }
                            }
                        }
                        else if (colour == false)
                        {
                            if (size == true)
                            {
                                for (int j = 0; j < searchCategoryArray.Length; j++)
                                {
                                    string sql =
                                        string.Format("SELECT prod_id FROM products WHERE category ='{0}'",
                                            searchCategoryArray[i]);
                                    using var cmd = new MySqlCommand(sql, con);
                                    using MySqlDataReader rdr = cmd.ExecuteReader();
                                    while (rdr.Read())
                                    {
                                        FoundprodId = rdr.GetInt32(0);
                                        if (FoundprodId != 0)
                                        {
                                            Product newFound = new Product();
                                            newFound.Id = FoundprodId;
                                            foundProducts.Add(newFound);
                                            FoundprodId = 0;
                                        }
                                    }
                                }

                                for (int l = 0; l < searchSizeArray.Length; l++)
                                {
                                    foreach (var prod2 in foundProducts)
                                    {
                                        string sql3 = string.Format("SELECT size FROM sizes WHERE prod_id = '{0}'",
                                            prod2.Id);
                                        using var cmd3 = new MySqlCommand(sql3, con);
                                        using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                                        while (rdr3.Read())
                                        {
                                            Foundsize = rdr3.GetString(0);
                                            if (Foundsize != "")
                                            {
                                                prod2.Size = Foundsize;
                                                Foundsize = "";
                                            }
                                        }
                                        rdr3.Close();
                                    }
                                }
                            }
                            else if (size == false)
                            {
                                for (int j = 0; j < searchCategoryArray.Length; j++)
                                {
                                    string sql =
                                        string.Format("SELECT prod_id FROM products WHERE category ='{0}'",
                                            searchCategoryArray[i]);
                                    using var cmd = new MySqlCommand(sql, con);
                                    using MySqlDataReader rdr = cmd.ExecuteReader();
                                    while (rdr.Read())
                                    {
                                        FoundprodId = rdr.GetInt32(0);
                                        if (FoundprodId != 0)
                                        {
                                            Product newFound = new Product();
                                            newFound.Id = FoundprodId;
                                            foundProducts.Add(newFound);
                                            FoundprodId = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            else if (category == false)
            {
                FoundprodId = 0;
                FoundcolourId = 0;
                Foundsize = "";

                if (type == true)
                {
                    for (int j = 0; j < searchTypeArray.Length; j++)
                    {
                        string sql =
                            string.Format("SELECT prod_id FROM products WHERE type = '{0}'",
                                searchTypeArray[j]);
                        using var cmd = new MySqlCommand(sql, con);
                        using MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            FoundprodId = rdr.GetInt32(0);
                            if (FoundprodId != 0)
                            {
                                Product newFound = new Product();
                                newFound.Id = FoundprodId;
                                foundProducts.Add(newFound);
                                FoundprodId = 0;
                            }
                        }
                        rdr.Close();
                        if (colour == true)
                        {
                            for (int k = 0; k < searchColourArray.Length; k++)
                            {
                                foreach (var prod1 in foundProducts)
                                {
                                    string sql2 =
                                        string.Format("SELECT colour_id FROM colours WHERE prod_id = '{0}' AND colour = '{1}'",
                                            prod1.Id, searchColourArray[k]);
                                    using var cmd2 = new MySqlCommand(sql2, con);
                                    using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                                    while (rdr2.Read())
                                    {
                                        FoundcolourId = rdr2.GetInt32(0);
                                        if (FoundcolourId != 0)
                                        {
                                            prod1.Colour_id = FoundcolourId;
                                            FoundcolourId = 0;
                                        }
                                    }
                                    rdr2.Close();
                                    if (size == true)
                                    {
                                        for (int l = 0; l < searchSizeArray.Length; l++)
                                        {
                                            foreach (var prod2 in foundProducts)
                                            {
                                                string sql3 = string.Format(
                                                    "SELECT size FROM sizes WHERE prod_id = '{0}' AND colour_id = '{1}'",
                                                    prod2.Id, prod2.Colour_id);
                                                using var cmd3 = new MySqlCommand(sql3, con);
                                                using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                                                while (rdr3.Read())
                                                {
                                                    Foundsize = rdr3.GetString(0);
                                                    if (Foundsize != "")
                                                    {
                                                        prod2.Size = Foundsize;
                                                        Foundsize = "";
                                                    }
                                                }
                                                rdr3.Close();
                                            }
                                        }
                                    }
                                    else if (size == false)
                                    {
                                    }
                                }
                            }
                        }
                        else if (colour == false)
                        {
                            if (size == true)
                            {
                                for (int l = 0; l < searchSizeArray.Length; l++)
                                {
                                    foreach (var prod2 in foundProducts)
                                    {
                                        string sql3 = string.Format("SELECT size FROM sizes WHERE prod_id = '{0}'",
                                            prod2.Id);
                                        using var cmd3 = new MySqlCommand(sql3, con);
                                        using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                                        while (rdr3.Read())
                                        {
                                            Foundsize = rdr3.GetString(0);
                                            if (Foundsize != "")
                                            {
                                                prod2.Size = Foundsize;
                                                Foundsize = "";
                                            }
                                        }
                                        rdr3.Close();
                                    }
                                }
                            }
                            else if (size == false)
                            {
                            }
                        }
                    }
                }
                else if (type == false)
                {
                    if (colour == true)
                    {
                        for (int j = 0; j < searchColourArray.Length; j++)
                        {
                            string sql =
                                string.Format("SELECT prod_id, colour_id FROM colours WHERE colour ='{0}'",
                                    searchColourArray[j]);
                            using var cmd = new MySqlCommand(sql, con);
                            using MySqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                FoundprodId = rdr.GetInt32(0);
                                FoundcolourId = rdr.GetInt32(1);
                                if (FoundprodId != 0)
                                {
                                    Product newFound = new Product();
                                    newFound.Id = FoundprodId;
                                    newFound.Colour_id = FoundcolourId;
                                    foundProducts.Add(newFound);
                                    FoundprodId = 0;
                                    FoundcolourId = 0;
                                }
                            }
                            if (size == true)
                            {
                                for (int l = 0; l < searchSizeArray.Length; l++)
                                {
                                    foreach (var prod2 in foundProducts)
                                    {
                                        string sql3 = string.Format(
                                            "SELECT size FROM sizes WHERE prod_id = '{0}' AND colour_id = '{1}'",
                                            prod2.Id, prod2.Colour_id);
                                        using var cmd3 = new MySqlCommand(sql3, con);
                                        using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                                        while (rdr3.Read())
                                        {
                                            Foundsize = rdr3.GetString(0);
                                            if (Foundsize != "")
                                            {
                                                prod2.Size = Foundsize;
                                                Foundsize = "";
                                            }
                                        }
                                        rdr3.Close();
                                    }
                                }
                            }
                            else if (size == false)
                            {
                            }
                        }
                    }
                    else if (colour == false)
                    {
                        if (size == true)
                        {
                            for (int j = 0; j < searchSizeArray.Length; j++)
                            {
                                string sql =
                                    string.Format("SELECT prod_id, size FROM sizes WHERE size ='{0}'",
                                        searchSizeArray[j]);
                                using var cmd = new MySqlCommand(sql, con);
                                using MySqlDataReader rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    FoundprodId = rdr.GetInt32(0);
                                    Foundsize = rdr.GetString(1);
                                    if (FoundprodId != 0)
                                    {
                                        Product newFound = new Product();
                                        newFound.Id = FoundprodId;
                                        newFound.Size = Foundsize;
                                        foundProducts.Add(newFound);
                                        FoundprodId = 0;
                                        Foundsize = "";
                                    }
                                }
                            }
                        }
                        else if (size == false)
                        {
                        }
                    }
                }
            }

            List<Product> editedFoundProducts = new List<Product>();

            foreach (var prod in foundProducts)
            {
                if (category)
                {
                    if (type)
                    {
                        if (colour)
                        {
                            if (size)
                            {
                                if (prod.Id == 0 || prod.Colour_id == 0 || prod.Size == "")
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                            else if (!size)
                            {
                                if (prod.Id == 0 || prod.Colour_id == 0)
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                        }
                        else if (!colour)
                        {
                            if (size)
                            {
                                if (prod.Id == 0 || prod.Size == "" )
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                            else if (!size)
                            {
                                if (prod.Id == 0)
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                        }
                    }
                    else if (!type)
                    {
                        if (colour)
                        {
                            if (size)
                            {
                                if (prod.Id == 0 || prod.Colour_id == 0 || prod.Size == "")
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                            else if (!size)
                            {
                                if (prod.Id == 0 || prod.Colour_id == 0)
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                        }
                        else if (!colour)
                        {
                            if (size)
                            {
                                if (prod.Id == 0 || prod.Size == "" )
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                            else if (!size)
                            {
                                if (prod.Id == 0)
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                        }
                    }
                }
                else if (!category)
                {
                    if (type)
                    {
                        if (colour)
                        {
                            if (size)
                            {
                                if (prod.Id == 0 || prod.Colour_id == 0 || prod.Size == "")
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                            else if (!size)
                            {
                                if (prod.Id == 0 || prod.Colour_id == 0)
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                        }
                        else if (!colour)
                        {
                            if (size)
                            {
                                if (prod.Id == 0 || prod.Size == "" )
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                            else if (!size)
                            {
                                if (prod.Id == 0)
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                        }
                    }
                    else if (!type)
                    {
                        if (colour)
                        {
                            if (size)
                            {
                                if (prod.Id == 0 || prod.Colour_id == 0 || prod.Size == "")
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                            else if (!size)
                            {
                                if (prod.Id == 0 || prod.Colour_id == 0)
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                        }
                        else if (!colour)
                        {
                            if (size)
                            {
                                if (prod.Id == 0 || prod.Size == "" )
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                            else if (!size)
                            {
                                if (prod.Id == 0)
                                {
                                    editedFoundProducts.Add(prod);
                                }
                            }
                        }
                    }
                }
            }
            
            int foundProductsLength = foundProducts.Count;

            for (int i = 0; i < foundProductsLength; i++)
            {
                foreach (var prod in editedFoundProducts)
                {
                    if (foundProducts.Contains(prod))
                    {
                        foundProducts.Remove(prod);
                    }
                }
            }
            
            foundProducts.TrimExcess();

            foreach (var prod2 in foundProducts)
            {
                Console.WriteLine(prod2.Id);
            }


            string testbhgfds = "";


            // varierende SQL-kald alt efter mængden af parametertyper tilstede.

            // size, colour, type, category

            // type + category -> colour -> size


            string[] test = { "placeholder" };

            // return prod_id[]
            con.Close();
            return foundProducts;
        }

        public Product GetProdByID(int id)
        {
            using var con = new MySqlConnection(_cs);
            con.Open();

            Product searchedProduct = new Product();
            string sql =$"SELECT prod_name, price, prod_id FROM products WHERE prod_id = {id};";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                searchedProduct.Name = rdr.GetString(0);
                searchedProduct.Price = rdr.GetDouble(1);
                searchedProduct.Id = rdr.GetInt32(2);
            }

            rdr.Close();
            string sqlImg = $"SELECT img, colour_id, colour FROM colours WHERE prod_id = {id} LIMIT 1;";
            using var cmdImg = new MySqlCommand(sqlImg, con);
            using MySqlDataReader rdrImg = cmdImg.ExecuteReader();
            while (rdrImg.Read())
            {
                searchedProduct.ImageLink = rdrImg.GetString(0);
                searchedProduct.Colour_id = rdrImg.GetInt32(1);
                searchedProduct.Colour = rdrImg.GetString(2);
            }
            rdrImg.Close();

            string sqlSize = $"SELECT size FROM sizes WHERE prod_id = {id} LIMIT 1;";
            using var cmdSize = new MySqlCommand(sqlSize, con);
            using MySqlDataReader rdrSize = cmdSize.ExecuteReader();
            while (rdrSize.Read())
            {
                searchedProduct.Size = rdrSize.GetString(0);
            }
            rdrSize.Close();

            return searchedProduct;
        }

        public void Order(params object[] args)
        {
            using var con = new MySqlConnection(_cs);
            con.Open();
            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $@"INSERT INTO orders (firstname, lastname, email, phonenumber, city, street, zipcode, country, ordered_items) 
            VALUES ('{args[1]}','{args[2]}','{args[3]}','{args[4]}','{args[5]}','{args[6]}','{args[7]}','{args[8]}', '{args[9]}')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Stockchange(string callType, params object[] args)
        {
            using var con = new MySqlConnection(_cs);
            string sql = "";
            con.Open();
            if (callType == "Reduce stock")
            {
                string[] itemArray;
                itemArray = args[0].ToString().Split();
                for (int i = 0; i < (itemArray.Length-1)/2; i+=3)
                {
                    int ammount = 1;
                    int prodid = int.Parse(itemArray[i]);
                    string colour = itemArray[i+1];
                    string size = itemArray[i + 2];
                    sql = $"SELECT colour_id FROM colours WHERE prod_id = {prodid} AND colour = '{colour}'";
                    using var cmd = new MySqlCommand(sql, con);
                    using MySqlDataReader rdr = cmd.ExecuteReader();
                    int colourId = 0;
                    while (rdr.Read())
                    {
                        colourId = rdr.GetInt32(0);
                    }
                    rdr.Close();

                    using var cmd2 = new MySqlCommand();
                    sql = string.Format(@"UPDATE sizes SET stock = stock - '{0}' WHERE prod_id = '{1}' AND colour_id = '{2}' AND size = '{3}'", ammount, prodid, colourId, size);
                    cmd2.Connection = con;
                    cmd2.CommandText = sql;
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public string[] KPI(string callType, params object[] args)
        {
            using var con = new MySqlConnection(_cs);
            con.Open();
            
            int arraySize = 0;
            if (callType == "Type call")
            {
                string sql = "SELECT COUNT(type) as amount FROM types";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    arraySize = rdr.GetInt32(0);
                }
            }
            else if (callType == "Product type call")
            {
                arraySize = 10000;
            }
            string[] array = new string[arraySize];
            if (callType == "Type call")
            {

                string sql = "SELECT type FROM types";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                int i = 0;
                while (rdr.Read())
                {
                    array[i]= rdr.GetString(0);
                    i++;
                }
                con.Close();
            }
            else if (callType == "Product type call")
            {
                string[][] product = new string[10000][];
                
                string sql = "SELECT * FROM sizes";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                int h = 0;

                while (rdr.Read())
                {
                    string[] singleProduct = new string[9];
                    
                    singleProduct[0] = rdr.GetString(0);
                    singleProduct[1] = rdr.GetString(1);
                    singleProduct[2] = rdr.GetString(2);
                    singleProduct[3] = rdr.GetString(3);
                    product[h] = singleProduct;
                    h++;
                }
                rdr.Close();

                for (int j = 0; j < h; j++)
                {
                    string sql2 = $"SELECT colour, img FROM colours WHERE prod_id ={product[j][1]}  AND colour_id = {product[j][0]};";
                    using var cmd2 = new MySqlCommand(sql2, con);
                    using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        product[j][4] = rdr2.GetString(0);
                        product[j][5] = rdr2.GetString(1);
                    }
                    rdr2.Close();
                }
                
                
                for (int y = 0; y < h; y++)
                {
                    string sql3 = $"SELECT prod_name, type, price FROM products WHERE prod_id ={product[y][1]};";
                    using var cmd3 = new MySqlCommand(sql3, con);
                    using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                    while (rdr3.Read())
                    {
                        product[y][6] = rdr3.GetString(0);
                        product[y][7] = rdr3.GetString(1);
                        product[y][8] = rdr3.GetString(2);
                    }
                    rdr3.Close();
                }
            }
            else if (callType == "Specific product call")
            {
                
            }

            return array;
        }

        public string[][][] KPI2()
        { 
            
            using var con = new MySqlConnection(_cs);
            con.Open();

            string sql5 = "SELECT COUNT(colour_id) AS amount FROM sizes";
            using var cmd5 = new MySqlCommand(sql5, con);
            using MySqlDataReader rdr5 = cmd5.ExecuteReader();
            int productAmount = 0;
            
            while (rdr5.Read())
            {
                 productAmount = rdr5.GetInt32(0);
            }
            rdr5.Close();
            
            string[][] product = new string[productAmount][];

            string sql6 = "SELECT COUNT(type) AS amount FROM types";
            using var cmd6 = new MySqlCommand(sql6, con);
            using MySqlDataReader rdr6 = cmd6.ExecuteReader();
            int typeAmount = 0;
            
            while (rdr6.Read())
            {
                typeAmount = rdr6.GetInt32(0);
            }
            rdr6.Close();
            
            int f = 0;
            string[][] typeArray = new string[typeAmount][];
            
            string sql4 = "SELECT type FROM types";
            using var cmd4 = new MySqlCommand(sql4, con);
            using MySqlDataReader rdr4 = cmd4.ExecuteReader();
            while (rdr4.Read())
            {
                string[] fields = new string[2];
                typeArray[f] = fields;
                typeArray[f][0] = rdr4.GetString(0);
                typeArray[f][1] = 0.ToString();
                f++;
            }
            rdr4.Close();
            

            typeArray = typeArray.Where(c => c != null).ToArray();
            
            string sql = "SELECT * FROM sizes";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            int h = 0;

            while (rdr.Read())
            {
                string[] singleProduct = new string[9];
                
                singleProduct[0] = rdr.GetString(0);
                singleProduct[1] = rdr.GetString(1);
                singleProduct[2] = rdr.GetString(2);
                singleProduct[3] = rdr.GetString(3);
                product[h] = singleProduct;
                h++;
            }
            rdr.Close();

            for (int j = 0; j < h; j++)
            {
                string sql2 = $"SELECT colour, img FROM colours WHERE prod_id ={product[j][1]}  AND colour_id = {product[j][0]};";
                using var cmd2 = new MySqlCommand(sql2, con);
                using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    product[j][4] = rdr2.GetString(0);
                    product[j][5] = rdr2.GetString(1);
                }
                rdr2.Close();
            }
            
            
            for (int y = 0; y < h; y++)
            {
                string sql3 = $"SELECT prod_name, type, price FROM products WHERE prod_id ={product[y][1]};";
                using var cmd3 = new MySqlCommand(sql3, con);
                using MySqlDataReader rdr3 = cmd3.ExecuteReader();
                while (rdr3.Read())
                {
                    product[y][6] = rdr3.GetString(0);
                    product[y][7] = rdr3.GetString(1);
                    product[y][8] = rdr3.GetString(2);

                    for (int i = 0; i < typeAmount; i++)
                    {
                        if (product[y][7] == typeArray[i][0])
                        {
                            int amount = int.Parse(typeArray[i][1])+1;
                            typeArray[i][1] = amount.ToString();
                        }
                    }

                }
                rdr3.Close();
            }

            string[][][] test = new string[5][][];
            string[][] test2 = new string[4][];
            string[] test3 = new string[3];
            test3[0] = "test4";

            test[0] = test2;
            test[0][0] = test3;



            string[][][] sortedProducts = new string[typeAmount][][];

            for (int i = 0; i < typeAmount; i++)
            {
                int k = 0;
                int size = int.Parse(typeArray[i][1]);
                string[][] types = new string[size][];
                sortedProducts[i] = types;
                for (int j = 0; j < product.Length; j++)
                {
                    if (product[j][7] == typeArray[i][0] )
                    {
                        string[] productAttributes = new string[9];
                        sortedProducts[i][k] = productAttributes;
                        sortedProducts[i][k] = product[j];
                        k++;
                    }
                }
            }
            return sortedProducts;
        }
        public List<Product> KPI3(int product_ID)
        {
            int count = 0;
            List<Product> Sold = new List<Product>();
            using var con = new MySqlConnection(_cs);
            con.Open();

            string sql2 = $"SELECT sold, colour FROM colours WHERE prod_id = {product_ID}";
            using var cmd2 = new MySqlCommand(sql2, con);
            using MySqlDataReader rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {
                Product KPI = new Product();
                KPI.Sold = rdr2.GetInt32(0);
                KPI.Colour = rdr2.GetString(1);

                Sold.Add(KPI);

            }
            rdr2.Close();

            string sql = $"SELECT views FROM products WHERE prod_id = {product_ID}";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Sold[count].Views = rdr.GetInt32(0);

                count++;
            }
            rdr.Close();

            return Sold;
        }

        public string UserAdministration(string callType, params object[] args)
        {
            string returnString = "";

            if (callType == "New user")
            {
                string username = args[0].ToString();
                string password = args[1].ToString();
                string hashedPassword = EasyEncryption.SHA.ComputeSHA256Hash(password);
                string accessToken = EasyEncryption.SHA.ComputeSHA256Hash(DateTime.Now.ToString());
                
                using var con = new MySqlConnection(_cs);
                con.Open();
                using var cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = string.Format("INSERT INTO Login (username, hashed_password, access_token) VALUES ('{0}', '{1}', '{2}')", username, hashedPassword, accessToken);
                cmd.ExecuteNonQuery();
            }
            else if (callType == "User login")
            {
                string username = args[0].ToString();
                string password = args[1].ToString();
                string dbHashedPassword = "";
                string accessToken = "";
                var hashedPassword = EasyEncryption.SHA.ComputeSHA256Hash(password);
                
                using var con = new MySqlConnection(_cs);
                con.Open();
                string sql = string.Format("SELECT hashed_password FROM login WHERE username = '{0}'", username);
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dbHashedPassword = rdr.GetString(0);
                }
                rdr.Close();

                if (dbHashedPassword == "")
                {
                    Console.WriteLine("Wrong username");
                }

                else if (dbHashedPassword == hashedPassword)
                {
                    string sql2 = string.Format("SELECT access_token FROM login WHERE username = '{0}' AND hashed_password = '{1}'", username, hashedPassword);
                    using var cmd2 = new MySqlCommand(sql2, con);
                    using MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        accessToken = rdr2.GetString(0);
                       
                    }
                    rdr2.Close();
                    returnString = accessToken;
                }
                else if (dbHashedPassword != hashedPassword)
                {
                    Console.WriteLine("Wrong password");
                }
            }
            return returnString;
        }
        public bool Verify(string currentAccesToken)
        {
            string tokenInDb = "";
            using var con = new MySqlConnection(_cs);
            con.Open();
            string sql = string.Format("SELECT access_token FROM login WHERE access_token = '{0}'", currentAccesToken);
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tokenInDb = rdr.GetString(0);
            }
            rdr.Close();
            if (currentAccesToken != null)
            { 
                if (currentAccesToken.Equals(tokenInDb))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
               return false;
            }
        }
    }
}