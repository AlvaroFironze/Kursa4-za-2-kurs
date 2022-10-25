namespace ConfLog.Models
{
    public class Constructor
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string link {get;set;}
        public string field { get; set; }
        public List<Order> orders { get; set; }  

    }
}
