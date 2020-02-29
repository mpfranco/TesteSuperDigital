using Conta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NmCliente)
            .IsRequired()
            .HasColumnType("varchar(50)");

            builder.Property(x => x.CPF)
            .IsRequired()
            .HasColumnType("varchar(11)");

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
            builder.ToTable("Clientes");
        }
    }
}
