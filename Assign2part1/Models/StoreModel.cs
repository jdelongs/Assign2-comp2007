namespace Assign2part1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreModel : DbContext
    {
        public StoreModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<beer> beers { get; set; }
        public virtual DbSet<brewery> breweries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<beer>()
                .Property(e => e.beerName)
                .IsUnicode(false);

            modelBuilder.Entity<beer>()
                .Property(e => e.beerType)
                .IsUnicode(false);

            modelBuilder.Entity<beer>()
                .Property(e => e.canOrBottle)
                .IsUnicode(false);

            modelBuilder.Entity<brewery>()
                .Property(e => e.breweryLocation)
                .IsUnicode(false);

            modelBuilder.Entity<brewery>()
                .Property(e => e.breweryName)
                .IsUnicode(false);

            modelBuilder.Entity<brewery>()
                .Property(e => e.features)
                .IsUnicode(false);
        }
    }
}
