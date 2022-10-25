namespace ConfLog.Models
{
    public class Function
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? desk { get; set; }
        public int? level { get; set; }
        public bool isBase { get; set; }

        public string code { get; set; }
        public string? img { get; set; }
        public int typeID { get; set; }
        public string? toUse { get; set; } 
        public List<Using>? usings { get; set; } 
        public List<Field>? fields { get; set; }
        public virtual FType type { get; set; }
        public List<Order> orders { get; set; }


    }
}
