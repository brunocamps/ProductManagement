using Accreditaire.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accreditaire.Infra.Data.Mappings
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor> // fluent API representada pela classe entitytypecinfiguration
    {
        // mapeamento feito pelo FluentApi pela entidade Fornecedor
        // por isso, a camada de acesso a dados precisa conhecer a camada
        // de negocios, pois mapeia esses objetos.

        // construtor

        public FornecedorConfig()
        {
            HasKey(f => f.Id); // chave primaria

            Property(f => f.Nome).IsRequired().HasMaxLength(200);

            Property(f => f.Documento).IsRequired().HasMaxLength(14).HasColumnAnnotation("IX_Documento", new IndexAnnotation(new IndexAttribute {IsUnique = true}));

            // relacionamento

            HasRequired(f => f.Endereco).WithRequiredPrincipal(e => e.Fornecedor);
            // Fornecedor tem um endereço requerido e o principal nessa
            // relação é o fornecedor.
            ToTable("Fornecedores");
            
            
            
            
            // HasRequired é um relacionamento obrigatorio
            //HasOptional é um relacionamento opcional

        }
    }
}
