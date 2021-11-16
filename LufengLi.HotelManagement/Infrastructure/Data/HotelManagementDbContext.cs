using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> CUSTOMERS { get; set; }
        public DbSet<RoomType> ROOMTYPES { get; set; }
        public DbSet<Room> ROOMS { get; set; }
        public DbSet<Service> SERVICES { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(ConfigureCustomers);
            modelBuilder.Entity<RoomType>(ConfigureRoomTypes);
            modelBuilder.Entity<Service>(ConfigureServices);
            modelBuilder.Entity<Room>(ConfigureRooms);
        }
        private void ConfigureCustomers(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CUSTOMERS");
            builder.Property(c => c.CheckIn).HasColumnType("datetime");
            builder.Property(c => c.Advance).HasColumnType("money");
            builder.HasOne(c => c.Room).WithMany(c => c.Customers).HasForeignKey(c => c.RoomNo);


        }
        private void ConfigureRoomTypes(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("ROOMTYPES");
            builder.Property(rt => rt.Rent).HasColumnType("money");

        }
        private void ConfigureRooms(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("ROOMS");
            builder.HasOne(r => r.RoomType).WithMany(r => r.Rooms).HasForeignKey(r => r.RTCode);

        }
        private void ConfigureServices(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("SERVICES");
            builder.Property(s => s.Amount).HasColumnType("money");
            builder.Property(s => s.ServiceDate).HasColumnType("datetime");
            builder.HasOne(s => s.Room).WithMany(r => r.Services).HasForeignKey(r => r.RoomNO);


        }
    }
}
