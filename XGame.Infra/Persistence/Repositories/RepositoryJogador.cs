using System;
using System.Linq;
using System.Collections.Generic;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador: RepositoryBase<Jogador,Guid>, IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context): base(context)
        {
            this._context = context;
        }
    }
}
