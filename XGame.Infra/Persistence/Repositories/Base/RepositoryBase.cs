using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Entities.Base;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntidade, TId> : IRepositoryBase<TEntidade, TId>
        where TEntidade : EntityBase
        where TId : struct
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            this._context = context;
        }

        public TEntidade Adicionar(TEntidade entidade)
        {
            _context.Set<TEntidade>().Add(entidade);
            _context.SaveChanges();
            return entidade;
        }

        public IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades)
        {
            return _context.Set<TEntidade>().AddRange(entidades);
        }

        public TEntidade Editar(TEntidade entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return entidade;
        }

        public bool Existe(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return _context.Set<TEntidade>();
        }

        public IQueryable<TEntidade> ListarEOrdenarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }

        public IQueryable<TEntidade> ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            throw new NotImplementedException();
            //return Listar(includeProperties).FirstOrDefault(where);
        }

        public TEntidade ObterporId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Remover(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
            _context.SaveChanges();
        }
    }
}
