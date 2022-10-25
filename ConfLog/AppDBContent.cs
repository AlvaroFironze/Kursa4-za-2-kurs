using ConfLog.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfLog
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Using> Usings { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FType> FType {get;set;}
        public DbSet<Order> Orders { get; set; }

    }
}
