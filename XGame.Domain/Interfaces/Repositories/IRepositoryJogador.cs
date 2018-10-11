using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        Jogador AutenticarJogador(AutenticarJogadorRequest request);
        Jogador AdicionarJogador(Jogador jogador);
        IEnumerable<Jogador> ListaJogador();
        Jogador ObterJogadorPorId(Guid id);
        void AlterarJogador(Jogador jogador);
    }
}
