using System.Collections.Generic;
using System.Dynamic;

namespace Project.CSharpFiles
{
    public class Order
    {
        public string Calltype { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Items { get; set; }
        public List<Product> OrderedItems = new List<Product>();

        public void Dbcall(string type)
        {
            Calltype = type;
            DbCall call = new DbCall();
            Items = Items.Substring(2);
            Items += ",";
            call.Order(Calltype, Firstname, Lastname, Email, Phonenumber, Adress, City, Zipcode, Country, Items);
        }
    }
    
    
}