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

        public void Dbcall(string type)
        {
            Calltype = type;
            DbCall call = new DbCall();
            call.Order(Calltype, Firstname, Lastname, Email, Phonenumber, Adress, City, Zipcode, Country);
        }
    }
    
    
}