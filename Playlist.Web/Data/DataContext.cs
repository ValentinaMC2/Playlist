using Playlist.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Playlist.Web.Data
{
    public class DataContext : DbContext //Mapper - Data context of my application.
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } //Mapping table in database...

        public DbSet<Song> Songs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }

}

