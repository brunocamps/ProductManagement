﻿using Accreditaire.Business.Models.Fornecedores;
using Accreditaire.Business.Models.Produtos;
using Accreditaire.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accreditaire.Infra.Data.Context
{
    public class MeuDbContext : DbContext // herda de DbContext
    {
        public MeuDbContext() : base("DefaultConnection") // passa p/ construtor da classe base uma connnection string chamada DefaultConnection
        { }

        // mapeamento DbSet
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        // overwrite

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
        }



    }
}
