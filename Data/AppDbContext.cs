using EcommerceCenima.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCenima.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActors>().HasKey(m => new {m.MovieId,m.ActorId});
            modelBuilder.Entity<MovieActors>().HasOne(m=>m.Movie).WithMany(m=>m.MovieActors).HasForeignKey(m=>m.MovieId);   
            modelBuilder.Entity<MovieActors>().HasOne(m=>m.Actor).WithMany(m=>m.MovieActors).HasForeignKey(m=>m.ActorId);   
            base.OnModelCreating(modelBuilder);
        }

        internal Task SavingChangesAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<MovieActors> MovieActors { get; set; }
    }
}
