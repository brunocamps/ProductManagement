using Accreditaire.Business.Core.Data;
using Accreditaire.Business.Core.Models;
using Accreditaire.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accreditaire.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()// generica, portanto esta classe precisa ser generica tambem (TEntity)
    {
        // estrategia de repositorio generico
        // alguns metodos sao virtuais porque na hora de implementar os metodos, voce podera modifica-los
        // public abstract class: nao pode implementar sozinha, tem que herda-la
        // Esta classe repository faz tudo aquilo que a nossa interface (IRepository) implementou

        protected readonly MeuDbContext Db; // protected porque so quem herda dela pode enxergar

        protected readonly DbSet<TEntity> DbSet;

        protected Repository()
        {
            Db = new MeuDbContext();
            DbSet = Db.Set<TEntity>();  

        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            // Atualizar o estado da entidade
            Db.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }
        //852
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
  

        public virtual async Task Remover(Guid id)
        {
            // economiza uma ida ao banco
            Db.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose(); // so chama se tiver instancia definida
        }
    }
}
