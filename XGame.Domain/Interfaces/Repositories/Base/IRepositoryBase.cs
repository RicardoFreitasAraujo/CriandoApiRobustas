using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XGame.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntidade, TId>
        where TEntidade: class
        where TId: struct
    {
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> ListarEOrdenarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        bool Existe(Func<TEntidade, bool> where);

        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade,object>>[] includeProperties);

        TEntidade ObterporId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade Adicionar(TEntidade entidade);

        TEntidade Editar(TEntidade entidade);

        void Remover(TEntidade entidade);

        IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades);

    }
}
