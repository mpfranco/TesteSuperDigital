using Conta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conta.Infra.Data.Mappings
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContaDestino)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.ContaOrigem)
             .IsRequired()
             .HasColumnType("varchar(50)");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("money");
           

            builder.Property(x => x.Ativo)
              .IsRequired()
              .HasColumnType("bit");

            builder.Property(x => x.DataInclusao)
               .IsRequired()
               .HasColumnType("datetime");

            builder.Property(x => x.UsuarioInclusaoId)
               .IsRequired()
               .HasColumnType("bigint");

            builder.Property(x => x.DataAlteracao)
               .IsRequired()
               .HasColumnType("datetime");

            builder.Property(x => x.UsuarioAlteracaoId)
               .IsRequired()
               .HasColumnType("bigint");

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
            builder.ToTable("Lancamentos");
        }
    }
}
