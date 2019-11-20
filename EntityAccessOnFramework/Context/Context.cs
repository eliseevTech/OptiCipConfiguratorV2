using EntityAccessOnFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Data
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
            Database.SetInitializer<Context>(null);
        }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<LineObject> Objects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineObject>().HasKey(O => new { O.ProjectId,O.GroupId,O.StationId,O.LineId,O.Id});
        }
    }
}
