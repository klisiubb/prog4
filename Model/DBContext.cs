using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace P4_MVVM.Model
{
    public class MusicContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }

        private readonly string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conStr);
            //optionsBuilder.UseSqlServer("server=.;database=p4zaliczenie;trusted_connection=true;");
        }
    }
}
