using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Prova.Domain.Entities;

namespace Prova.Infrastructure.Data.Config
{
    public class ContatoConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.DataNascimento).HasColumnType("date").HasColumnName("data_nascimento");
            builder.Property(p => p.Sexo).HasColumnName("sexo"); 
            builder.Property(p => p.IsAtivo).HasColumnName("is_ativo");
        }
    }
}
