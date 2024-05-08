using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class CarBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1450;Database=CarBookDB;User Id=sa;Password=Mamakasml06;TrustServerCertificate=True;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(x => x.Brand)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.BrandID);

            modelBuilder.Entity<CarDescription>()
                .HasOne(x => x.Car)
                .WithMany(x => x.CarDescriptions)
                .HasForeignKey(x => x.CarID);

            modelBuilder.Entity<CarFeature>()
                .HasOne(x => x.Car)
                .WithMany(x => x.CarFeatures)
                .HasForeignKey(x => x.CarID);

            modelBuilder.Entity<CarPricing>()
                .HasOne(x => x.Car)
                .WithMany(x => x.CarPricings)
                .HasForeignKey(x => x.CarID);

            modelBuilder.Entity<CarFeature>()
                .HasOne(x => x.Feature)
                .WithMany(x => x.CarFeatures)
                .HasForeignKey(x => x.FeatureID);

            modelBuilder.Entity<CarPricing>()
                .HasOne(x => x.Pricing)
                .WithMany(x => x.CarPricings)
                .HasForeignKey(x => x.PricingID);
        }
    }
}
