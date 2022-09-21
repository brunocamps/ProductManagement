using Accreditaire.Business.Models.Fornecedores;
using Accreditaire.Business.Models.Produtos;
using Accreditaire.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accreditaire.Infra.Data.Context
{
    public class MeuDbContext : DbContext // herda de DbContext
    {
        public MeuDbContext() : base("DefaultConnection") // passa p/ construtor da classe base uma connnection string chamada DefaultConnection
        {
            // diminuem muito a performance da aplicação caso estejam ligados
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        // mapeamento DbSet
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        // overwrite

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // EF é feito de convenções. você pode criar ou usar convenções existentes


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar").HasMaxLength(100));

              
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());

            base.OnModelCreating(modelBuilder);
        }




    }
}
