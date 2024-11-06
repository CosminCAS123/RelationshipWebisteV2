using Microsoft.EntityFrameworkCore;
using RelationshipWebsiteV2.Models;

namespace RelationshipWebsiteV2
{
    public class RelationshipDBContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public string DbPath { get; private set; }

        public RelationshipDBContext()
        {

            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            this.DbPath = System.IO.Path.Join(path, "relationshipwebsite.db");
            
        
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }



    }
}
