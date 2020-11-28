using System;
using Microsoft.EntityFrameworkCore;

namespace DbComplimentYoutubeImdb
{
    public class ContextComplimentYoutubeImdb : DbContext
    {
        public DbSet<MovieLink> MovieLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"server=.\SQLExpress;" +
                @"database=NetflexMovieLinks;" +
                @"trusted_connection=true;" +
                @"MultipleActiveResultSets=True"
                );
        }

        // Sätter ImdbId som primary key
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieLink>(entity => { entity.HasKey(m => m.ImdbID); });
            base.OnModelCreating(modelBuilder);
        }
    }
}
