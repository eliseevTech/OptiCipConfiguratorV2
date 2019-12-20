using EntityAccessOnFramework.Models;
using JetEntityFrameworkProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Data
{
    public class AccessContext : DbContext
    {


        public AccessContext(string connectionString) : base(new JetConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source='" + connectionString + "';"), true)
        {
            Database.SetInitializer<AccessContext>(null);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<LineObject> Objects { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<LineTag> LineTags { get; set; } 
        public DbSet<OpcShortLink> OpcShortLinks { get; set; }
        
         

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasKey(G => new { G.ProjectId, G.Id });
            modelBuilder.Entity<Station>().HasKey(S => new { S.ProjectId, S.GroupId, S.Id });
            modelBuilder.Entity<Line>().HasKey(L => new { L.ProjectId, L.GroupId, L.StationId , L.Id });

            modelBuilder.Entity<LineObject>().HasKey(O => new { O.ProjectId,O.GroupId,O.StationId,O.LineId,O.Id});
            modelBuilder.Entity<LineTag>().HasKey(T => new { T.ProjectId, T.GroupId, T.StationId, T.LineId, T.TagId });

            modelBuilder.Entity<Tag>().HasKey(T => new { T.Id, T.ProjectId });

            modelBuilder.Entity<OpcShortLink>().HasKey(O => new { O.Id, O.Name });
        }
    }
}
