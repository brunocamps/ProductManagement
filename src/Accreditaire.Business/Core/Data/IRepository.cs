using Accreditaire.Business.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accreditaire.Business.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity); //async

        Task<TEntity> ObterPorId(Guid id); //async

        Task<List<TEntity>> ObterTodos(); // lista de entidades

        Task Atualizar(TEntity entity); 

        Task Remover(Guid id); // recebe um ID ao inves de objeto

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges(); // int eh o numero de linhas afetadas apos persistir no banco
    }
}
