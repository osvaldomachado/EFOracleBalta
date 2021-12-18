using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.Models
{
    public class SetorMap : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable("PCSETOR");
            builder.HasKey(x => x.CODSETOR); 
            builder.Property("DESCRICAO").HasColumnName("DESCRICAO");                        
        }
    }
}