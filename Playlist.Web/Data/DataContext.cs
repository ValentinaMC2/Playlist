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

        public DbSet<UserSong> UserSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary key configuration for the UserSong entity.
            modelBuilder.Entity<UserSong>()
                .HasKey(us => new { us.UserId, us.SongId });
        }

    }

}
