using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MosEisleyCantinaOnTatooine.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosEisleyCantinaOnTatooine.Persistence
{
    public class DbContextMenuItems : DbContext
    {
        public DbContextMenuItems(DbContextOptions<DbContextMenuItems> options)
            : base(options)
        {
        
        }
        public virtual DbSet<MenuItems> MenuItems { get; set; }
        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MosEisleyCantinaOnTatooine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
