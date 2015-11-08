using System.Data.Entity;

namespace LookingForGroup.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("LfgConnection")
        {
            
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Party> Parties { get; set; }
    }
}