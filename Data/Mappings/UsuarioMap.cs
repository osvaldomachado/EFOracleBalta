using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.Models
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("PCEMPR");
            builder.HasKey(x => x.MATRICULA); 
            builder.Property("NOME").HasColumnName("NOME");            
           // builder.Property("CODSETOR").HasColumnName("CODSETOR");            
           // builder.HasOne(x => x.CODSETOR);     //caso for um para muitos usar depois .WithMany      
        }
    }
}