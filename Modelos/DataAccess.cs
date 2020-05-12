using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models{
    public class LibraryDbContext : DbContext{
        public RestaurantDbContext(DbContextOptions<LibraryDbContext> data)
        :base (data){}
        public DbSet <Tab_Cliente> Tab_Cliente{get; set;}
        public DbSet <Tab_Categoria> Tab_Categoria{get; set;}
        public DbSet <Tab_Concepto> Tab_Concepto{get; set;}
        public DbSet <Tab_Inventario> Tab_Inventario{get; set;}
         public DbSet <Tab_Unidad> Tab_Unidad{get; set;}
        public DbSet <Enc_Factura> Enc_Factura{get; set;}
        public DbSet <Deta_Factura> Deta_Factura{get; set;}
        
        }
        
    }