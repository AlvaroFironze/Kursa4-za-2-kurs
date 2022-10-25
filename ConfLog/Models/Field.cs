namespace ConfLog.Models
{
    public class Field
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public List<Function> functions { get; set; }
    }
}
