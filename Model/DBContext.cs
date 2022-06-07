using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_MVVM.Model
{
    public class MusicContext :DbContext
    {

        /* public MusicContext() : base("name=CompanyConnectionString")
         {
             Database.SetInitializer(new DropCreateDatabaseAlways<MusicContext>());
         }
        */
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Albums { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=p4zaliczenie;trusted_connection=true;");
        }
    }
}
