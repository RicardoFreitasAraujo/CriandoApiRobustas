using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }

        public ServiceJogador(IRepositoryJogador repository)
        {
            this._repositoryJogador = repository;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            Nome nome = new Nome(request.PrimeiroNome,request.UltimoNome);
            Email email = new Email(request.Email);
            Jogador jogador = new Jogador(nome,email,request.Senha);

            this.AddNotifications(nome, email);

            if (_repositoryJogador.Existe(x => x.Email.Endereco == request.Email))
            {
                this.AddNotification(new Notification("Email","Já existe um e-mail chamado " + request.Email));
            }

            if (this.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.Adicionar(jogador);
            return new AdicionarJogadorResponse() { Id = jogador.Id, Message = "Operação realizada com sucesso" };
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                this.AddNotification("AlterarJogador", Message.X0_E_OBRIGATORIO.ToFormat("AlterarJogadorRequest"));
            }

            Jogador jogador = _repositoryJogador.ObterporId(request.Id);

            if (jogador == null)
            {
                this.AddNotification("Id", "Dados Não encontrado");
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email);

            this.AddNotifications(jogador, email);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositoryJogador.Editar(jogador);
            return (AlterarJogadorResponse)jogador;

        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest",  string.Format(Message.X0_E_OBRIGATORIO, "AutenticarJogadorRequest"));
            }

            var email = new Email(request.Email);
            Jogador jogador = new Jogador(email,request.Senha);

            AddNotifications(jogador, email);
            if (jogador.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco == request.Email && x.Senha == request.Senha).First();

            return (AutenticarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            return _repositoryJogador.Listar().Select(x =>  new JogadorResponse() {
                Id = x.Id,
                NomeCompleto = x.Nome.PrimeiroNome + " " + x.Nome.UltimoNome,
                PrimeiroNome = x.Nome.PrimeiroNome,
                UltimoNome = x.Nome.UltimoNome,
                Email = x.Email.Endereco
            }).ToList();
        }

        public ResponseBase ExcluirJogador(Guid id)
        {
            Jogador jogador = _repositoryJogador.ObterporId(id);

            if (jogador == null)
            {
                this.AddNotification("Id", "Dados Não Encontrados");
                return null;
            }

            this._repositoryJogador.Remover(jogador);

            return new ResponseBase();
        }
    }
}
