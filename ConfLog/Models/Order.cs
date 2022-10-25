namespace ConfLog.Models
{
    public class Order
    {
        public int id { get; set; }
        public List<Constructor> constructors { get; set; }
        public List<Function>? functions { get; set; }   
        public string? result { get; set; }
        public DateTime orderTime { get; set; }=DateTime.Now;

    }
}
