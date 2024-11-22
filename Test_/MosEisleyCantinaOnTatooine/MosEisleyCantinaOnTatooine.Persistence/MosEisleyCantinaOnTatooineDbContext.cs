using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MosEisleyCantinaOnTatooine.DTO;

namespace MosEisleyCantinaOnTatooine.Persistence
{
    public class MosEisleyCantinaOnTatooineDbContext: DbContext
    {
        public MosEisleyCantinaOnTatooineDbContext() { }

        public MosEisleyCantinaOnTatooineDbContext(DbContextOptions<MosEisleyCantinaOnTatooineDbContext> options) 
            : base(options)
        {
        }

        public DbSet<MenuItemsDTO> MenuItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MosEisleyCantinaOnTatooine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItemsDTO>(entity =>
            {
                entity.ToTable("MenuItemsDTO");
                entity.HasKey(p => p.Id).HasName("PK_User");
                entity.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int").ValueGeneratedNever();
                entity.Property(p => p.ItemName)
                .HasColumnName("name");

                entity.Property(p => p.Description)
                .HasColumnName("description ");

                entity.Property(p => p.Price)
                .HasColumnName("price");

                entity.Property(p => p.Image_Url)
                .HasColumnName("image_url");
            });
        }
    }
}
