using System;
using System.Linq;
using System.Collections.Generic;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador: IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context)
        {
            this._context = context;
        }

        public Jogador AdicionarJogador(Jogador jogador)
        {
            this._context.Jogadores.Add(jogador);
            _context.SaveChanges();
            return jogador;
        }

        public void AlterarJogador(Jogador jogador)
        {
            this._context.Entry<Jogador>(jogador).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public Jogador AutenticarJogador(AutenticarJogadorRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogador> ListaJogador()
        {
            return _context.Jogadores.ToList();
        }

        public Jogador ObterJogadorPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public int CalculaJogadores()
        {
            var jogadoresAtivos = _context.Jogadores.Where(x=> x.Status == Domain.Enum.EnumSituacaoJogador.Ativo).ToList();

            jogadoresAtivos.Where(x => x.Nome.PrimeiroNome.Contains("p"));

            return 0;
        }
    }
}
