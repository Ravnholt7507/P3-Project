namespace ConsoleApplication1
{
    public class CustomType
    {
        public CustomType(string id, string type)
        {
            this.Id = id;
            this.Type = type;
        }
        public string Id { get; set; }
        public string Type { get; set; }
    }
}