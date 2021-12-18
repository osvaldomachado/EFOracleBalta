using Microsoft.EntityFrameworkCore;

namespace Todo.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios {get;set;}
        public DbSet<Setor> Setores {get;set;}

       protected override void OnConfiguring(DbContextOptionsBuilder options)
       { 
           options.UseOracle("Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.1.49 )    (PORT = 1521)) )  (CONNECT_DATA = (SERVER = DEDICATED) (SID = TESTE))); Persist Security info = true; User ID = teste; Password = teste", options => options
                            .UseOracleSQLCompatibility("11"));        
           options.LogTo(Console.WriteLine); //  Este mostra os selects também                       

       }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new SetorMap());

           //modelBuilder.Entity<Car>().HasKey(c => new { c.State, c.LicensePlate });
           //modelBuilder.Entity<Usuario>().HasKey(x => new { x.MATRICULA});
        }            
              
    }
}