using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MostLib;
using MostLib.Enums;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;

namespace MostAspNetCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Penalty> Penalties { get; set; }  //Таблица штрафов
        public DbSet<Product> Products { get; set; }
        public DbSet<MostLib.Route> Routes { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Transport> Transports { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>()
                .Property(building => building.BuildingTypeId)
                .HasConversion(
                    property => (int)property,                 //Хранит в базе как int
                    property => (BuildingType)property);       //Возвращает из базы как BuildingType

           /* modelBuilder.Entity<Driver>()
                .Property(driver => driver.DriverLicenseCategory)
                .HasConversion(
                    property => JsonConvert.SerializeObject(property),                                  //Хранит в базе как JSON
                    property => JsonConvert.DeserializeObject<List<DriverLicenseCategory>>(property));  //Возвращает из базы как List<DriverLicenseCategory>*/

            modelBuilder.Entity<Product>()
                .Property(product => product.ProductPackageTypeId)
                .HasConversion(
                    property => (int)property,                      //Хранит в базе как int
                    property => (ProductPackageType)property);      //Возвращает из базы как ProductPackageType

            modelBuilder.Entity<Product>()
                .Property(product => product.ProductCategoryId)
                .HasConversion(
                    property => (int)property,                      //Хранит в базе как int
                    property => (ProductCategory)property);         //Возвращает из базы как ProductCategory

            modelBuilder.Entity<MostLib.Route>()
                .Property(route => route.Buildings)
                .HasConversion(
                    property => JsonConvert.SerializeObject(property),                      //Хранит в базе как JSON
                    property => JsonConvert.DeserializeObject<List<Building>>(property));   //Возвращает из базы как List<Building>

            modelBuilder.Entity<MostLib.Route>()
                .Property(product => product.Cargos)
                .HasConversion(
                    property => JsonConvert.SerializeObject(property),                                //Хранит в базе как JSON
                    property => JsonConvert.DeserializeObject<Dictionary<Product, int>>(property));   //Возвращает из базы как List<Building>

            modelBuilder.Entity<Trailer>()
                .Property(transport => transport.TrailerTypeId)
                .HasConversion(
                    property => (int)property,               //Хранит в базе как int
                    property => (TrailerType)property);      //Возвращает из базы как TrailerType

            modelBuilder.Entity<Trailer>()
                .Property(transport => transport.TrailerAxesTypeId)
                .HasConversion(
                    property => (int)property,                  //Хранит в базе как int
                    property => (TrailerAxesType)property);     //Возвращает из базы как TrailerType

            modelBuilder.Entity<Transport>()
                .Property(transport => transport.TransportTypeId)
                .HasConversion(
                    property => (int)property,                 //Хранит в базе как int
                    property => (TransportType)property);      //Возвращает из базы как TransportType

            modelBuilder.Entity<Transport>()
                .Property(transport => transport.AxesTypeId)
                .HasConversion(
                    property => (int)property,                  //Хранит в базе как int
                    property => (TransportAxesType)property);   //Возвращает из базы как TransportAxesType
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
