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
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentalTransactions> RentalTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table Relationship

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

            modelBuilder.Entity<CarRental>()
                .HasOne(x => x.Car)
                .WithMany(x => x.CarRentals)
                .HasForeignKey(x => x.CarID);

            modelBuilder.Entity<CarRental>()
                .HasOne(x => x.Location)
                .WithMany(x => x.CarRentals)
                .HasForeignKey(x => x.LocationID);

            modelBuilder.Entity<RentalTransactions>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.RentalTransactions)
                .HasForeignKey(x => x.CustomerID);

            modelBuilder.Entity<RentalTransactions>()
                .HasOne(x => x.Car)
                .WithMany(x => x.RentalTransactions)
                .HasForeignKey(x => x.CarID);

            // Table Column Type

            modelBuilder.Entity<RentalTransactions>()
                .Property(x => x.PickUpDate)
                .HasColumnType("Date");

            modelBuilder.Entity<RentalTransactions>()
                .Property(x => x.DropOffDate)
                .HasColumnType("Date");

            modelBuilder.Entity<RentalTransactions>()
                .Property(x => x.PickUpTime)
                .HasColumnType("Time");

            modelBuilder.Entity<RentalTransactions>()
                .Property(x => x.DropOffTime)
                .HasColumnType("Time");

            // Table Primary Key

            modelBuilder.Entity<About>().HasKey(x => x.AboutID);
            modelBuilder.Entity<Banner>().HasKey(x => x.BannerID);
            modelBuilder.Entity<Brand>().HasKey(x => x.BrandID);
            modelBuilder.Entity<Car>().HasKey(x => x.CarID);
            modelBuilder.Entity<CarDescription>().HasKey(x => x.CarDescriptionID);
            modelBuilder.Entity<CarFeature>().HasKey(x => x.CarFeatureID);
            modelBuilder.Entity<CarPricing>().HasKey(x => x.CarPricingID);
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryID);
            modelBuilder.Entity<Contact>().HasKey(x => x.ContactID);
            modelBuilder.Entity<Feature>().HasKey(x => x.FeatureID);
            modelBuilder.Entity<Footer>().HasKey(x => x.FooterID);
            modelBuilder.Entity<Location>().HasKey(x => x.LocationID);
            modelBuilder.Entity<Pricing>().HasKey(x => x.PricingID);
            modelBuilder.Entity<Service>().HasKey(x => x.ServiceID);
            modelBuilder.Entity<SocialMedia>().HasKey(x => x.SocialMediaID);
            modelBuilder.Entity<Testimonial>().HasKey(x => x.TestimonialID);
            modelBuilder.Entity<CarRental>().HasKey(x => x.CarRentalID);
            modelBuilder.Entity<RentalTransactions>().HasKey(x => x.RentalTransactionsID);
            modelBuilder.Entity<Customer>().HasKey(x => x.CustomerID);
        }
    }
}
